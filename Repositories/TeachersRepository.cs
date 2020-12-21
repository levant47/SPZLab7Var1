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
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            new SqlCommand($"INSERT INTO Teacher (Name, Age) VALUES ('{newTeacher.Name}', {newTeacher.Age})", sqlConnection)
                .ExecuteNonQuery();
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlDataReader = new SqlCommand("SELECT TOP 1 * FROM Teacher ORDER BY 1 DESC", sqlConnection).ExecuteReader();
                return sqlDataReader.Cast<IDataRecord>()
                    .Select(ConvertRecordToTeacher)
                    .First();
            }
            finally
            {
                sqlDataReader?.Close();
            }
        }

        public static void Update(Teacher newTeacher)
        {
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            new SqlCommand($"UPDATE Teacher SET Name = '{newTeacher.Name}', Age = {newTeacher.Age} WHERE Id = {newTeacher.Id}", sqlConnection)
                .ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            new SqlCommand($"DELETE FROM Teacher WHERE Id = {id}", sqlConnection).ExecuteNonQuery();
        }

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

