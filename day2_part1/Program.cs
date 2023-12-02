using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace day2_part1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //var lines = File.ReadAllLines("C:/Users/antoine.leberre/RiderProjects/adventOfCode_2023/day2_part1/input_exemple.txt");
            var lines = File.ReadAllLines("/Users/antoineleberre/dvp/C#/adventOfCode2023/day2_part1/input.txt");
            //var games = new Dictionary<int, Dictionary<string, int>>();
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
                    //if ((color[1].Contains("red") && int.Parse(color[0]) > 12) || (color[1].Contains("red") && int.Parse(color[0]) > 12))
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
                

                sum += (nbPerCubeColor["red"] <= 12 && nbPerCubeColor["green"] <= 13 && nbPerCubeColor["blue"] <= 14)
                    ? getGame
                    : 0;
            }
            
            Console.WriteLine(sum);
        }
    }
}