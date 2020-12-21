using System.Collections.Generic;
using System.Linq;

namespace SPZLab7Var1.Repositories
{
    public class SubjectsRepository
    {
        private static int _latestId = 3;
        public static List<Subject> Subjects = new List<Subject>
        {
            new Subject { Id = 1, Name = "Высшая Математика", Faculty = "Факультет Математики" },
            new Subject { Id = 2, Name = "Физическая Культура", Faculty = "Факультет Физической Культуры" },
            new Subject { Id = 3, Name = "Системное Програмное Обеспечение", Faculty = "Факультет Компьютерной Инженерии" },
        };

        public static Subject Add(Subject newSubject)
        {
            _latestId += 1;
            newSubject.Id = _latestId;
            Subjects.Add(newSubject);
            return newSubject;
        }

        public static void Update(Subject newSubject) =>
            Subjects = Subjects.Select(subject => subject.Id == newSubject.Id ? newSubject : subject).ToList();

        public static void Delete(int id) => Subjects = Subjects.Where(subject => subject.Id != id).ToList();
    }
}

