using System.Collections.Generic;

namespace SPZLab7Var1.Models
{
    public class FullDataModel
    {
        public List<Teacher> Teachers { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<TeacherSubject> TeacherSubjects { get; set; }
    }
}

