using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    [Serializable]
    public class GlassInformationFile: IEnumerable, IComparable<GlassInformationFile>
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public int Sum { get; set; }
        public int Times { get; set; }
        public double Average { get; set; }

        public int CompareTo(GlassInformationFile glass)
        {
            return -1*(this.Average.CompareTo(glass.Average));
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
