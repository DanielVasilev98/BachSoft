namespace BachSoft
{
    using System;
    using System.Collections.Generic;

    public static class StudentsRepository
    {
        // public static string ExceptionsMessages { get; set; }

        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCource;

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
                    studentsByCource[cource].Add(students, new List<int>());
                }

                studentsByCource[cource][students].Add(mark);
                input = Console.ReadLine();
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }


      
        private static bool IsQueryForCourcePossible(string courceName)
        {
            if (isDataInitialized)
            {
                if (studentsByCource.ContainsKey(courceName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }

                return true;
            }
           else
           {
               OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitialisedException);
           }
           return false;
        }

        private static bool IsQueryForStudentsPossible(string courceName, string studentUserName)
        {
            if (IsQueryForCourcePossible(courceName) && studentsByCource[courceName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            return false;
        }

        public static void GetStudentsScoreFromCource(string courceName, string username)
        {
            if (IsQueryForStudentsPossible(courceName, username))
            {
                OutputWriter.PrintStudents(new KeyValuePair<string, List<int>>(username, studentsByCource[courceName][username]));
            }
        }

        public static void GetAllStudentsByCource(string courceName)
        {
            if (IsQueryForCourcePossible(courceName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courceName}");
                foreach (var studentsMarksEntry  in studentsByCource[courceName])
                {
                    OutputWriter.PrintStudents(studentsMarksEntry);
                }   
            }
        }
    }
}
