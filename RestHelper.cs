using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management
{
    public static class RestHelper
    {

        // Start - Function for GetAll
        public static async Task<string> GetAll()
        {
            using(HttpClient client = new HttpClient())
            {

                using(HttpResponseMessage Response = await client.GetAsync("https://gorest.co.in/public-api/users"))
                {
                    using(HttpContent content = Response.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if(data != null)
                        {
                            return data;
                        }
                    }
                }

            }
            return string.Empty;
        }

        //End - Function for GetAll

        public static string BeautifyJson(string jsondata)
        {
            JToken parseJson = JToken.Parse(jsondata);
            return parseJson.ToString(Formatting.Indented);
        }



        //// Start - Function for Post
        //public static async Task<string> Post(string id, string name, string gender, string email, string status)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var InputData = new Dictionary<string, string>
        //        {
        //            {"id" , id },
        //            {"name" , name },
        //            {"email" , email},
        //            {"gender" , gender},
        //            {"status" , status }
        //        };

        //        var input = new FormUrlEncodedContent(InputData);

        //        using (HttpResponseMessage Response = await client.PostAsync("https://gorest.co.in/public-api/users" , input))
        //        {
        //            using (HttpContent content = Response.Content)
        //            {
        //                string data = await content.ReadAsStringAsync();
        //                if (data != null)
        //                {
        //                    return data;
        //                }
        //            }
        //        }

        //    }
        //    return string.Empty;
        //}

        ////End - Function for Post


        //Start - Function for Get

        public static async Task<string> Get(string Getid)
        {
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage Response = await client.GetAsync("https://gorest.co.in/public-api/users" + Getid))
                {
                    using (HttpContent content = Response.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }

            }
            return string.Empty;
        }

        //End - Function for GetAll

        //End - Function for Get

        //Start -  Function for Put
        public static async Task<string>Put(string Getid,string id, string name, string gender, string email, string status)
        {
            using (HttpClient client = new HttpClient())
            {
                {
                    var InputData = new Dictionary<string, string>
                            {
                                {"id" , id },
                                {"name" , name },
                                {"email" , email},
                                {"gender" , gender},
                                {"status" , status }
                            };

                    var input = new FormUrlEncodedContent(InputData);

                    using (HttpResponseMessage Response = await client.PutAsync("https://gorest.co.in/public-api/users" + Getid, input))
                    {
                        using (HttpContent content = Response.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                return data;
                            }
                        }
                    }

                }
            }
                return string.Empty;
        }


    }
}
