using Robot.Models;
using Robot.Tools;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Robot.Database
{
    public class SQLQuery: ISQLQuery
    {

        public bool findUserByID(string ID)
        {
            bool isExist = false;
            try 
            {
              
                using (SqlConnection connection = new SqlConnection(Config.AppSettings.DefaultConnection))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[FindUserByID] @IDnumber", connection))
                    {
                        command.Parameters.AddWithValue("@IDnumber", ID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                               isExist= (bool)reader["results"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"failed to search for ID number{ex.Message}");
            }
            return isExist;
           
        }
        public string createSurvior(Survivor survivor)
        {
            try {
                var userID = 0;
                using (SqlConnection connection = new SqlConnection(Config.AppSettings.DefaultConnection))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("AddSuvivor @Name,@Surname,@Age,@IDnumber,@Gender,@Lat,@Long",connection))
                    {
                        command.Parameters.AddWithValue("@Name", survivor.Name);
                        command.Parameters.AddWithValue("@Surname", survivor.Surname);
                        command.Parameters.AddWithValue("@Age", survivor.age);
                        command.Parameters.AddWithValue("@IDnumber", survivor.IDNumber);
                        command.Parameters.AddWithValue("@Gender", survivor.Gender);
                        command.Parameters.AddWithValue("@Lat", survivor.Lat);
                        command.Parameters.AddWithValue("@Long", survivor.Long);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                userID = Convert.ToInt32(reader["id"]);
                            }
                        }
                    }

                }

                foreach(var resource in survivor.list)
                {
                    AddResources(userID, resource);
                }
               
                return "survivor has been registered";

            }
            catch(Exception ex)
            {
                Log.Error($"the was an error inserting survior detail into database {ex.Message}");
                return ex.InnerException.Message;
            }            
         
           
        }

        public bool updateLocation(string Id,Location location)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.AppSettings.DefaultConnection))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[UpdateLocation]  @IDnumber,@Lat,@long", connection))
                    {
                        command.Parameters.AddWithValue("@IDnumber", Id);
                        command.Parameters.AddWithValue("@Lat", location.Lat);
                        command.Parameters.AddWithValue("@Long", location.Long);

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                Log.Error($"failed to update the location{ex.Message}");
            }
          
            return false;
        }

       public void AddResources(int UserID,string resource)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.AppSettings.DefaultConnection))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[AddUserResource] @UserID,@Resource", connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@Resource", resource);
                        command.ExecuteNonQuery();
                    }
                }

                }catch(Exception ex)
            {
                Log.Error($"failed to add inventory of resources {ex.Message}");
            }
          
        }
    }
}
