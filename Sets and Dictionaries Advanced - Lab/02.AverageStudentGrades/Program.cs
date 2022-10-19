using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gradesByStudents = new Dictionary<string, List<decimal>>();

            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (!gradesByStudents.ContainsKey(name))
                {
                    gradesByStudents.Add(name, new List<decimal>());
                }

                gradesByStudents[name].Add(grade);
            }

            foreach (var gradesByStudent in gradesByStudents)
            {
                Console.WriteLine($"{gradesByStudent.Key} -> {string.Join(" ", gradesByStudent.Value)} (avg: {gradesByStudent.Value.Average():f2})");
            }
        }
    }
}
