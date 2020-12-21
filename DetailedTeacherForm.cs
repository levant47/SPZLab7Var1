using SPZLab7Var1.Models;
using SPZLab7Var1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SPZLab7Var1
{
    public partial class DetailedTeacherForm : Form
    {
        private readonly Func<TeacherVM, bool> _onSubmit;
        private readonly List<Subject> _subjectOptions;
        private readonly Teacher _teacher;

        public DetailedTeacherForm(TeacherVM teacherVM, List<Subject> subjectOptions, Func<TeacherVM, bool> onSubmit)
        {
            InitializeComponent();

            _teacher = teacherVM?.Teacher ?? new Teacher();
            _subjectOptions = subjectOptions;
            _onSubmit = onSubmit;

            subjectOptions.ForEach(subject => subjectListBox.Items.Add(subject.Name));

            if (teacherVM != null)
            {
                nameTextBox.Text = teacherVM.Teacher.Name;
                ageTextBox.Text = teacherVM.Teacher.Age.ToString();
                for (var i = 0; i < subjectOptions.Count; i++)
                {
                    subjectListBox.SetSelected(i, teacherVM.SubjectIds.Contains(subjectOptions[i].Id));
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var errors = new List<(string, string)>();
            var name = Validation.AssertValidationPassed("Название", Validation.SafeGetNonEmptyString(nameTextBox.Text), errors);
            var age = Validation.AssertValidationPassed("Возраст", Validation.SafeGetPositiveInteger(ageTextBox.Text), errors);
            if (errors.Any())
            {
                var completeErrorMessage = errors.Aggregate("", (result, fieldErrorPair) =>
                {
                    var (field, error) = fieldErrorPair;
                    return result + field + ": " + error + "\n";
                });
                MessageBox.Show(completeErrorMessage);
                return;
            }

            var subjectIds = subjectListBox.SelectedIndices.Cast<int>().Select(index => _subjectOptions[index].Id).ToList();

            _teacher.Name = name;
            _teacher.Age = (int)age;
            var wasSuccessful = _onSubmit(new TeacherVM
            {
                Teacher = _teacher,
                SubjectIds = subjectIds,
            });
            if (wasSuccessful)
            {
                Close();
            }
        }
    }
}
