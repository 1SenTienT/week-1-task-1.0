using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_1_task_1._0
{
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
    }
