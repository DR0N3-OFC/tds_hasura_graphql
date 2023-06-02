using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula03.Models
{
    public class MovieModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MovieID { get; set; }
        
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string? Name { get; set; }

        [JsonProperty("movies_category")]
        public CategoryModel? Category { get; set; }
    }
}
