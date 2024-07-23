//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//class Program
//{
//    static void Main(string[] args)
//    {

//        string filePath = @"C:\Users\sunkara.lavanya\source\repos\CommandLineArgments\CommandLineArgments\bin\Debug\storedvalues.txt";


//        //string arguments = string.Join(" ", args);


//        //File.WriteAllText(filePath, arguments);



//        //string storedArguments = File.ReadAllText(filePath);


//        //Console.WriteLine("Stored Command Line Arguments:");
//        //Console.WriteLine(storedArguments);
//        //string _opererator = "";
//        //for (int i = 0; i < args.Length; i++)
//        //{
//        //    //Console.WriteLine(args[i].ToString());
//        //    if (args[i].ToString().Contains("+"))
//        //        _opererator = "+";
//        //    if (args[i].ToString().Contains("*"))
//        //        _opererator = "*";

//        //}
//        //int total = 0;
//        //long product = 1;

//        //for (int i = 0; i < args.Length; i++)
//        //{
//        //    if (args[i].ToString().Contains("+") || args[i].ToString().Contains("*"))
//        //    {
//        //        continue;

//        //    }
//        //    string s1 = args[i];
//        //    string[] arr_s1 = s1.Split(':');
//        //    int n1 = int.Parse(arr_s1[1]);
//        //    if (_opererator == "+")
//        //    {
//        //        total += n1;
//        //        if (i == args.Length - 1)
//        //        {
//        //            Console.WriteLine(total);
//        //            Console.ReadLine();
//        //        }
//        //    }
//        //    else
//        //    {
//        //        if (_opererator == "*")
//        //        {
//        //            product *= n1;
//        //            if (i == args.Length - 1)
//        //            {
//        //                Console.WriteLine(product);
//        //                Console.ReadLine();
//        //            }
//        //        }

//        //    }


//        //}
//        //if (_opererator == "+")
//        //{

//        //    Console.WriteLine(total);
//        //    File.AppendAllText(filePath,total.ToString());
//        //    Console.ReadLine();
//        //}
//        //else
//        //{
//        //    if (_opererator == "*")
//        //    {

//        //        Console.WriteLine(product);
//        //        File.AppendAllText(filePath, product.ToString());
//        //        Console.ReadLine();
//        //    }
//        //}















//        if (File.Exists(filePath))
//        {
//            string[] lines = File.ReadAllLines(filePath);
//            string line;
//            for (int i = 0; i < lines.Length; i++)
//            {
//                line = lines[i];
//                string[] argus = line.Split(':');


//                string name = argus[0];
//                int total = 0;
//                for (int j = 1; j < argus.Length; j++)
//                {
//                    try
//                    {

//                        int number = int.Parse(argus[j]);
//                        total = total + number;
//                    }
//                    catch (Exception)
//                    {

//                        Console.WriteLine("FilePath which you provided doesn't exist");
//                    }
//                }
//                lines[i] = line + ":Total_" + total;

//            }
//            string[] flines = File.ReadAllLines(filePath);

//            for (int i = 0; i < flines.Length; i++)
//            {


//                if (!(flines[i].Contains(":Total_")))
//                {
//                    File.WriteAllLines(filePath, lines);

//                }
//            }
//        }
//    }
//}








////    Console.WriteLine("Updated lines with totals:");
////    foreach (var updatedLine in lines)
////    {
////        Console.WriteLine(updatedLine);
////    }
////    Console.ReadLine();
////}
////else
////{
////    Console.WriteLine($"File {filePath} does not exist.");
////}








//using System;
//using System.IO;

//class Program
//{
//    static void Main(string[] args)
//    {
//        //if (args.Length == 0)
//        //{
//        //    Console.WriteLine("Please provide the file path as an argument.");
//        //    return;
//        //}

//        string filePath = args[0];

//        if (File.Exists(filePath))
//        {
//            string[] lines = File.ReadAllLines(filePath);

//            foreach (string line in lines)
//            {
//                string[] parts = line.Split(':');
//                string name = parts[0];

