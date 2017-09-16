using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calendar_LawrenceChu.Models
{
    public class DataBase
    {
        private static DataBase instance;

        public static DataBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Mydb.db3"));
                }
                return instance;
            }
        }

        private readonly SQLiteAsyncConnection database;

        public DataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<Event>().Wait();
		}

		public Task<List<Event>> GetItemsAsync()
		{
			return database.Table<Event>().ToListAsync();
		}

		public Task<List<Event>> GetItemsNotDoneAsync()
		{
			return database.QueryAsync<Event>("SELECT * FROM [User] WHERE [Done] = 0");
		}

		public Task<Event> GetItemAsync(int id)
		{
			return database.Table<Event>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(Event item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else
			{
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(Event item)
		{
			return database.DeleteAsync(item);
		}
    }
}
