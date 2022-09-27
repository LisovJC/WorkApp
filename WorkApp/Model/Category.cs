using System.Collections.Generic;

namespace WorkApp.Model
{
    internal class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}