//                int total = 0;
//                bool totalExists = false;
//                bool hasError = false;

//                for (int j = 1; j < parts.Length; j++)
//                {
//                    string part = RemoveExtraSpaces(parts[j]);
//                    if (part.StartsWith("Total_"))
//                    {
//                        totalExists = true;
//                        string totalStr = part.Substring(6);
//                        if (IsNumeric(totalStr))
//                        {
//                            total = int.Parse(totalStr);
//                        }
//                        else
//                        {
//                            hasError = true;
//                        }
//                    }
//                    else if (string.IsNullOrEmpty(part) || part == "0" || part == ": :")
//                    {
//                        total += 0;
//                    }
//                    else
//                    {
//                        try
//                        {

//                            if (IsNumeric(part))
//                            {
//                                total += int.Parse(part);
//                            }
//                            else
//                            {
//                                hasError = true;
//                                total += 0;
//                            }
//                        }
//                        catch (FormatException)
//                        {
//                            hasError = true;
//                        }
//                    }
//                }

//                int calculatedTotal = CalculateTotal(parts);
//                string modifiedLine = line;

//                if (!totalExists || total != calculatedTotal)
//                {
//                    modifiedLine = $"{line}:Total_{calculatedTotal}";
//                }

//                if (hasError)
//                {
//                    AppendToFile(Path.Combine(Path.GetDirectoryName(filePath), "errorvalues.txt"), line);
//                }
//                else
//                {
//                    int subjectCount = parts.Length - 1;
//                    string outputPath = Path.Combine(Path.GetDirectoryName(filePath), $"filename_{subjectCount}.txt");
//                    AppendToFile(outputPath, modifiedLine);
//                }
//            }

//            Console.WriteLine("Appended.");
//        }
//        else
//        {
//            Console.WriteLine("File path does not exist.");
//        }

//        Console.ReadLine();
//    }

//    static string RemoveExtraSpaces(string input)
//    {
//        return string.Join("", input.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
//    }

//    static bool IsNumeric(string input)
//    {
//        foreach (char c in input)
//        {
//            if (!char.IsDigit(c))
//            {
//                return false;
//            }
//        }
//        return true;
//    }

//    static int CalculateTotal(string[] parts)
//    {
//        int total = 0;
//        for (int i = 1; i < parts.Length; i++)
//        {
//            string part = RemoveExtraSpaces(parts[i]);
//            if (!part.StartsWith("Total_") && !string.IsNullOrEmpty(part) && part != "0" && part != ": :")
//            {
//                if (IsNumeric(part))
//                {
//                    total += int.Parse(part);
//                }
//                else
//                {
//                    total += 0;
//                }
//            }
//        }
//        return total;
//    }

//    static void AppendToFile(string filePath, string line)
//    {
//        try
//        {
//            File.AppendAllText(filePath, $"{line}\n");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error appending to file {filePath}: {ex.Message}");
//        }
//    }
//}

//code for average
//using System;
//using System.IO;

//class Program
//{
//    static void Main(string[] args)
//    {
//        if (args.Length == 0)
//        {
//            Console.WriteLine("Please provide the file path as an argument.");
//            return;
//        }

//        string filePath = args[0];

//        if (File.Exists(filePath))
//        {
//            string[] lines = File.ReadAllLines(filePath);

//            foreach (string line in lines)
//            {
//                string[] parts = line.Split(':');
//                string name = parts[0];

//                int total = 0;
//                int subjectCount = 0;
//                bool totalExists = false;
//                bool hasError = false;

//                for (int j = 1; j < parts.Length; j++)
//                {
//                    string part = parts[j].Trim();
//                    if (part.StartsWith("Total_"))
//                    {
//                        totalExists = true;
//                        string totalStr = part.Substring(6);
//                        if (IsNumeric(totalStr))
//                        {
//                            total = int.Parse(totalStr);
//                        }
//                        else
//                        {
//                            hasError = true;
//                        }
//                    }
//                    else if (string.IsNullOrEmpty(part) || part == "0" || part == ": :")
//                    {
//                        total += 0;
//                    }
//                    else
//                    {
//                        if (IsNumeric(part))
//                        {
//                            total += int.Parse(part);
//                            subjectCount++;
//                        }
//                        else
//                        {
//                            hasError = true;
//                            total += 0;
//                        }
//                    }
//                }

