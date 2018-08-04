using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model
{
    /// <summary>
    /// 自定义类约定
    /// </summary>
    public class CustomKeyConvention:Convention
    {
        public CustomKeyConvention()
        {
            Properties().Where(p => p.Name == "Id").Configure(p => p.IsKey());
        }
    }
}
