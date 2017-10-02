using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    [Serializable]
    public class GlassInformationFile: IEnumerable
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public int Sum { get; set; }
        public int Times { get; set; }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
