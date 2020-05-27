using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp16
{
    public class DynamicFileHelper
    {
        private StreamReader OpenFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                return new StreamReader(fileName);
            }
            return null;
        }

        public IEnumerable<dynamic> ParseFile(string fileName)
        {
            string[] headerLine = fileStream.ReadLine().Split(',').Trim().ToArray();
            var retList = new List<dynamic>();
            while (fileStream.Peek()>0)
            {
                string[] dataLine = fileStream.ReadLine().Split(',').Trim().ToArray();
                dynamic dynamicEntity = new ExpandoObject();
                for (int i = 0; i < headerLine.length; i++)
                {
                    ((IDictionary<string, object>)dynamicEntity).Add(headerLine[i],dataLine[i]);
                }
                retList.Add(dynamicEntity);
            }
            return retList;
        }
    }
}
