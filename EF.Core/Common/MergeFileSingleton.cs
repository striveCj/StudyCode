using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Common
{
    public class MergeFileSingleton
    {
        private static  object _lock=new object();
        private static MergeFileSingleton instance;
        private List<string> MergeFileList;

        private MergeFileSingleton()
        {
            MergeFileList=new List<string>();
        }

        public static MergeFileSingleton Instance
        {
            get
            {
                if (Instance != null) return instance;
                lock (_lock)
                {
                    if (instance==null)
                    {
                        instance=new MergeFileSingleton();
                    }
                }

                return instance;
            }
        }

        public void AddFile(string BaseFileName)
        {
            MergeFileList.Add(BaseFileName);
        }

        public bool InUse(string BaseFileName)
        {
            return MergeFileList.Contains(BaseFileName);
        }

        public bool RemoveFile(string BaseFileName)
        {
            return MergeFileList.Remove(BaseFileName);
        }
    }
}
