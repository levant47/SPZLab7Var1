using Newtonsoft.Json;
using SPZLab7Var1.Models;
using SPZLab7Var1.Repositories;
using System;
using System.IO;
using System.Windows.Forms;

namespace SPZLab7Var1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateFullView();
        }

        private void UpdateFullView()
        {
            UpdateTeachersGrid();
            UpdateSubjectsGrid();
        }

        private void UpdateTeachersGrid()
        {
            teachersDataGridView.Rows.Clear();
            TeachersRepository.GetAll().ForEach(teacher => teachersDataGridView.Rows.Add(teacher.Name, teacher.Age));
        }

        private void UpdateSubjectsGrid()
        {
            subjectDataGridView.Rows.Clear();
            SubjectsRepository.GetAll().ForEach(subject => subjectDataGridView.Rows.Add(subject.Name, subject.Faculty));
        }

        private void teacherCreateButton_Click(object sender, EventArgs e) => new DetailedTeacherForm
        (
            null,
            SubjectsRepository.GetAll(),
            newTeacherVM =>
            {
                var newTeacherId = TeachersRepository.Add(newTeacherVM.Teacher).Id;
                TeacherSubjectRepository.AddSubjectsForTeacher(newTeacherId, newTeacherVM.SubjectIds);
                UpdateTeachersGrid();
                return true;
            }
        ).Show();

        private void teacherEditButton_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = GetSelectedRowIndex(teachersDataGridView);
            if (selectedRowIndex == null)
            {
                return;
            }
            var teacher = TeachersRepository.GetAll()[(int)selectedRowIndex];
            var teacherVM = new TeacherVM
            {
                Teacher = teacher,
                SubjectIds = TeacherSubjectRepository.GetSubjectsForTeacher(teacher.Id),
            };
            new DetailedTeacherForm
            (
                teacherVM,
                SubjectsRepository.GetAll(),
                updatedTeacherVM =>
                {
                    TeachersRepository.Update(updatedTeacherVM.Teacher);
                    TeacherSubjectRepository.UpdateSubjectsForTeacher(updatedTeacherVM.Teacher.Id, updatedTeacherVM.SubjectIds);
                    UpdateTeachersGrid();
                    return true;
                }
            ).Show();
        }

        private void teacherDeleteButton_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = GetSelectedRowIndex(teachersDataGridView);
            if (selectedRowIndex == null)
            {
                return;
            }
            TeachersRepository.Delete(TeachersRepository.GetAll()[(int)selectedRowIndex].Id);
            UpdateTeachersGrid();
        }

        private int? GetSelectedRowIndex(DataGridView dataGridView) => dataGridView.SelectedRows.Count == 1
            ? dataGridView.SelectedRows[0].Index
            : dataGridView.SelectedCells.Count == 1
            ? dataGridView.SelectedCells[0].RowIndex
            : (int?)null;

        private void subjectCreateButton_Click(object sender, EventArgs e) => new DetailedSubjectForm
        (
            null,
            TeachersRepository.GetAll(),
            newSubjectVM =>
            {
                var newSubjectId = SubjectsRepository.Add(newSubjectVM.Subject).Id;
                TeacherSubjectRepository.AddTeachersForSubject(newSubjectId, newSubjectVM.TeacherIds);
                UpdateSubjectsGrid();
                return true;
            }
        ).Show();

        private void subjectEditButton_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = GetSelectedRowIndex(subjectDataGridView);
            if (selectedRowIndex == null)
            {
                return;
            }
            var subject = SubjectsRepository.GetAll()[(int)selectedRowIndex];
            var subjectVM = new SubjectVM
            {
                Subject = subject,
                TeacherIds = TeacherSubjectRepository.GetTeachersForSubject(subject.Id),
            };
            new DetailedSubjectForm
            (
                subjectVM,
                TeachersRepository.GetAll(),
                updatedSubjectVM =>
                {
                    SubjectsRepository.Update(updatedSubjectVM.Subject);
                    TeacherSubjectRepository.UpdateTeachersForSubject(updatedSubjectVM.Subject.Id, updatedSubjectVM.TeacherIds);
                    UpdateSubjectsGrid();
                    return true;
                }
            ).Show();
        }

        private void subjectDeleteButton_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = GetSelectedRowIndex(subjectDataGridView);
            if (selectedRowIndex == null)
            {
                return;
            }
            SubjectsRepository.Delete(SubjectsRepository.GetAll()[(int)selectedRowIndex].Id);
            UpdateSubjectsGrid();
        }
    }
}

