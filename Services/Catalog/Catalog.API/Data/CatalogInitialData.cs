﻿//using Marten.Schema;

using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data;

public class CatalogInitialData :DbContext
{
    private DataContext DBData { get; set; }
    public CatalogInitialData(DataContext DBData)
    {
        this.DBData = DBData;
        if (!this.DBData.Products.Any())
        {
            this.DBData.Products.AddRange(GetPreconfiguredProducts().ToList<Product>());
            this.DBData.SaveChanges();
        }
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
            {
                new Product()
                {
                    //Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
                    Id = 1,
                    Name = "Milk",
                    Price = 4.99,
                    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    pictureUrl="/public/img/milk.jpg",
                    Image = "https://localhost:5173/public/img/milk.jpg",
                    //Category = new List<string> { "Smart Phone" }
                    Quantity=10
                },
                new Product()
                {
                    //Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
                    Id=2,
                    Name = "Bread",
                    Price = 4.99,
                    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    pictureUrl="/public/img/bread.jpg",
                    Image = "product-2.png",
                    //Category = new List<string> { "Smart Phone" }
                    Quantity=15
                },
                new Product()
                {
                    //Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
                    Id = 3,
                    Name = "Eggs",
                    Price = 5.79,
                    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    pictureUrl="/public/img/eggs.jpg",
                    Image = "https://localhost:5173/public/img/milk.jpg",
                    //Category = new List<string> { "Smart Phone" }
                    Quantity=10
                },
                new Product()
                {
                    //Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
                    Id=4,
                    Name = "Apple",
                    Price = 5.49,
                    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    pictureUrl="/public/img/apple.jpg",
                    Image = "product-2.png",
                    //Category = new List<string> { "Smart Phone" }
                    Quantity=15
                },
                new Product()
                {
                    //Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
                    Id = 5,
                    Name = "atta",
                    Price = 2.99,
                    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    pictureUrl="/public/img/eggs.jpg",
                    Image = "https://localhost:5173/public/img/milk.jpg",
                    //Category = new List<string> { "Smart Phone" }
                    Quantity=10
                },
                new Product()
                {
                    //Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
                    Id=6,
                    Name = "Onion",
                    Price = 12.99,
                    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    pictureUrl="/public/img/onion.jpg",
                    Image = "product-2.png",
                    //Category = new List<string> { "Smart Phone" }
                    Quantity=15
                },
                new Product()
                {
                    //Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
                    Id = 7,
                    Name = "Peas",
                    Price = 3.29,
                    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    pictureUrl="/public/img/peas.jpg",
                    Image = "https://localhost:5173/public/img/milk.jpg",
                    //Category = new List<string> { "Smart Phone" }
                    Quantity=10
                },
                new Product()
                {
                    //Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
                    Id=8,
                    Name = "Rice",
                    Price = 4.99,
                    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    pictureUrl="/public/img/rice.jpg",
                    Image = "product-2.png",
                    //Category = new List<string> { "Smart Phone" }
                    Quantity=15
                },
                new Product()
                {
                    //Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
                    Id = 9,
                    Name = "Sugar",
                    Price = 3.19,
                    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    pictureUrl="/public/img/sugar.jpg",
                    Image = "https://localhost:5173/public/img/milk.jpg",
                    //Category = new List<string> { "Smart Phone" }
                    Quantity=10
                },
                new Product()
                {
                    //Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
                    Id=10,
                    Name = "Tomato",
                    Price = 2.99,
                    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    pictureUrl="/public/img/tomato.jpg",
                    Image = "product-2.png",
                    //Category = new List<string> { "Smart Phone" }
                    Quantity=15
                }
                //new Product()
                //{
                //    Id = new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
                //    Name = "Huawei Plus",
                //    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                //    ImageFile = "product-3.png",
                //    Price = 650.00M,
                //    Category = new List<string> { "White Appliances" }
                //},
                //new Product()
                //{
                //    Id = new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),
                //    Name = "Xiaomi Mi 9",
                //    //Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                //    ImageFile = "product-4.png",
                //    Price = 470.00M,
                //    Category = new List<string> { "White Appliances" }
                //},
                //new Product()
                //{
                //    Id = new Guid("b786103d-c621-4f5a-b498-23452610f88c"),
                //    Name = "HTC U11+ Plus",
                //    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                //    ImageFile = "product-5.png",
                //    Price = 380.00M,
                //    Category = new List<string> { "Smart Phone" }
                //},
                //new Product()
                //{
                //    Id = new Guid("c4bbc4a2-4555-45d8-97cc-2a99b2167bff"),
                //    Name = "LG G7 ThinQ",
                //    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                //    ImageFile = "product-6.png",
                //    Price = 240.00M,
                //    Category = new List<string> { "Home Kitchen" }
                //},
                //new Product()
                //{
                //    Id = new Guid("93170c85-7795-489c-8e8f-7dcf3b4f4188"),
                //    Name = "Panasonic Lumix",
                //    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                //    ImageFile = "product-6.png",
                //    Price = 240.00M,
                //    Category = new List<string> { "Camera" }
                //}
            };

}
