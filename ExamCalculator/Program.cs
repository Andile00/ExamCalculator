using System;

namespace ExamEligibilityCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== STUDENT EXAM ELIGIBILITY CALCULATOR ===");
            Console.WriteLine("Enter marks (0-100) for each assessment:\n");
            
            try
            {
                double test1 = GetInput("Test 1 (Weight: 30%): ");
                double test2 = GetInput("Test 2 (Weight: 50%): ");
                double assignment1 = GetInput("Assignment 1 (Weight: 10%): ");
                double project = GetInput("Project (Weight: 10%): ");
                
                double weightedAverage = (test1 * 0.30) + (test2 * 0.50) + (assignment1 * 0.10) + (project * 0.10);
                
                Console.WriteLine("\n" + new string('=', 40));
                Console.WriteLine($"Weighted Average: {weightedAverage:F2}%");
                Console.WriteLine("Required Minimum: 50%");
                Console.WriteLine(new string('=', 40));
                
                string status = weightedAverage >= 50 ? "ELIGIBLE" : "NOT ELIGIBLE";
                Console.WriteLine($"\n*** STUDENT IS {status} TO WRITE THE EXAM ***");
                
                if (weightedAverage < 50)
                    Console.WriteLine($"\nNeed {50 - weightedAverage:F2}% more to qualify.");
                
                // Remove Console.ReadKey() for Docker compatibility
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ReadKey(true);
            }
        }
        
        static double GetInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                
                // Handle empty input
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a number between 0-100.");
                    continue;
                }
                
                if (!double.TryParse(input.Trim(), out double value))
                {
                    Console.WriteLine("Invalid! Enter a number between 0-100.");
                    continue;
                }
                
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Marks must be between 0 and 100. Please try again.");
                    continue;
                }
                
                return value;
            }
        }
    }
}