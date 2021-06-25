namespace P00.CodeFirstDemo.Modules
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Ingridient 
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}
