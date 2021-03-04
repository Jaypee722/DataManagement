using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class QueryProcessor
    {
        public static int CreateUsers(int user_ID, string userName, string firstName,
            string lastName, string middleName, string emailAddress, string userPassword)
        {
            UsersModel data = new UsersModel
            {
                User_ID = user_ID,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                EmailAddress = emailAddress,
                UserPassword = userPassword
            };

            string sql = @"insert into dbo.UserInfo (User_ID, UserName, FirstName, LastName, MiddleName, EmailAddress, UserPassword) values (@User_ID, @UserName, @FirstName, @LastName, @MiddleName, @EmailAddress, @UserPassword);";

            return SqlDataAccess.SaveData(sql, data);
        }


        public static int EditAccount(int user_ID, string userName, string firstName, string lastName, string middleName, string emailAddress, string userPassword)
        {
            int updateid = Variables.UID;
            UsersModel data = new UsersModel
            {
                User_ID = user_ID,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                EmailAddress = emailAddress,
                UserPassword = userPassword
            };

            string sql = @"update dbo.UserInfo set User_ID = @User_ID, UserName = @UserName, FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, EmailAddress = @EmailAddress, UserPassword = @UserPassword where Id =" + updateid.ToString() + ";";



            return SqlDataAccess.EditData(sql, data);
        }

        public static List<UsersModel> LoadUser()
        {
            string sql = @"select Id, User_ID, UserName, FirstName, LastName, MiddleName, EmailAddress, UserPassword from dbo.UserInfo;";
            return SqlDataAccess.LoadData<UsersModel>(sql);
        }

        public static List<UsersModel> DeleteUser()
        {
            int DeleteID = Variables.UID;
            string sql = @"delete from dbo.UserInfo where id = " + @DeleteID.ToString() +";";
            return SqlDataAccess.DeleteData<UsersModel>(sql);
        }

    }
}

