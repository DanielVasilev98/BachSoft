namespace BachSoft
{
    class Program
    {
        static void Main()
        {

            // IOManager.TraverceDirectory(@"C:\Users\Ivan\Documents\Visual Studio 2017\Projects\CSharp\BachSoft\BachSoft");

            StudentsRepository.InitializeData();
            StudentsRepository.GetAllStudentsByCource("Unity");

        }
    }
}
