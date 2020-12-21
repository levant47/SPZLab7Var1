using SPZLab7Var1.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SPZLab7Var1.Repositories
{
    public class SubjectsRepository
    {
        public static List<Subject> GetAll()
        {
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlDataReader = new SqlCommand("SELECT * FROM Subject", sqlConnection).ExecuteReader();
                return sqlDataReader.Cast<IDataRecord>()
                    .Select(ConvertRecordToSubject)
                    .ToList();
            }
            finally
            {
                sqlDataReader?.Close();
            }
        }

        public static Subject Add(Subject newSubject)
        {
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            new SqlCommand($"INSERT INTO Subject (Name, Faculty) VALUES ('{newSubject.Name}', '{newSubject.Faculty}')", sqlConnection)
                .ExecuteNonQuery();
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlDataReader = new SqlCommand("SELECT TOP 1 * FROM Subject ORDER BY 1 DESC", sqlConnection).ExecuteReader();
                return sqlDataReader.Cast<IDataRecord>()
                    .Select(ConvertRecordToSubject)
                    .First();
            }
            finally
            {
                sqlDataReader?.Close();
            }
        }

        public static void Update(Subject newSubject)
        {
        }

        public static void Delete(int id)
        {
        }

        private static Subject ConvertRecordToSubject(IDataRecord record)
        {
            var subject = new Subject();
            foreach (var (propertyInfo, index) in typeof(Subject).GetProperties().WithIndex())
            {
                var dbValue = record[index];
                propertyInfo.SetValue(subject, dbValue == DBNull.Value ? null : dbValue);
            }
            return subject;
        }
    }
}

