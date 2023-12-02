using System;
using System.Collections.Generic;
using System.IO;

namespace day2_part2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //var lines = File.ReadAllLines("C:/Users/antoine.leberre/RiderProjects/adventOfCode_2023/day2_part1/input_exemple.txt");
            var lines = File.ReadAllLines("/Users/antoineleberre/dvp/C#/adventOfCode2023/day2_part2/input.txt");
            var sum = 0;

            foreach (var line in lines)
            {
                var nbPerCubeColor = new Dictionary<string, int>();
                var split = line.Replace(';', ',').Split(':');
                var getGame = int.Parse(split[0].Split(' ')[1]);
                var splitCube = split[1].Split(',');
                
                foreach (var s in splitCube)
                {
                    var color = s.Trim().Split(' ');
                    if (nbPerCubeColor.ContainsKey(color[1]))
                    {
                        if (nbPerCubeColor[color[1]] < int.Parse(color[0]))
                        {
                            nbPerCubeColor[color[1]] = int.Parse(color[0]);
                        }
                    }
                    else
                    {
                        nbPerCubeColor.Add(color[1], int.Parse(color[0]));
                    }
                }

                Console.WriteLine("Game {0}", getGame);
                foreach (var keyValuePair in nbPerCubeColor)
                {
                    Console.WriteLine("Color = {0}, value = {1}", keyValuePair.Key, keyValuePair.Value);
                }


                sum += nbPerCubeColor["red"] * nbPerCubeColor["green"] * nbPerCubeColor["blue"];
            }
            
            Console.WriteLine(sum);
        }
    }
}