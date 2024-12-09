using System;
using System.IO;
using System.Linq;

namespace Day1
{
    public class Part1
    {
        public static void Part1Try()
        {
            try
            {
                Console.WriteLine("Day 1 - Part 1");
                // Use relative path for the input file
                string filePath = @"../../../input1.txt"; // Update path if needed

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Input file not found!");
                    return;
                }

                // Read all lines from the input file
                string[] input = File.ReadAllLines(filePath);

                // Create separate lists for the left and right numbers
                var leftList = new int[input.Length];
                var rightList = new int[input.Length];

                for (int i = 0; i < input.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(input[i]))
                    {
                        string[] split = input[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                        if (split.Length == 2 &&
                            int.TryParse(split[0], out int a) &&
                            int.TryParse(split[1], out int b))
                        {
                            leftList[i] = a;
                            rightList[i] = b;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid line format: {input[i]}");
                        }
                    }
                }

                // Sort both lists
                Array.Sort(leftList);
                Array.Sort(rightList);

                // Calculate total distance between sorted pairs
                int totalDistance = 0;
                for (int i = 0; i < leftList.Length; i++)
                {
                    totalDistance += Math.Abs(leftList[i] - rightList[i]);
                }

                // Output the total distance
                Console.WriteLine($"Total distance: {totalDistance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

// Result: Total distance: 2196996

