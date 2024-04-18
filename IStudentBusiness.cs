using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Model;

namespace Student.Business.Contract
{
    public interface IStudentBusiness
    {
        int GetTotalMarkObtained(int studentId);

        // Method to get the total percentage obtained by a student in all subjects.
        double GetTotalPercentageObtained(int studentId);

        // Method to get all marks of a student by their ID.
        IEnumerable<Marksheet> GetAllMarksById(int studentId);

        // Method to add marks for a student in a subject.
        void AddMarks(Marksheet markSheet);

        // Method to update marks for a student in a subject.
        void UpdateMarks(Marksheet markSheet);

        // Method to get a list of all students with their total marks and percentages.
        IEnumerable<object> GetStudentList();

        // Method to get the top three students who have secured the maximum marks in all subjects.
        IEnumerable<object> GetTopThree(int @class);
    }
}
