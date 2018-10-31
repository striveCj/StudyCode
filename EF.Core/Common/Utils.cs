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

            if (!MergeFileSingleton.Instance.InUse(baseFileName))
            {
                MergeFileSingleton.Instance.AddFile(baseFileName);
                if (FileHelper.Exist(baseFileName))
                {
                    FileHelper.Delete(baseFileName);
                }

                var mergeList = new List<SortedFile>();
                foreach (var file in filesList)
                {
                    var sortedFile = new SortedFile
                    {
                        FileName = file
                    };
                    baseFileName = file.Substring(0, file.IndexOf(PARTTOKEN));
                    trailingTokens = file.Substring(file.IndexOf(PARTTOKEN) + PARTTOKEN.Length);
                    int.TryParse(trailingTokens.Substring(0, trailingTokens.IndexOf(".")), out fileIndex);
                    sortedFile.FileOrder = fileIndex;
                    mergeList.Add(sortedFile);
                }

                var mergeOrder = mergeList.OrderBy(s => s.FileOrder).ToList();

                using (var fileStream=new FileStream(baseFileName,FileMode.Create))
                {
                    try
                    {
                        foreach (var chunk in mergeOrder)
                        {
                            PollyHelper.WaitAndRetry<IOException>(() =>
                            {
                                using (var fileChunk=new FileStream(chunk.FileName,FileMode.Open))
                                {
                                    fileChunk.CopyTo(fileStream);
                                }
                            });
                        }
                    }
                    catch (IOException e)
                    {
                        return false;
                        throw e;
                    }
                }

                result = true;

                MergeFileSingleton.Instance.RemoveFile(baseFileName);

                Parallel.ForEach(mergeList, (d) => { FileHelper.Delete(d.FileName); });

            }

            return result;
        }
        
    }
}
