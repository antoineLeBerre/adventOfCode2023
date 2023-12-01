using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day1_part1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("C:/Users/antoine.leberre/RiderProjects/adventOfCode_2023/day1_part1/input.txt");
            var result = lines.Select(line => Regex.Replace(line, "[a-zA-Z]", "")).Select(number => int.Parse(number.First() + "" + number.Last())).Sum();

            Console.WriteLine(result);
        }
    }
}