using Microsoft.EntityFrameworkCore;
using ORMHW.Contexts;
using ORMHW.Models;

ShopDbContext shopDbContext = new ShopDbContext();


void CreateCategory()
{
    Console.WriteLine("Please add category name");
    string Name = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(Name))
    {
        Console.WriteLine("Name can not be empaty");
        Name = Console.ReadLine();
    }

    Category category = new Category
    {
        Name = Name,
        CreatedAt = DateTime.UtcNow.AddHours(4),

    };

    shopDbContext.Add(category);
    int result = shopDbContext.SaveChanges();
    Console.WriteLine( result > 0 ? "Success" : "Something went wrong");
}

void GetAllCategory()
{
    IQueryable<Category> queries = shopDbContext.Categories
        .Where(x => !x.IsDeleted).AsNoTracking();


    List<Category> categories = queries
        .Select(x => new Category { Name = x.Name, Id = x.Id })
        .ToList();
    foreach (var item in categories)
    {
        Console.WriteLine($"CategoryName:{item.Name} Id:{item.Id}");
    }
 
}

void GetByIdCategory()
{
    Console.WriteLine("Please add category Id");
    int.TryParse(Console.ReadLine(), out int Id);
    Category? category = shopDbContext.Categories.Where(x => x.Id == Id)
        .AsNoTracking()
        .FirstOrDefault();

    if (category == null)
    {
        Console.WriteLine("Not found");
        return;
    }

    Console.WriteLine(category.Name);


}

void UpdateCategory()
{

    Console.WriteLine("Add category Id");
    int.TryParse(Console.ReadLine(), out int Id);
    Category? category = shopDbContext.Categories.Where(x => x.Id == Id)
        .FirstOrDefault();

    if (category == null)
    {
        Console.WriteLine("Not found");
        return;
    }

    Console.WriteLine("Add New Name");
    string Name = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(Name))
    {
        Console.WriteLine("Name can not be empaty");
        Name = Console.ReadLine();
    }

    category.Name = Name;
    category.UpdatedAt = DateTime.UtcNow.AddHours(4);
    shopDbContext.SaveChanges();

}

void RemoveCategory()
{
    Console.WriteLine("Add Id");
    int.TryParse(Console.ReadLine(), out int Id);
    Category? category = shopDbContext.Categories.Where(x => x.Id == Id)
        .FirstOrDefault();

    if (category == null)
    {
        Console.WriteLine("Not found");
        return;
    };
    category.IsDeleted = true;
    shopDbContext.SaveChanges();

}


void CreateProduct()
{
    Console.WriteLine("Please add name");
    string Name = Console.ReadLine();
    Console.WriteLine("Please add price");
    double Price= double.Parse( Console.ReadLine());
    Console.WriteLine("Please add categoryId");
    int CategoryId = int.Parse(Console.ReadLine());


    while (string.IsNullOrWhiteSpace(Name))
    {
        Console.WriteLine("Name can not be empaty");
        Name = Console.ReadLine();
    }

    Product product = new Product
    {
        Name = Name,
        Price = Price,
        CategoryId = CategoryId,
        CreatedAt = DateTime.UtcNow.AddHours(4),

    };

    shopDbContext.Add(product);
    int result = shopDbContext.SaveChanges();
    Console.WriteLine(result > 0 ? "Success" : "Something went wrong");
}

void GetAllProduct()
{
    IQueryable<Product> query = shopDbContext.Products
        .Where(x => !x.IsDeleted)
        .Include(x => x.Category)
        .AsNoTracking().Select(x => new Product
        {
            Name = x.Name,
            Category = new Category { Name = x.Category.Name }
        });

    IEnumerable<Product> products = query.ToList();

    foreach (var item in products)
    {
        Console.WriteLine(item.Name);
    }
}

void GetByIdProduct()
{
    Console.WriteLine("Please add Product Id");
    int.TryParse(Console.ReadLine(), out int Id);
    Product? product = shopDbContext.Products.Where(x => x.Id == Id)
        .AsNoTracking()
        .FirstOrDefault();

    if (product == null)
    {
        Console.WriteLine("Not found");
        return;
    }

    Console.WriteLine(product.Name);


}

void UpdateProduct()
{

    Console.WriteLine("Add product Id");
    int.TryParse(Console.ReadLine(), out int Id);
    Product? product = shopDbContext.Products.Where(x => x.Id == Id)
        .FirstOrDefault();

    if (product == null)
    {
        Console.WriteLine("Not found");
        return;
    }

    Console.WriteLine("Please choose what you want to update");
    Console.WriteLine("1.Name");
    Console.WriteLine("2.CategoryId");
    Console.WriteLine("3. Both");
    int updaterequest = int.Parse(Console.ReadLine());

    switch (updaterequest)
    {
        case 1:
            Console.WriteLine("Add New Name");
            string Name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Name can not be empaty");
                Name = Console.ReadLine();
            }

            product.Name = Name;
            product.UpdatedAt = DateTime.UtcNow.AddHours(4);
            shopDbContext.SaveChanges();
            break;
            case 2:
            Console.WriteLine("Add New CategoryId");
            int CategoryId = int.Parse(Console.ReadLine());
            product.CategoryId = CategoryId;
            product.UpdatedAt = DateTime.UtcNow.AddHours(4);
            shopDbContext.SaveChanges();
            break;
            case 3:
            Console.WriteLine("Add New Name");
            string Name3 = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(Name3))
            {
                Console.WriteLine("Name can not be empaty");
                Name = Console.ReadLine();
            }

            Console.WriteLine("Add New CategoryId");
            int CategoryId3 = int.Parse(Console.ReadLine());
            product.Name = Name3;
            product.CategoryId = CategoryId3;
            product.UpdatedAt = DateTime.UtcNow.AddHours(4);
            shopDbContext.SaveChanges();
            break;
        default:
            break;
    }
        

   

}


void RemoveProduct()
{
    Console.WriteLine("Add product Id");
    int.TryParse(Console.ReadLine(), out int Id);
    Product? product = shopDbContext.Products.Where(x => x.Id == Id)
        .FirstOrDefault();

    if (product == null)
    {
        Console.WriteLine("Not found");
        return;
    };
    product.IsDeleted = true;
    shopDbContext.SaveChanges();

}

