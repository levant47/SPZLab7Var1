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
            SubjectsRepository.Subjects.ForEach(subject => subjectDataGridView.Rows.Add(subject.Name, subject.Faculty));
        }

        private void teacherCreateButton_Click(object sender, EventArgs e) => new DetailedTeacherForm
        (
            null,
            SubjectsRepository.Subjects,
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
            var teacher = TeachersRepository.Teachers[(int)selectedRowIndex];
            var teacherVM = new TeacherVM
            {
                Teacher = teacher,
                SubjectIds = TeacherSubjectRepository.GetSubjectsForTeacher(teacher.Id),
            };
            new DetailedTeacherForm
            (
                teacherVM,
                SubjectsRepository.Subjects,
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
            TeachersRepository.Delete(TeachersRepository.Teachers[(int)selectedRowIndex].Id);
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
            TeachersRepository.Teachers,
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
            var subject = SubjectsRepository.Subjects[(int)selectedRowIndex];
            var subjectVM = new SubjectVM
            {
                Subject = subject,
                TeacherIds = TeacherSubjectRepository.GetTeachersForSubject(subject.Id),
            };
            new DetailedSubjectForm
            (
                subjectVM,
                TeachersRepository.Teachers,
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
            SubjectsRepository.Delete(SubjectsRepository.Subjects[(int)selectedRowIndex].Id);
            UpdateSubjectsGrid();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                FilterIndex = 1,
                RestoreDirectory = true,
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var fullData = new FullDataModel
            {
                Teachers = TeachersRepository.Teachers,
                Subjects = SubjectsRepository.Subjects,
                TeacherSubjects = TeacherSubjectRepository.TeacherSubjects,
            };
            File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(fullData));
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                FilterIndex = 1,
                RestoreDirectory = true,
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var fullData = JsonConvert.DeserializeObject<FullDataModel>(File.ReadAllText(openFileDialog.FileName));
            TeachersRepository.Teachers = fullData.Teachers;
            SubjectsRepository.Subjects = fullData.Subjects;
            TeacherSubjectRepository.TeacherSubjects = fullData.TeacherSubjects;
            UpdateFullView();
        }
    }
}

