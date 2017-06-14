namespace BachSoft
{
    using System.Collections.Generic;
    using System.IO;

    public static class IOManager 
    {
        public static void TraverceDirectory(string path)
        {

            // OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            OutputWriter.WriteMessageOnNewLine(path);
            subFolders.Enqueue(SessionData.currentPath);

            while (subFolders.Count !=0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;
                identation++;

                // Print the folder patch

                foreach (string directoryPatch in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPatch);
                    OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string ('-', identation), directoryPatch));
                }
            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + name;
            Directory.CreateDirectory(path);
        }
    }
}
