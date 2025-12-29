using System;
using System.IO;

namespace AntivirusScanner
{
    class Program
    {
        // The signature we are looking for (must match the one in VirusSimulator)
        private const string VirusSignature = "VIROUS-TEST-SIGNATURE-12345";

        static void Main(string[] args)
        {
            Console.WriteLine("=== Antivirus Scanner ===");
            Console.WriteLine($"Scanning for signature: {VirusSignature}");
            Console.WriteLine();

            Console.Write("Enter the directory to scan (default: current directory): ");
            string? inputDir = Console.ReadLine();
            string searchDir = string.IsNullOrWhiteSpace(inputDir) ? Directory.GetCurrentDirectory() : inputDir;

            if (!Directory.Exists(searchDir))
            {
                Console.WriteLine($"[ERROR] Directory not found: {searchDir}");
                return;
            }

            Console.WriteLine($"Scanning {searchDir}...");
            int filesScanned = 0;
            int virusesFound = 0;

            try
            {
                // Recursive scan for all files
                string[] files = Directory.GetFiles(searchDir, "*.*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    filesScanned++;
                    try
                    {
                        string content = File.ReadAllText(file);
                        if (content.Contains(VirusSignature))
                        {
                            virusesFound++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[ALERT] Virus detected in: {file}");
                            Console.ResetColor();

                            // Action: Quarantine/Delete
                            // For simplicity, we'll just delete it after asking or just tell user.
                            // Let's safe delete.
                            
                            try
                            {
                                File.Delete(file);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"[ACTION] File deleted successfully.");
                                Console.ResetColor();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"[ERROR] Could not delete file: {ex.Message}");
                            }
                        }
                    }
                    catch (IOException)
                    {
                        // File might be in use, skip
                        Console.WriteLine($"[WARN] Could not read file: {file}");
                    }
                    catch (UnauthorizedAccessException)
                    {
                         // No permission, skip
                         Console.WriteLine($"[WARN] Access denied: {file}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Critical scanning error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("=== Scan Complete ===");
            Console.WriteLine($"Files Scanned: {filesScanned}");
            Console.WriteLine($"Viruses Detection: {virusesFound}");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
