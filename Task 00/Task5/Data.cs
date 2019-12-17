using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    [Serializable]
    public class Data
    {
        public string Path { get; set; }
        public int TName { get; set; }
        public DateTime DateOfEvent { get; set; }
        public string TypeOfEvent { get; set; }
        //public Data(string path, int name, DateTime date, string tOfEvent)
        //{
        //    Path = path;
        //    TName = name;
        //    DateOfEvent = date;
        //    TypeOfEvent = tOfEvent;
        //}
    }
}

