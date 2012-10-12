using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Utils
{
    static class File
    {
        static void FindInDir(DirectoryInfo dir, string pattern, bool recursive, ref List<string> FileNames)
        {
            foreach (FileInfo file in dir.GetFiles(pattern))
            {
                FileNames.Add(file.FullName);
            }
            if (recursive)
            {
                foreach (DirectoryInfo subdir in dir.GetDirectories())
                {
                    FindInDir(subdir, pattern, recursive, ref FileNames);
                }
            }
        }

        static public List<string> Find(string dir, string pattern, bool recursive)
        {
            List<string> FileNames = new List<string>();
            FindInDir(new DirectoryInfo(dir), pattern, recursive, ref FileNames);
            return FileNames;
        }
    }
}
