using System;
using System.Collections.Generic;

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

public class Calculation
{
    public List<Course> ExecuteGPAComputation(out int totalUnitsRegistered, out int totalUnitsPassed, out int totalWeightPoints, out double GPA)
    {
        // Initialize output parameters
        totalUnitsRegistered = 0;
        totalUnitsPassed = 0;
        totalWeightPoints = 0;

        // List to store multiple Course objects
        List<Course> courses = new List<Course>();

        bool addMoreCourses = true;  // Flag to control the loop for adding courses
        while (addMoreCourses)
        {
            // Prompt user for course information
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

            // Update the totals
            totalUnitsRegistered += courseUnit;
            if (gradeUnit > 0) totalUnitsPassed += courseUnit;
            totalWeightPoints += weightPoint;

            // Create a new Course object and add it to the list
            courses.Add(new Course(courseNameCode, courseUnit, grade, gradeUnit, weightPoint, remark));

            // Ask if the user wants to add another course
            Console.Write("Add another course? (y/n): ");
            addMoreCourses = Console.ReadLine().ToLower() == "y";
        }

        // Calculate GPA
        GPA = totalUnitsRegistered > 0 ? Math.Round((double)totalWeightPoints / totalUnitsRegistered, 2) : 0;

        return courses; // Return the list of courses
    }
}

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

public class Program
{
    public static void Main(string[] args)
    {
        // Instantiate the Program class and execute the GPA computation
        Calculation calculation = new Calculation();

        // Capture output from GPA computation
        int totalUnitsRegistered, totalUnitsPassed, totalWeightPoints;
        double GPA;
        List<Course> courses = calculation.ExecuteGPAComputation(out totalUnitsRegistered, out totalUnitsPassed, out totalWeightPoints, out GPA);

        // Instantiate the PrintTable class and print the results
        PrintTable printTable = new PrintTable();
        printTable.Print(courses, totalUnitsRegistered, totalUnitsPassed, totalWeightPoints, GPA);
    }
}
