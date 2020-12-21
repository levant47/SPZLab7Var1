using System.Collections.Generic;
using System.Linq;

namespace SPZLab7Var1.Repositories
{
    public static class TeachersRepository
    {
        private static int _latestId = 3;
        public static List<Teacher> Teachers = new List<Teacher>
        {
            new Teacher { Id = 1, Name = "Иван Иванов", Age = 20 },
            new Teacher { Id = 2, Name = "Петр Петров", Age = 30 },
            new Teacher { Id = 3, Name = "Василий Василев", Age = 40 },
        };

        public static Teacher Add(Teacher newTeacher)
        {
            _latestId += 1;
            newTeacher.Id = _latestId;
            Teachers.Add(newTeacher);
            return newTeacher;
        }

        public static void Update(Teacher newTeacher) =>
            Teachers = Teachers.Select(teacher => teacher.Id == newTeacher.Id ? newTeacher : teacher).ToList();

        public static void Delete(int id) => Teachers = Teachers.Where(teacher => teacher.Id != id).ToList();
    }
}

