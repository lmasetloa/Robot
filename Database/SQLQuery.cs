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
                                userID = Convert.ToInt32(reader["userid"]);
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
                    using (SqlCommand command = new SqlCommand("[dbo].[UpdateLocation]  @UserID,@Lat,@long", connection))
                    {
                        command.Parameters.AddWithValue("@UserID", Id);
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

        public List<SuviviorViewModel> survivors()
        {
            List<SuviviorViewModel> sur = new List<SuviviorViewModel>();

            try
            {
                var UserID = "";
                using (SqlConnection connection = new SqlConnection(Config.AppSettings.DefaultConnection))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[AllSurvivors]", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SuviviorViewModel survivor = new SuviviorViewModel()
                                {
                                    ID = (int)reader["ID"],
                                    Name = reader["Name"].ToString(),
                                    Surname = reader["Surname"].ToString(),
                                    age = int.Parse(reader["age"].ToString()),
                                    Gender = Char.Parse(reader["Gender"].ToString()),
                                    IDNumber = reader["IDNumber"].ToString(),
                                    Lat = reader["Lat"].ToString(),
                                    Long = reader["Long"].ToString()
                              

                            };
                                using (SqlCommand commands = new SqlCommand($"SELECT [Resource] FROM [Survivor].[dbo].[Resources] where [UserID] = {survivor.ID}", connection))
                                {
                                    using (SqlDataReader readers = commands.ExecuteReader())
                                    {
                                        while (readers.Read())
                                        {
                                            survivor.list.Add(readers["Resource"].ToString());
                                        }
                                    }
                                }
                                sur.Add(survivor);

                            }
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
            }

           
            return sur;
        }

        public List<SuviviorViewModel> Nonsurvivors()
        {
            List<SuviviorViewModel> sur = new List<SuviviorViewModel>();

            try
            {
                var UserID = "";
                using (SqlConnection connection = new SqlConnection(Config.AppSettings.DefaultConnection))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo].[AllNonSurvivors]", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SuviviorViewModel survivor = new SuviviorViewModel()
                                {
                                    ID = (int)reader["ID"],
                                    Name = reader["Name"].ToString(),
                                    Surname = reader["Surname"].ToString(),
                                    age = int.Parse(reader["age"].ToString()),
                                    Gender = Char.Parse(reader["Gender"].ToString()),
                                    IDNumber = reader["IDNumber"].ToString(),
                                    Lat = reader["Lat"].ToString(),
                                    Long = reader["Long"].ToString()


                                };
                                using (SqlCommand commands = new SqlCommand($"SELECT [Resource] FROM [Survivor].[dbo].[Resources] where [UserID] = {survivor.ID}", connection))
                                {
                                    using (SqlDataReader readers = commands.ExecuteReader())
                                    {
                                        while (readers.Read())
                                        {
                                            survivor.list.Add(readers["Resource"].ToString());
                                        }
                                    }
                                }
                                sur.Add(survivor);

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }


            return sur;
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

       public string AddZombi(int ReporterID,int newZombiID)
        {
            try 
            {
                var message = "";
                using (SqlConnection connection = new SqlConnection(Config.AppSettings.DefaultConnection))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[AddZombi]   @ReporterID,@newZombiID", connection))
                    {
                        command.Parameters.AddWithValue("@ReporterID", ReporterID);
                        command.Parameters.AddWithValue("@newZombiID", newZombiID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                message = reader["Results"].ToString();
                            }
                        }
                    }
                }
                return message;
            }
            catch(Exception ex)
            {
                Log.Error($"having problem proccessing your details{ex}");
                return ex.ToString();
            }

           


        }
    }
}
