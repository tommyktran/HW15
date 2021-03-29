using System;
using System.Collections.Generic;

namespace HW15
{
    class Program
    {
        static void Main(string[] args)
        {
            var ShrinkProblem = new ShrinkWords("MITXAFEC");
            ShrinkProblem.Solve();

            Console.WriteLine();

            var ElementProblem = new ElementWords("Canine");
            ElementProblem.Solve();

            Console.WriteLine();

            var DoctorProblem = new DoctorHours(new List<int> { 7, 2, 4, 2 }, new List<int> { 1, 2, 5, 3, 1, 2, 1 });
            DoctorProblem.Solve();

            Console.WriteLine();

            double[,] coords =
            {
                { 11, 10 },
                { 16, 16 },
                { 3, 15 },
                { 6, 17 },
                { 10, 5 },
                { 14, 11 },
                { 5, 19 },
                { 15, 18 },
                { 17, 20 },
                { 18, 22 }
            };
            double d = 6.0;
            var RadioProblem = new RadioTowers(coords, d);
            RadioProblem.Solve();
        }
    }
}
