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
            database.CreateTableAsync<UserData>().Wait();
		}

		public Task<List<UserData>> GetItemsAsync()
		{
			return database.Table<UserData>().ToListAsync();
		}

		public Task<List<UserData>> GetItemsNotDoneAsync()
		{
			return database.QueryAsync<UserData>("SELECT * FROM [User] WHERE [Done] = 0");
		}

		public Task<UserData> GetItemAsync(int id)
		{
			return database.Table<UserData>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(UserData item)
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

        public Task<UserData>  LoadUser() {

            return database.Table<UserData>().FirstOrDefaultAsync();
        }




		public Task<int> DeleteItemAsync(UserData item)
		{
			return database.DeleteAsync(item);
		}
    }
}
