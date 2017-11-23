using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.HistoryData
{
    public class HistoryInfoSum : IComparable<HistoryInfoSum>
    {
            [JsonProperty("category")]
            public String Category { get; set; }
            [JsonProperty("sumOfMl")]
            public int SumOfMl { get; set; }
            
            public int CompareTo(HistoryInfoSum drinkInfo)
            {
                return -1 * (this.SumOfMl.CompareTo(drinkInfo.SumOfMl));
            }
    }
}
