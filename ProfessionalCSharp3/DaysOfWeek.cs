using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp3
{
    [Flags]
    public enum DaysOfWeek
    {
        Monday=0x1,
        TuesDay=0x2,
        Wednesday=0x4,
        Thursday=0x8,
        Friday=0x10,
        Saturday=0x20,
        Sunday=0x40,
        Weekday=Saturday|Sunday,
        Workday=0x1f,
        AllWeek=Workday|Weekday
    }
}
