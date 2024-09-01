// See https://aka.ms/new-console-template for more information

using BuilderDesignPattern;

var products = new List<Product>
{
    new Product { MyProperty = "Apple", Price = 1.0 },
    new Product { MyProperty = "Banana", Price = 2.0 },
    new Product { MyProperty = "Cherry", Price = 3.0 }
};

var builder = new ProductStockReportBuilder(products);

var director = new ProductStockReportDirector(builder);

director.BuildStockReport();

Console.WriteLine(builder.GetReport());