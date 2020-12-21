using SPZLab7Var1.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public static List<Teacher> GetAll()
        {
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlDataReader = new SqlCommand("SELECT * FROM Teacher", sqlConnection).ExecuteReader();
                return sqlDataReader.Cast<IDataRecord>()
                    .Select(ConvertRecordToTeacher)
                    .ToList();
            }
            finally
            {
                sqlDataReader?.Close();
            }
        }

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

        private static Teacher ConvertRecordToTeacher(IDataRecord record)
        {
            var teacher = new Teacher();
            foreach (var (propertyInfo, index) in typeof(Teacher).GetProperties().WithIndex())
            {
                var dbValue = record[index];
                propertyInfo.SetValue(teacher, dbValue == DBNull.Value ? null : dbValue);
            }
            return teacher;
        }
    }
}

