using SPZLab7Var1.Models;
using System.Collections.Generic;
using System.Linq;

namespace SPZLab7Var1.Repositories
{
    public static class TeacherSubjectRepository
    {
        public static List<TeacherSubject> TeacherSubjects = new List<TeacherSubject>();

        public static void AddSubjectsForTeacher(int teacherId, List<int> subjectIds) =>
            TeacherSubjects.AddRange(subjectIds.Select(subjectId => new TeacherSubject { SubjectId = subjectId, TeacherId = teacherId }));

        public static void RemoveAllSubjectsForTeacher(int teacherId) =>
            TeacherSubjects = TeacherSubjects.Where(teacherSubject => teacherSubject.TeacherId != teacherId).ToList();

        public static void UpdateSubjectsForTeacher(int teacherId, List<int> subjectIds)
        {
            RemoveAllSubjectsForTeacher(teacherId);
            AddSubjectsForTeacher(teacherId, subjectIds);
        }

        public static List<int> GetSubjectsForTeacher(int teacherId) => TeacherSubjects
            .Where(teacherSubject => teacherSubject.TeacherId == teacherId)
            .Select(teacherSubject => teacherSubject.SubjectId)
            .ToList();

        public static void AddTeachersForSubject(int subjectId, List<int> teacherIds) =>
            TeacherSubjects.AddRange(teacherIds.Select(teacherId => new TeacherSubject { TeacherId = teacherId, SubjectId = subjectId }));

        public static List<int> GetTeachersForSubject(int subjectId) => TeacherSubjects
            .Where(teacherSubject => teacherSubject.SubjectId == subjectId)
            .Select(teacherSubject => teacherSubject.TeacherId)
            .ToList();

        public static void RemoveTeachersForSubject(int subjectId) =>
            TeacherSubjects = TeacherSubjects.Where(teacherSubject => teacherSubject.SubjectId != subjectId).ToList();

        public static void UpdateTeachersForSubject(int subjectId, List<int> teacherIds)
        {
            RemoveTeachersForSubject(subjectId);
            AddTeachersForSubject(subjectId, teacherIds);
        }
    }
}
