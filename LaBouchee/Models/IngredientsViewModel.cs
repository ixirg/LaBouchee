using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LaBouchee.Models
{
    public class IngredientsViewModel
    {
        
        public int Id { get; set; }
        [DisplayName("Ingredient name")]
        public string Ingredient { get; set; }
        [DisplayName("Ingredient description")]
        public string Description { get; set; }

    }
}
