using SPZLab7Var1.Models;
using SPZLab7Var1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SPZLab7Var1
{
    public partial class DetailedSubjectForm : Form
    {
        private readonly Subject _subject;
        private readonly List<Teacher> _teacherOptions;
        private readonly Func<SubjectVM, bool> _onSubmit;

        public DetailedSubjectForm(SubjectVM subjectVM, List<Teacher> teacherOptions, Func<SubjectVM, bool> onSubmit)
        {
            InitializeComponent();

            _subject = subjectVM?.Subject ?? new Subject();
            _teacherOptions = teacherOptions;
            _onSubmit = onSubmit;

            teacherOptions.ForEach(teacher => teacherListBox.Items.Add(teacher.Name));

            if (subjectVM != null)
            {
                nameTextBox.Text = subjectVM.Subject.Name;
                facultyTextBox.Text = subjectVM.Subject.Faculty;
                for (var i = 0; i < teacherOptions.Count; i++)
                {
                    teacherListBox.SetSelected(i, subjectVM.TeacherIds.Contains(teacherOptions[i].Id));
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var errors = new List<(string, string)>();
            var name = Validation.AssertValidationPassed("Имя", Validation.SafeGetNonEmptyString(nameTextBox.Text), errors);
            var faculty = Validation.AssertValidationPassed("Факультет", Validation.SafeGetNonEmptyString(facultyTextBox.Text), errors);
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

            var teacherIds = teacherListBox.SelectedIndices.Cast<int>().Select(index => _teacherOptions[index].Id).ToList();

            _subject.Name = name;
            _subject.Faculty = faculty;
            var wasSuccessful = _onSubmit(new SubjectVM
            {
                Subject = _subject,
                TeacherIds = teacherIds,
            });
            if (wasSuccessful)
            {
                Close();
            }
        }
    }
}
