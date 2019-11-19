using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp10
{
    public class RacerComparer:IComparable<Racer>
    {
        public enum  CompareType
        {
            FirstName,
            LastName,
            Country,
            Wins
        }
        private  CompareType  _compareType;

        public RacerComparer(CompareType compareType)
        {
            _compareType = compareType;
        }

        public int Compare(Racer x, Racer y)
        {
            if (x==null&&y==null)
            {
                return 0;
            }
            if (x==null)
            {
                return -1;
            }
            if (y==null)
            {
                return 1;
            }
            int result;
            switch (_compareType)
            {
                case CompareType.FirstName:
                    return string.Compare(x.FirstName, y.FirstName);
                case CompareType.LastName:
                    return string.Compare(x.LastName, y.LastName);
                case CompareType.Country:
                    result = string.Compare(x.LastName, y.LastName);
                    if (result==0)
                    {
                        return string.Compare(x.LastName, y.LastName);
                    }
                    else
                    {
                        return result;
                    }
                case CompareType.Wins:
                    return x.Wins.CompareTo(y.Wins);
                default:
                    throw new ArgumentException("Invalid Compare Type");
            }
        }

        public int CompareTo(Racer other)
        {
            throw new NotImplementedException();
        }
    }
}
