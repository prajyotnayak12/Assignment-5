using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model
{
    public class Marksheet
    {
        public int MarkSheetId { get; set; }
        public int StudentId { get; set; }
        public string Subject { get; set; }
        public int TotalMark { get; set; }
        public int MarksObtained { get; set; }

    }
}
