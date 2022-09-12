using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.list
{
    public class Api : IApi
    {
        private readonly string BaseURL = "http://localhost:4201/api/heroes";

        public List<Contacts> GetContacts()
        {
            var response = Get();
            if (response.IsSuccessful && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    var contacts = JsonConvert.DeserializeObject<List<Contacts>>(response.Content);
                    return contacts;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        RestResponse Get()
        {
            var client = new RestClient(BaseURL);
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = client.Execute(request);
            return response;
        }
        public Contacts EvolveContact(string value, string action)
        {
            var response = Post(value, action);
            if (response.IsSuccessful && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    var contacts = JsonConvert.DeserializeObject<Contacts>(response.Content);
                    return contacts;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }
        RestResponse Post(string value, string action)
        {
            var client = new RestClient($"{BaseURL}?action={action}");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            var body = $@"""{value}""
            " + "\n" +
                        @"   
            " + "\n" +
            @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
    }
}
