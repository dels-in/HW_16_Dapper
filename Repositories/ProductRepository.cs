using Dapper;
using HW_16.Models;
using Npgsql;

namespace HW_16.Repositories;

internal static class ProductRepository
{
    public static List<Product> GetProducts(int page)
    {
        using var db = new NpgsqlConnection(Config.SqlConnectionString);
        var sql = $"select * from products limit {10} offset {10*page}";
        return db.Query<Product>(sql).ToList();
    }

    public static void AddProduct(Product product)
    {
        using var db = new NpgsqlConnection(Config.SqlConnectionString);
        var sql = $"insert into products (name, description, stockQuantity, price) values (@name, @description, @stockQuantity, @price)";
        db.Execute(sql, product);
    }

    public static Product GetProductById(int id)
    {
        using var db = new NpgsqlConnection(Config.SqlConnectionString);
        var sql = $"select * from products where id = {id}";
        return db.QueryFirstOrDefault<Product>(sql);
    }
}