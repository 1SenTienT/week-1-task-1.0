using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_1_task_1._0
{
    public class program
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
}
