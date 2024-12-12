using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_1_task_1._0
{
    public class PrintTable
    {
        public void Print(List<Course> courses, int totalUnitsRegistered, int totalUnitsPassed, int totalWeightPoints, double GPA)
        {
            // Print table headers
            Console.WriteLine("|----------------------|--------------|-------|-----------|-----------|-------------|");
            Console.WriteLine("| COURSE & CODE       | COURSE UNIT  | GRADE | GRADE-UNIT| WEIGHT Pt.| REMARK      |");
            Console.WriteLine("|----------------------|--------------|-------|-----------|-----------|-------------|");

            // Print each course entry
            foreach (var course in courses)
            {
                Console.WriteLine($"| {course.CourseNameCode,-20} | {course.CourseUnit,-12} | {course.Grade,-5} | {course.GradeUnit,-9} | {course.WeightPoint,-9} | {course.Remark,-11} |");
            }

            // Print footer and GPA details
            Console.WriteLine("|----------------------|--------------|-------|-----------|-----------|-------------|");
            Console.WriteLine($"Total Course Unit Registered: {totalUnitsRegistered}");
            Console.WriteLine($"Total Course Unit Passed: {totalUnitsPassed}");
            Console.WriteLine($"Total Weight Point: {totalWeightPoints}");
            Console.WriteLine($"Your GPA is: {GPA:F2}");
        }
    }
}
