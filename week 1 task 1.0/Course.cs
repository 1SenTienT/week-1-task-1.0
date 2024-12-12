using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_1_task_1._0
{
    public class Course
    {
        public string CourseNameCode { get; set; }
        public int CourseUnit { get; set; }
        public string Grade { get; set; }
        public int GradeUnit { get; set; }
        public int WeightPoint { get; set; }
        public string Remark { get; set; }

        public Course(string courseNameCode, int courseUnit, string grade, int gradeUnit, int weightPoint, string remark)
        {
            CourseNameCode = courseNameCode;
            CourseUnit = courseUnit;
            Grade = grade;
            GradeUnit = gradeUnit;
            WeightPoint = weightPoint;
            Remark = remark;
        }
    }
}
