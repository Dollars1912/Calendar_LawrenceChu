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
            database.CreateTableAsync<EventData>().Wait();
		}

		public Task<List<EventData>> GetItemsAsync()
		{
			return database.Table<EventData>().ToListAsync();
		}

		public Task<List<EventData>> GetItemsNotDoneAsync()
		{
			return database.QueryAsync<EventData>("SELECT * FROM [User] WHERE [Done] = 0");
		}

		public Task<EventData> GetItemAsync(int id)
		{
			return database.Table<EventData>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(EventData item)
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

		public Task<int> DeleteItemAsync(EventData item)
		{
			return database.DeleteAsync(item);
		}
    }
}
