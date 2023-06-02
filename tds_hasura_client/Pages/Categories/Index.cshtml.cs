
using Aula03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aula03.pages.Categories
{
    public class Index : PageModel
    {
        public List<CategoryModel> CategoriesList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var httpClient = new HttpClient();
            var url = "http://localhost:8085/categories";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);

            var content = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(content);
            var jsonArray = jsonObject.SelectToken("categories");

            CategoriesList = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonArray.ToString())
                .OrderBy(category => category.Name).ToList();


            return Page();
        }
    }
}
