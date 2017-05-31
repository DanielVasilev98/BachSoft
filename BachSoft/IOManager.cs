namespace BachSoft
{
    using System.Collections.Generic;
    using System.IO;

    public static class IOManager 
    {
        public static void TraverceDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = path.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(path);

            while (subFolders.Count !=0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;

                // Print the folder patch

                foreach (string directoryPatch in Directory.GetDirectories(currentPath))
                {
                    OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string ('-', identation), currentPath));
                }
            }
        }
    }
}
