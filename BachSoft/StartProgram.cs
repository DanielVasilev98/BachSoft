using System.IO;

namespace BachSoft
{
    class StartProgram
    {
        static void Main()
        {

            //IOManager.TraverceDirectory(@"C:\Users\Ivan\Documents\Visual Studio 2017\Projects\CSharp\BachSoft\BachSoft");
            
            // StudentsRepository.InitializeData();
            // StudentsRepository.GetAllStudentsByCource("Unity");

            // Tester.CompareContent(@"C:\Users\Ivan\Desktop\test2.txt", @"C:\Users\Ivan\Desktop\test3.txt");


            IOManager.CreateDirectoryInCurrentFolder("pecho");
            IOManager.TraverceDirectory(Directory.GetCurrentDirectory());
        }
    }
}
