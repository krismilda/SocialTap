using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class TopList
    {
        public List<GlassInformationFile> getTopList()
        {
            List<GlassInformationFile> list = ReadingFromFile.Read();
            list.Sort();
            return list;
        }

    }
}
