using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace XamarinSQLite
{
    public class ItemList
    {
        [PrimaryKey, AutoIncrement]
        public int ItemID { get; set; }
        public string Item { get; set; }
    }
}