//                int calculatedTotal = CalculateTotal(parts);
//                string modifiedLine = line;

//                if (!totalExists || total != calculatedTotal)
//                {
//                    double average = (subjectCount > 0) ? (double)calculatedTotal / subjectCount : 0;
//                    modifiedLine = $"{line}:Total_{calculatedTotal} Average_{average}";
//                }

//                if (hasError)
//                {
//                    AppendToFile(Path.Combine(Path.GetDirectoryName(filePath), "errorvalues.txt"), line);
//                }
//                else
//                {
//                    subjectCount = parts.Length - 1;
//                    string outputPath = Path.Combine(Path.GetDirectoryName(filePath), $"filename_{subjectCount}.txt");
//                    AppendToFile(outputPath, modifiedLine);
//                }
//            }

//            Console.WriteLine("Appended.");
//        }
//        else
//        {
//            Console.WriteLine("File path does not exist.");
//        }

//        Console.ReadLine();
//    }

//    static bool IsNumeric(string input)
//    {
//        foreach (char c in input)
//        {
//            if (!char.IsDigit(c))
//            {
//                return false;
//            }
//        }
//        return true;
//    }

//    static int CalculateTotal(string[] parts)
//    {
//        int total = 0;
//        for (int i = 1; i < parts.Length; i++)
//        {
//            string part = parts[i].Trim();
//            if (!part.StartsWith("Total_") && !string.IsNullOrEmpty(part) && part != "0" && part != ": :")
//            {
//                if (IsNumeric(part))
//                {
//                    total += int.Parse(part);
//                }
//                else
//                {
//                    total += 0;
//                }
//            }
//        }
//        return total;
//    }

//    static void AppendToFile(string filePath, string line)
//    {
//        try
//        {
//            File.AppendAllText(filePath, $"{line}\n");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error appending to file {filePath}: {ex.Message}");
//        }
//    }
//}



//using System;
//using System.IO;

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Check if any command line arguments are provided
//        if (args.Length == 0)
//        {
//            Console.WriteLine("Please provide the file path as an argument.");
//            return;
//        }

//        string filePath = args[0]; // Get the file path from the first command line argument

//        // Check if the file exists at the provided path
//        if (File.Exists(filePath))
//        {
//            string[] lines = File.ReadAllLines(filePath); // Read all lines from the file

//            foreach (string line in lines) // Iterate through each line in the file
//            {
//                string[] parts = line.Split(':'); // Split the line by ':' character
//                string name = parts[0]; // The first part is the name

//                int total = 0; // Initialize total
//                bool totalExists = false; // Flag to check if total exists
//                bool hasError = false; // Flag to check if there's an error in the line

//                // Iterate through each part after the name
//                for (int j = 1; j < parts.Length; j++)
//                {
//                    string part = parts[j].Trim(); // Trim any leading/trailing whitespace
//                    if (part.StartsWith("Total_")) // Check if the part is a total
//                    {
//                        totalExists = true;
//                        string totalStr = part.Substring(6); // Get the total value as string
//                        if (IsNumeric(totalStr)) // Check if it's numeric
//                        {
//                            total = int.Parse(totalStr); // Parse the total value
//                        }
//                        else
//                        {
//                            hasError = true; // Mark as error if total is not numeric
//                        }
//                    }
//                    else if (string.IsNullOrEmpty(part) || part == "0" || part == ": :")
//                    {
//                        total += 0; // Treat empty, "0", or ": :" parts as zero
//                    }
//                    else
//                    {
//                        try
//                        {
//                            if (IsNumeric(part)) // Check if the part is numeric
//                            {
//                                total += int.Parse(part); // Parse and add the part value to total
//                            }
//                            else
//                            {
//                                hasError = true; // Mark as error if part is not numeric
//                                total += 0; // Treat non-numeric parts as zero
//                            }
//                        }
//                        catch (FormatException)
//                        {
//                            hasError = true; // Mark as error if parsing fails
//                        }
//                    }
//                }

