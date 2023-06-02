
using Aula03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aula03.pages.Movies
{
    public class Index : PageModel
    {

        public List<MovieModel> MoviesList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var httpClient = new HttpClient();
            var url = "http://localhost:8085/movies";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);

            var content = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(content);
            var jsonArray = jsonObject.SelectToken("movies");

            MoviesList = JsonConvert.DeserializeObject<List<MovieModel>>(jsonArray.ToString())
                .OrderBy(movie => movie.Name).ToList();

            return Page();
        }
    }
}
