using System;
using System.IO;
using System.Linq;

namespace Day1
{
    public class Part2
    {
        public static void Part2Try()
        {
            try
            {
                Console.WriteLine("Day 1 - Part 2");

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

                // Calculate total simularities between left and right arrays
                int similarityCount = 0;
                int totalSimilarityCount = 0;
                for (int i = 0; i < leftList.Length; i++)
                {
                    for(int j = 0; j < rightList.Length; j++)
                    {
                        if(leftList[i] == rightList[j])
                        {
                            similarityCount += 1;
                        }

                        totalSimilarityCount += leftList[i] * similarityCount;
                        similarityCount = 0;
                    }
                }

                // Output the total distance
                Console.WriteLine($"Total Similarity: {totalSimilarityCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
// Result: Total Similarity: 23655822