//                int calculatedTotal = CalculateTotal(parts); // Calculate the total from parts
//                string modifiedLine = line; // Initialize modifiedLine with the original line

//                // Check if total exists and is correct
//                if (!totalExists || total != calculatedTotal)
//                {
//                    modifiedLine = $"{line}:Total_{calculatedTotal}"; // Add or correct the total
//                }

//                if (hasError)
//                {
//                    // Write the line to errorvalues.txt if there's an error
//                    AppendToFile(Path.Combine(Path.GetDirectoryName(filePath), "errorvalues.txt"), line);
//                }
//                else
//                {
//                    int subjectCount = parts.Length - 1; // Number of subjects
//                    string outputPath = Path.Combine(Path.GetDirectoryName(filePath), $"filename_{subjectCount}.txt");
//                    // Write the modified line to the appropriate file based on subject count
//                    AppendToFile(outputPath, modifiedLine);
//                }
//            }

//            Console.WriteLine("Processing complete.");
//        }
//        else
//        {
//            // Display message if the file path does not exist
//            Console.WriteLine("File path does not exist.");
//        }

//        Console.ReadLine(); // Wait for user input before closing the console window
//    }

//    static bool IsNumeric(string input)
//    {
//        // Check if the input string contains only digits
//        foreach (char c in input)
//        {
//            if (!char.IsDigit(c))
//            {
//                return false;
//            }
//        }
//        return true;
//    }

//    static int CalculateTotal(string[] parts)
//    {
//        int total = 0;
//        // Iterate through each part and calculate the total
//        for (int i = 1; i < parts.Length; i++)
//        {
//            string part = parts[i].Trim(); // Trim any leading/trailing whitespace
//            if (!part.StartsWith("Total_") && !string.IsNullOrEmpty(part) && part != "0" && part != ": :")
//            {
//                if (IsNumeric(part)) // Check if the part is numeric
//                {
//                    total += int.Parse(part); // Parse and add the part value to total
//                }
//                else
//                {
//                    total += 0; // Treat non-numeric parts as zero
//                }
//            }
//        }
//        return total;
//    }

//    static void AppendToFile(string filePath, string line)
//    {
//        try
//        {
//            // Append the line to the file
//            File.AppendAllText(filePath, $"{line}\n");
//        }
//        catch (Exception ex)
//        {
//            // Handle any exceptions that occur during file write
//            Console.WriteLine($"Error appending to file {filePath}: {ex.Message}");
//        }
//    }
//}




//program for totalaverage



