using System.Collections.Generic;
using System.Linq;
using WorkApp.Model;
using WorkApp.Services;

namespace WorkApp.ViewModel
{
    internal class MainViewModel
    {
        public List<DataView> dataList { get; set; } = new();
        public MainViewModel()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Category clothes = new() { Name = "Clothes" };
                Category computers = new() { Name = "Computers" };
                Category cars = new() { Name = "Cars" };
                Category homeElectronics = new() { Name = "HomeElectronics" };

                db.Categories.AddRange(clothes, computers, cars, homeElectronics);

                Product bmwM3 = new() { Name = "BMW Model 3", Price = 5100000m, Category = cars };
                Product ladaCalina = new() { Name = "Lada Calina", Price = 800560.99m, Category = cars };
                Product PC_One = new() { Name = "Computer Model One", Price = 89999m, Category = computers };
                Product PC_Two = new() { Name = "Computer Model Two", Price = 56000m, Category = computers };
                Product PC_Three = new() { Name = "Computer Model Three", Price = 37000.99m, Category = computers };
                Product becoGazeStove = new() { Name = "Gaze Stove from BEKO", Price = 31000.99m, Category = homeElectronics };
                Product lgFridge = new() { Name = "Fridge from LG", Price = 45000m, Category = homeElectronics };
                Product nikeCap = new() { Name = "Cap from NIKE", Price = 510.89m, Category = clothes };
                Product pumaCap = new() { Name = "Cap from PUMA", Price = 499.99m, Category = clothes };
                Product adidasCap = new() { Name = "Cap from ADIDAS", Price = 600m, Category = clothes };

                db.Products.AddRange(bmwM3, ladaCalina, PC_One, PC_Two, PC_Three, becoGazeStove, lgFridge,
                    nikeCap, pumaCap, adidasCap);
                db.SaveChanges();
            }          

            using (ApplicationContext db = new ApplicationContext())
            {
                var products = db.Products.Join(db.Categories,
                    p => p.CategoryId,
                    c => c.Id,
                    (p, c) => new
                    {
                        Name = p.Name,
                        Category = c.Name,
                        Price = p.Price
                    });

                foreach (var p in products)
                    dataList.Add(new() { Name = $"{p.Name}", Category = $"({p.Category})", Price = $"{p.Price} ₽" });                        
            }
        }
    }
}
