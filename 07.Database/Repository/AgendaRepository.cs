namespace Database.Repository
{

    using Dapper;
    using Database.Model;
    using Microsoft.Data.Sqlite;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class AgendaRepository
    {

        private readonly string databaseName = String.Empty;
        private IDbConnection connection = null;

        public AgendaRepository(string database)
        {
            this.databaseName = database;

            this.connection = new SqliteConnection("" + new SqliteConnectionStringBuilder
            {
                DataSource = this.databaseName
            });

            this.connection.Open();

            // Bootstrap database
            var response = CreateDatabase();
        }

        private bool CreateDatabase()
        {
            try
            {
                var sql = "CREATE TABLE if not exists MyFriends (Id integer primary key, Name varchar(50) not null, PhoneNumber varchar(16) null, CreatedAt datetime default current_timestamp, ModifiedAt datetime null)";
                var command = new SqliteCommand(sql, this.connection as SqliteConnection);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<MyFriend> GetAll()
        {
            try
            {
                string sql = "SELECT Id, Name, PhoneNumber, CreatedAt, ModifiedAt FROM MyFriends";
                return this.connection.Query<MyFriend>(sql).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public MyFriend GetBy(int id)
        {
            try
            {
                string sql = "SELECT Id, Name, PhoneNumber, CreatedAt, ModifiedAt FROM MyFriends WHERE Id = @Id";
                return this.connection.Query<MyFriend>(sql, new { Id = id }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Create(MyFriend myFriend)
        {
            try
            {
                string sql = "INSERT INTO MyFriends (Name, PhoneNumber) VALUES (@Name, @PhoneNumber)";
                this.connection.Execute(sql, myFriend);            

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Modify(MyFriend myFriend)
        {
            try
            {
                string sql = "UPDATE MyFriends SET PhoneNumber = @PhoneNumber, ModifiedAt = @ModifiedAt WHERE Id = @Id";
                this.connection.Execute(sql, myFriend);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteBy(int id)
        {
            try
            {
                string sql = "DELETE FROM MyFriends WHERE Id = @Id";
                this.connection.Execute(sql, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

}