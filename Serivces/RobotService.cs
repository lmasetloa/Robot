using Newtonsoft.Json;
using Robot.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Robot.Serivces
{
    public class RobotService: IRobotService
    {

        public object  CallWebAPIAsync()
        {
            List<Robots> robots = new List<Robots>();
            List<RobotData> robotData = new List<RobotData>();
           
            try
            {
              
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://robotstakeover20210903110417.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method
                    HttpResponseMessage response =  client.GetAsync("robotcpu").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var EmpResponse = response.Content.ReadAsStringAsync().Result;
                        //robot = response.Content.ReadAsAsync<IEnumerable<Robots>>().Result;
                        //Robots robots =  JsonConvert.DeserializeObject<Robots>(robot.ToString());
                        //  Robots robot = (Robots)await response.Content.ReadAsAsync<IEnumerable<Robots>>();

                        robots = JsonConvert.DeserializeObject<List<Robots>>(EmpResponse);

                        foreach(var robot in robots)
                        {
                            RobotData data = new RobotData()
                            {
                                Robot_model = robot.model,
                                Robot_Number = robot.serialNumber,
                                Create_Date = robot.manufacturedDate,
                            };
                            data.Robot_kind = "flying robot";
                            if (robot.category == "Land")                             
                                data.Robot_kind = "Walking robot";
                            robotData.Add(data);

                        }        
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }                
                return robotData;
            }
            catch (Exception ex)
            {
                Log.Error($" Internal server Error {ex}");
            }
            return robotData;
        }

        public List<RobotData> robots()
        {
            List<RobotData> robots = new List<RobotData>();
           var list = CallWebAPIAsync();         
            return robots;
        }
    }
}
