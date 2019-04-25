using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace XamarinSQLite
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<ItemList>().Wait();
        }

        //Insert and Update new record
        public Task<int> SaveItemAsync(ItemList itemList)
        {
            if (itemList.ItemID != 0)
            {
                return db.UpdateAsync(itemList);
            }
            else
            {
                return db.InsertAsync(itemList);
            }
        }

        //Delete
        public Task<int> DeleteItemAsync(ItemList itemList)
        {
            return db.DeleteAsync(itemList);
        }

        //Read All Items
        public Task<List<ItemList>> GetItemsAsync()
        {
            return db.Table<ItemList>().ToListAsync();
        }

       
        //Read Item
        public Task<ItemList> GetItemAsync(int itemId)
        {
            return db.Table<ItemList>().Where(i => i.ItemID == itemId).FirstOrDefaultAsync();
        }
    }
}
