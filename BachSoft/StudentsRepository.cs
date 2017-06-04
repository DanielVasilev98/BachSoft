namespace BachSoft
{
    using System;
    using System.Collections.Generic;

   public static class StudentsRepository
   {
       public static bool isDataInitialized = false;
       private static Dictionary<string, Dictionary<string, List<int>>> studentsByCource;

       private static void ReadData()
       {
           string input = Console.ReadLine();

           while (!string.IsNullOrEmpty(input))
           {
               string[] tokens = input.Split(' ');
               string cource = tokens[0];
               string students = tokens[1];
                int mark = int.Parse(tokens[2]);

               if (!studentsByCource.ContainsKey(cource))
               {
                   studentsByCource.Add(cource, new Dictionary<string, List<int>>());
               }

               if (!studentsByCource[cource].ContainsKey(students))
               {
                   studentsByCource[cource].Add(students,new List<int>());
               }

               studentsByCource[cource][students].Add(mark);
               input = Console.ReadLine();
           }

           isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
       }

       public static void InitializeData()
       {
           if (!isDataInitialized)
           {
               OutputWriter.WriteMessageOnNewLine("Reading data...");
               studentsByCource = new Dictionary<string, Dictionary<string, List<int>>>();
               ReadData();
           }
           else
           {
               OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitialisedException);
           }
       }

   }
}
