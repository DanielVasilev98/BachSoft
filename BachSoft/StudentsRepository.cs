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
