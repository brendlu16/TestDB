using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    public class Polozka
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nazev { get; set; }
        public int Cena { get; set; }
        public int TridaID { get; set; }
    }
}