//program for average of students

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Check if any command line arguments are provided
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the file path as an argument.");
            return;
        }

        string filePath = args[0]; // Get the file path from the first command line argument

        // Check if the file exists at the provided path
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath); // Read all lines from the file
            Dictionary<int, List<int>> subjectTotals = new Dictionary<int, List<int>>();
            Dictionary<int, List<string>> fileLines = new Dictionary<int, List<string>>();

            foreach (string line in lines) // Iterate through each line in the file
            {
                string[] parts = line.Split(':'); // Split the line by ':' character
                string name = parts[0]; // The first part is the name

                int total = 0; // Initialize total
                bool totalExists = false; // Flag to check if total exists
                bool hasError = false; // Flag to check if there's an error in the line

                // Iterate through each part after the name
                for (int j = 1; j < parts.Length; j++)
                {
                    string part = parts[j].Trim(); // Trim any leading/trailing whitespace
                    if (part.StartsWith("Total_")) // Check if the part is a total
                    {
                        totalExists = true;
                        string totalStr = part.Substring(6); // Get the total value as string
                        if (IsNumeric(totalStr)) // Check if it's numeric
                        {
                            total = int.Parse(totalStr); // Parse the total value
                        }
                        else
                        {
                            hasError = true; // Mark as error if total is not numeric
                        }
                    }
                    else if (string.IsNullOrEmpty(part) || part == "0" || part == ": :")
                    {
                        total += 0; // Treat empty, "0", or ": :" parts as zero
                    }
                    else
                    {
                        try
                        {
                            if (IsNumeric(part)) // Check if the part is numeric
                            {
                                total += int.Parse(part); // Parse and add the part value to total
                            }
                            else
                            {
                                hasError = true; // Mark as error if part is not numeric
                                total += 0; // Treat non-numeric parts as zero
                            }
                        }
                        catch (FormatException)
                        {
                            hasError = true; // Mark as error if parsing fails
                        }
                    }
                }

                int calculatedTotal = CalculateTotal(parts); // Calculate the total from parts
                string modifiedLine = line; // Initialize modifiedLine with the original line

                // Check if total exists and is correct
                if (!totalExists || total != calculatedTotal)
                {
                    modifiedLine = $"{line}:Total_{calculatedTotal}"; // Add or correct the total
                }

                int subjectCount = parts.Length - 1; // Number of subjects
                if (!subjectTotals.ContainsKey(subjectCount))
                {
                    subjectTotals[subjectCount] = new List<int>();
                    fileLines[subjectCount] = new List<string>();
                }

                if (!hasError)
                {
                    subjectTotals[subjectCount].Add(calculatedTotal);
                }

                if (hasError)
                {
                    // Write the line to errorvalues.txt if there's an error
                    AppendToFile(Path.Combine(Path.GetDirectoryName(filePath), "errorvalues.txt"), line);
                }
                else
                {
                    string outputPath = Path.Combine(Path.GetDirectoryName(filePath), $"filename_{subjectCount}.txt");
                    // Add the modified line to the list for the appropriate subject count
                    fileLines[subjectCount].Add(modifiedLine);
                }
            }

            foreach (var entry in fileLines)
            {
                int subjectCount = entry.Key;
                List<string> linesToWrite = entry.Value;
                List<int> totals = subjectTotals[subjectCount];

                // Calculate overall average for this subject count
                double overallAverage = (totals.Count > 0) ? (double)totals.Sum() / totals.Count : 0;

                // Append the overall average to each line
                for (int i = 0; i < linesToWrite.Count; i++)
                {
                    linesToWrite[i] = $"{linesToWrite[i]} Average_{overallAverage:F2}";
                }

                // Write the lines to the file
                string outputPath = Path.Combine(Path.GetDirectoryName(filePath), $"filename_{subjectCount}.txt");
                File.WriteAllLines(outputPath, linesToWrite);
            }

            Console.WriteLine("Processing complete.");
        }
        else
        {
            // Display message if the file path does not exist
            Console.WriteLine("File path does not exist.");
        }

        Console.ReadLine(); // Wait for user input before closing the console window
    }

    static bool IsNumeric(string input)
    {
        // Check if the input string contains only digits
        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    static int CalculateTotal(string[] parts)
    {
        int total = 0;
        // Iterate through each part and calculate the total
        for (int i = 1; i < parts.Length; i++)
        {
            string part = parts[i].Trim(); // Trim any leading/trailing whitespace
            if (!part.StartsWith("Total_") && !string.IsNullOrEmpty(part) && part != "0" && part != ": :")
            {
                if (IsNumeric(part)) // Check if the part is numeric
                {
                    total += int.Parse(part); // Parse and add the part value to total
                }
                else
                {
                    total += 0; 
                }
            }
        }
        return total;
    }

    static void AppendToFile(string filePath, string line)
    {
        try
        {
            // Append the line to the file
            File.AppendAllText(filePath, $"{line}\n");
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during file write
            Console.WriteLine($"Error appending to file {filePath}: {ex.Message}");
        }
    }
}
































