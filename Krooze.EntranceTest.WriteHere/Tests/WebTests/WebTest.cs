using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Krooze.EntranceTest.WriteHere.Tests.WebTests
{
    public class WebTest
    {
        public JObject GetAllMovies()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the films object

            string urlGetFilmes = "https://swapi.co/api/films/";

            var request = (HttpWebRequest)WebRequest.Create(urlGetFilmes);
            request.Method = "GET";

            HttpWebResponse response = null;

            
                response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var ReadedToEnd = reader.ReadToEnd();
                    JObject.Parse(ReadedToEnd);
                    return JObject.Parse(ReadedToEnd);
            }
               
        
        }
                    
        public string GetDirector()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the name of person that directed the most star wars movies, based on the films object return

            string urlGetFilmes = "https://swapi.co/api/films/";

            var request = (HttpWebRequest)WebRequest.Create(urlGetFilmes);
            request.Method = "GET";

            HttpWebResponse response = null;


            response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                var ReadedToEnd = reader.ReadToEnd();
                

                //var diretores = JObject.Parse(ReadedToEnd);

                //var teste = diretores["director"];


                //AreEqual("A New Hope", aNewHope["title"].Value<string>());

                return ReadedToEnd;
            }
        }
    }
}

