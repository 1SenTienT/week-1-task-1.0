using System;
using System.Collections.Generic;

namespace GPA_Calculator
{
    // This class represents a course and stores all details of each course.
    class Course
    {
        public string NameCode;
        public int Unit, GradeUnit, WeightPoint;
        public string Grade, Remark;

        // Constructor to initialize course details when an object of Course is created
        public Course(string nameCode, int unit, string grade, int gradeUnit, int weightPoint, string remark)
        {
            NameCode = nameCode;
            Unit = unit;
            Grade = grade;
            GradeUnit = gradeUnit;
            WeightPoint = weightPoint;
            Remark = remark;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // List to store multiple Course objects, representing each course entered by the user
            List<Course> courses = new List<Course>();

            // Variables to keep track of total units registered, total units passed, and total weight points
            int totalUnitsRegistered = 0;
            int totalUnitsPassed = 0;
            int totalWeightPoints = 0;

            bool addMoreCourses = true;  // Flag to control the loop for adding courses
            while (addMoreCourses)
            {
                // Prompt user for course information and read the input
                Console.Write("Enter Course Name & Code: ");
                string courseNameCode = Console.ReadLine();

                Console.Write("Enter Course Unit: ");
                int courseUnit = int.Parse(Console.ReadLine());

                Console.Write("Enter Course Score: ");
                int courseScore = int.Parse(Console.ReadLine());

                // Determine Grade, Grade Unit, and Remark based on the course score
                string grade;
                int gradeUnit;
                string remark;

                if (courseScore >= 70)
                {
                    grade = "A";
                    gradeUnit = 5;
                    remark = "Excellent";
                }
                else if (courseScore >= 60)
                {
                    grade = "B";
                    gradeUnit = 4;
                    remark = "Very Good";
                }
                else if (courseScore >= 50)
                {
                    grade = "C";
                    gradeUnit = 3;
                    remark = "Good";
                }
                else if (courseScore >= 45)
                {
                    grade = "D";
                    gradeUnit = 2;
                    remark = "Fair";
                }
                else
                {
                    grade = "F";
                    gradeUnit = 0;
                    remark = "Fail";
                }

                // Calculate Weight Point as product of grade unit and course unit
                int weightPoint = gradeUnit * courseUnit;

                // Update the totals for units registered, units passed, and weight points
                totalUnitsRegistered += courseUnit;
                if (gradeUnit > 0) totalUnitsPassed += courseUnit;  // Only passed units count toward total units passed
                totalWeightPoints += weightPoint;

                // Create a new Course object with the course details and add it to the list
                courses.Add(new Course(courseNameCode, courseUnit, grade, gradeUnit, weightPoint, remark));

                // Ask if the user wants to add another course
                Console.Write("Add another course? (y/n): ");
                addMoreCourses = Console.ReadLine().ToLower() == "y";
            }

            // Calculate GPA by dividing total weight points by total units registered
            double GPA = totalUnitsRegistered > 0 ? Math.Round((double)totalWeightPoints / totalUnitsRegistered, 2) : 0;

            // Display the results in tabular form
            Console.WriteLine("|----------------------|--------------|-------|-----------|-----------|-------------|");
            Console.WriteLine("| COURSE & CODE       | COURSE UNIT  | GRADE | GRADE-UNIT| WEIGHT Pt.| REMARK      |");
            Console.WriteLine("|----------------------|--------------|-------|-----------|-----------|-------------|");

            // Loop through each course to display each entry in the table
            foreach (var course in courses)
            {
                Console.WriteLine($"| {course.NameCode,-20} | {course.Unit,-12} | {course.Grade,-5} | {course.GradeUnit,-9} | {course.WeightPoint,-9} | {course.Remark,-11} |");
            }

            Console.WriteLine("|----------------------|--------------|-------|-----------|-----------|-------------|");

            // Display total values and the calculated GPA
            Console.WriteLine($"Total Course Unit Registered: {totalUnitsRegistered}");
            Console.WriteLine($"Total Course Unit Passed: {totalUnitsPassed}");
            Console.WriteLine($"Total Weight Point: {totalWeightPoints}");
            Console.WriteLine($"Your GPA is: {GPA:F2}");
        }
    }
}
