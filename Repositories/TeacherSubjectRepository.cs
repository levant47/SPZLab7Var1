using SPZLab7Var1.Models;
using SPZLab7Var1.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SPZLab7Var1.Repositories
{
    public static class TeacherSubjectRepository
    {
        public static List<TeacherSubject> TeacherSubjects = new List<TeacherSubject>();

        public static void AddSubjectsForTeacher(int teacherId, List<int> subjectIds)
        {
            if (!subjectIds.Any())
            {
                return;
            }
            var values = subjectIds.Select(subjectId => $"({teacherId}, {subjectId})").Join(", ");
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            new SqlCommand($"INSERT INTO TeacherSubject (TeacherId, SubjectId) VALUES {values}", sqlConnection)
                .ExecuteNonQuery();
        }

        public static void RemoveAllSubjectsForTeacher(int teacherId)
        {
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            new SqlCommand($"DELETE FROM TeacherSubject WHERE TeacherId = {teacherId}", sqlConnection)
                .ExecuteNonQuery();
        }

        public static void UpdateSubjectsForTeacher(int teacherId, List<int> subjectIds)
        {
            RemoveAllSubjectsForTeacher(teacherId);
            AddSubjectsForTeacher(teacherId, subjectIds);
        }

        public static List<int> GetSubjectsForTeacher(int teacherId)
        {
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlDataReader = new SqlCommand($"SELECT * FROM TeacherSubject WHERE TeacherId = {teacherId}", sqlConnection).ExecuteReader();
                return sqlDataReader.Cast<IDataRecord>()
                    .Select(record => ConvertRecordToTeacherSubject(record).SubjectId)
                    .ToList();
            }
            finally
            {
                sqlDataReader?.Close();
            }
        }

        public static void AddTeachersForSubject(int subjectId, List<int> teacherIds)
        {
            if (!teacherIds.Any())
            {
                return;
            }
            var values = teacherIds.Select(teacherId => $"('{teacherId}', '{subjectId}')").Join(", ");
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            new SqlCommand($"INSERT INTO TeacherSubject (TeacherId, SubjectId) VALUES {values}", sqlConnection)
                .ExecuteNonQuery();
        }

        public static List<int> GetTeachersForSubject(int subjectId)
        {
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlDataReader = new SqlCommand($"SELECT * FROM TeacherSubject WHERE SubjectId = {subjectId}", sqlConnection).ExecuteReader();
                return sqlDataReader.Cast<IDataRecord>()
                    .Select(record => ConvertRecordToTeacherSubject(record).TeacherId)
                    .ToList();
            }
            finally
            {
                sqlDataReader?.Close();
            }
        }

        public static void RemoveTeachersForSubject(int subjectId)
        {
            using var sqlConnection = DatabaseUtility.GetSqlConnection();
            new SqlCommand($"DELETE FROM TeacherSubject WHERE SubjectId = {subjectId}", sqlConnection)
                .ExecuteNonQuery();
        }

        public static void UpdateTeachersForSubject(int subjectId, List<int> teacherIds)
        {
            RemoveTeachersForSubject(subjectId);
            AddTeachersForSubject(subjectId, teacherIds);
        }

        private static TeacherSubject ConvertRecordToTeacherSubject(IDataRecord record)
        {
            var entity = new TeacherSubject();
            foreach (var (propertyInfo, index) in typeof(TeacherSubject).GetProperties().WithIndex())
            {
                var dbValue = record[index];
                propertyInfo.SetValue(entity, dbValue == DBNull.Value ? null : dbValue);
            }
            return entity;
        }
    }
}
