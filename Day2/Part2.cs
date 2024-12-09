using System;
using System.IO;
using System.Collections.Generic;

namespace Day2
{
    public class Part2
    {
        public static void Part2Try()
        {
            try
            {
                Console.WriteLine("Day 2 - Part 2");

                // Use relative path for the input file
                string filePath = @"../../../input2.txt"; // Update path if needed

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Input file not found!");
                    return;
                }

                // Read all lines from the input file
                string[] input = File.ReadAllLines(filePath);

                // Counter for safe rows
                int safeCount = 0;

                foreach (var line in input)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] split = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        int[] levels = Array.ConvertAll(split, int.Parse);

                        // Check if the row is safe
                        if (IsRowSafe(levels) || CanBecomeSafe(levels))
                        {
                            safeCount++;
                        }
                    }
                }

                // Output the number of safe rows
                Console.WriteLine($"Number of safe rows: {safeCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static bool IsRowSafe(int[] levels)
        {
            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int i = 1; i < levels.Length; i++)
            {
                int diff = levels[i] - levels[i - 1];

                // Check if the difference is outside the range [1, 3]
                if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                {
                    return false;
                }

                // Determine if the row is not strictly increasing or strictly decreasing
                if (diff > 0)
                {
                    isDecreasing = false; // Not decreasing
                }
                if (diff < 0)
                {
                    isIncreasing = false; // Not increasing
                }
            }

            // The row is safe if it is strictly increasing or strictly decreasing
            return isIncreasing || isDecreasing;
        }

        private static bool CanBecomeSafe(int[] levels)
        {
            // Attempt to remove one level at a time
            for (int i = 0; i < levels.Length; i++)
            {
                // Create a new list without the current level
                var modifiedLevels = new List<int>(levels);
                modifiedLevels.RemoveAt(i);

                // Check if the modified row is safe
                if (IsRowSafe(modifiedLevels.ToArray()))
                {
                    return true;
                }
            }

            // If no single removal makes the row safe, return false
            return false;
        }
    }
}
// Result: Number of safe rows: 621
