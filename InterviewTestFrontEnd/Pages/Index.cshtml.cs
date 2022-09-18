using InterviewTest.Controllers;
using InterviewTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestFrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration configuration;

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<IActionResult> OnGetAllHeroes()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(configuration["heroesApiEndpoint"]);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return new OkObjectResult(JsonConvert.DeserializeObject<List<Hero>>(result));
                else
                    return new NotFoundObjectResult(result);
            }
        }
        public async Task<IActionResult> OnPostEvolveHero(HeroPayload heroPayload)
        {
            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(configuration["heroesApiEndpoint"]);
                request.Content = new StringContent(JsonConvert.SerializeObject(heroPayload), Encoding.UTF8, "application/json");
                var response = await httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return new OkObjectResult(JsonConvert.DeserializeObject<Hero>(result));
                else
                    return new NotFoundObjectResult(result);
            }
        }
    }
}
