using System;
using System.IO;

namespace VirusSimulator
{
    class Program
    {
        // Define a "virus signature". This is a unique string that our antivirus will look for.
        // In a real scenario, this would be a specific sequence of bytes in the compiled code.
        // Here, we just put it in a text file.
        private const string VirusSignature = "VIROUS-TEST-SIGNATURE-12345";

        static void Main(string[] args)
        {
            Console.WriteLine("=== Virus Simulator ===");
            Console.WriteLine("This program will generate a harmless test file with a specific 'virus' signature.");
            Console.WriteLine($"Signature: {VirusSignature}");
            Console.WriteLine();

            Console.Write("Enter the directory where you want to drop the virus file (default: current directory): ");
            string? inputDir = Console.ReadLine();
            string targetDir = string.IsNullOrWhiteSpace(inputDir) ? Directory.GetCurrentDirectory() : inputDir;

            if (!Directory.Exists(targetDir))
            {
                try
                {
                    Directory.CreateDirectory(targetDir);
                    Console.WriteLine($"Created directory: {targetDir}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating directory: {ex.Message}");
                    return;
                }
            }

            string fileName = "virus_test.txt";
            string filePath = Path.Combine(targetDir, fileName);

            try
            {
                File.WriteAllText(filePath, $"This represents a malicious file content.\n{VirusSignature}\nEnd of virus.");
                Console.WriteLine($"[SUCCESS] Virus file created at: {filePath}");
                Console.WriteLine("Run the AntivirusScanner to detect and remove this file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to write virus file: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
