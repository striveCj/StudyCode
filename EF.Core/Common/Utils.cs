using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Core.Helper;

namespace EF.Core.Common
{
    public class Utils
    {
        private const string PARTTOKEN = ".part_";
        public string FileName { get; set; }

        public List<string> FileParts { get; set; }
        public Utils()
        {
            FileParts=new List<string>();
        }

        public bool MergeFile(string fileName, out bool result, out string storeFileName)
        {
            result = false;
            storeFileName = string.Empty;
            var fileNamePartToken = fileName.IndexOf(PARTTOKEN);
            var baseFileName = fileName.Substring(0, fileNamePartToken);
            var trailingTokens = fileName.Substring(fileNamePartToken + PARTTOKEN.Length);
            var fileIndex = 0;
            var fileCount = 0;
            int.TryParse(trailingTokens.Substring(0, trailingTokens.IndexOf(".")), out fileIndex);
            int.TryParse(trailingTokens.Substring(0, trailingTokens.IndexOf(".")), out fileCount);

            var searchPattern = Path.GetFileName(baseFileName) + PARTTOKEN + "*";
            var filesList = FileHelper.GetFiles(Path.GetDirectoryName(fileName), searchPattern);

            if (filesList.Count()==fileCount)
            {
                var extensionName = FileHelper.GetExtensionName(baseFileName);
                storeFileName = FileHelper.GetFileNameWithoutExtension(baseFileName) + extensionName;
            }
        }
    }
}
