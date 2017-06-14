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

                foreach (var file in Directory.GetFiles(currentPath))
                {
                    int indexOfLastSlash = file.LastIndexOf("\\");
                    string fileName = file.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                }

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

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "...")
            {
                string currentPath = SessionData.currentPath;
                int indexOfLastSlash = currentPath.LastIndexOf("\\");
                string newPath = currentPath.Substring(0, indexOfLastSlash);
                SessionData.currentPath = newPath;
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);

            }
        }

        private static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
            SessionData.currentPath = absolutePath;
        }
    }
}
