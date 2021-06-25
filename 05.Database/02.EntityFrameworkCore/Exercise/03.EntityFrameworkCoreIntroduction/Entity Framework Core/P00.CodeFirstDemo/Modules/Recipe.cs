namespace P00.CodeFirstDemo.Modules
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Ingridient> Ingridients { get; set; }
    }
}
