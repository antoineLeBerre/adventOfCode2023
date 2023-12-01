using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day1_part2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("C:/Users/antoine.leberre/RiderProjects/adventOfCode_2023/day1_part2/input.txt");
            var number = 0;
            var translation = new Dictionary<string, string>
            {
                {"one", "1"},
                {"two", "2"},
                {"three", "3"},
                {"four", "4"},
                {"five", "5"},
                {"six", "6"},
                {"seven", "7"},
                {"eight", "8"},
                {"nine", "9"}
            };
            foreach (var line in lines)
            {
                var order = new SortedDictionary<int, string>();
                
                Console.WriteLine(line);
                foreach (var keyValuePair in translation.Where(dico => line.Contains(dico.Key)))
                {
                    foreach (var index in Regex.Matches(line, keyValuePair.Key).Cast<Match>().Select(m => m.Index)
                                 .ToList())
                    {
                        order.Add(index, keyValuePair.Value);
                    }

                    
                }
                
                foreach (var keyValuePair in translation.Where(dico => line.Contains(dico.Value)))
                {
                    foreach (var index in Regex.Matches(line, keyValuePair.Value).Cast<Match>().Select(m => m.Index)
                                 .ToList())
                    {
                        order.Add(index, keyValuePair.Value);
                    }
                }
                Console.WriteLine(int.Parse(string.Join("", order.Values).First() + "" + string.Join("", order.Values).Last()));
                number += int.Parse(string.Join("", order.Values).First() + "" + string.Join("", order.Values).Last());
            }
            Console.WriteLine(number);
        }
    }
}