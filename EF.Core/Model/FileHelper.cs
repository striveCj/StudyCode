using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Model
{
    public static class FileHelper
    {
        public static bool Exist(string path)
        {
            return File.Exists(path);
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static bool ExistDirectory(string path)
        {
            return Directory.Exists(path);
        }

        public static void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public static string[] GetFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern);
        }

        public static string GetExtensionName(string path)
        {
            return Path.GetExtension(path);
        }

        public static string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        public static char GetDirectorySeparatorChar()
        {
            return Path.DirectorySeparatorChar;
        }

        public static string GetFileNameWithoutExtension(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }


    }
}
