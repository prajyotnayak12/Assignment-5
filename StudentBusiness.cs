using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Business.Contract;
using Student.Model;

namespace Student.Business.Business
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly List<Model.Student> _students;
        private readonly List<Marksheet> _markSheets;

        public StudentBusiness()
        {

            _students = new List<Model.Student>
            {
                new Model.Student { StudentId = 1, StudentName = "Rakesh", StudentJoinDate = new DateTime(2024, 1, 1) },
                new Model.Student { StudentId = 2, StudentName = "Manash", StudentJoinDate = new DateTime(2024, 2, 1) },
                new Model.Student { StudentId = 3, StudentName = "Ashutosh", StudentJoinDate = new DateTime(2024, 2, 1) },
                new Model.Student { StudentId = 4, StudentName = "Salony", StudentJoinDate = new DateTime(2024, 2, 1) },
                new Model.Student { StudentId = 5, StudentName = "Rajat", StudentJoinDate = new DateTime(2024, 2, 1) },

            };

            _markSheets = new List<Marksheet>
            {
                new Marksheet { MarkSheetId = 1, StudentId = 1, Subject = "Math", TotalMark = 100, MarksObtained = 90 },
                new Marksheet { MarkSheetId = 2, StudentId = 1, Subject = "Science", TotalMark = 100, MarksObtained = 85 },
                

                new Marksheet { MarkSheetId = 3, StudentId = 2, Subject = "Math", TotalMark = 100, MarksObtained = 91 },
                new Marksheet { MarkSheetId = 4, StudentId = 2, Subject = "Science", TotalMark = 100, MarksObtained = 86 },
               

                new Marksheet { MarkSheetId = 5, StudentId = 3, Subject = "Math", TotalMark = 100, MarksObtained = 92 },
                new Marksheet { MarkSheetId = 6, StudentId = 3, Subject = "Science", TotalMark = 100, MarksObtained = 81 },
               

                new Marksheet { MarkSheetId = 7, StudentId = 4, Subject = "Math", TotalMark = 100, MarksObtained = 93 },
                new Marksheet { MarkSheetId = 8, StudentId = 4, Subject = "Science", TotalMark = 100, MarksObtained = 87 },
                

                new Marksheet { MarkSheetId = 9, StudentId = 5, Subject = "Math", TotalMark = 100, MarksObtained = 94 },
                new Marksheet { MarkSheetId = 10, StudentId = 5, Subject = "Science", TotalMark = 100, MarksObtained = 89 },
             
               
            };
        }

        public int GetTotalMarkObtained(int studentId)
        {
            return _markSheets.Where(m => m.StudentId == studentId).Sum(m => m.MarksObtained);
        }

        public double GetTotalPercentageObtained(int studentId)
        {
            int totalMarks = _markSheets.Where(m => m.StudentId == studentId).Sum(m => m.TotalMark);
            int totalObtainedMarks = GetTotalMarkObtained(studentId);
            return (double)totalObtainedMarks / totalMarks * 100;
        }

        public IEnumerable<Marksheet> GetAllMarksById(int studentId)
        {
            return _markSheets.Where(m => m.StudentId == studentId);
        }

        public void AddMarks(Marksheet markSheet)
        {
            _markSheets.Add(markSheet);
        }

        public void UpdateMarks(Marksheet markSheet)
        {
            var existingMarkSheet = _markSheets.FirstOrDefault(m => m.MarkSheetId == markSheet.MarkSheetId);
            if (existingMarkSheet != null)
            {
                existingMarkSheet.Subject = markSheet.Subject;
                existingMarkSheet.TotalMark = markSheet.TotalMark;
                existingMarkSheet.MarksObtained = markSheet.MarksObtained;
            }
        }

        public IEnumerable<object> GetStudentList()
        {
            var studentList = from student in _students
                              let totalMark = GetTotalMarkObtained(student.StudentId)
                              let totalPercentage = GetTotalPercentageObtained(student.StudentId)
                              select new
                              {
                                  student.StudentId,
                                  student.StudentName,
                                  TotalMark = totalMark,
                                  TotalPercentage = totalPercentage
                              };
            return studentList;
        }

        public IEnumerable<object> GetTopThree()
        {
            var topThree = (from markSheet in _markSheets
                            group markSheet by markSheet.StudentId into grouped
                            let totalMarks = grouped.Sum(m => m.MarksObtained)
                            orderby totalMarks descending
                            select new
                            {
                                StudentId = grouped.Key,
                                TotalMarks = totalMarks
                            }).Take(3);
            return topThree;
        }

        public IEnumerable<object> GetTopThree(int @class)
        {
            throw new NotImplementedException();
        }
    }
}
