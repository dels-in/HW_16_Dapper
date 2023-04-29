using Dapper;
using HW_16.Models;
using Npgsql;

namespace HW_16.Repositories;

internal static class OrderRepository
{
    public static List<Order> GetOrders(int page)
    {
        using var db = new NpgsqlConnection(Config.SqlConnectionString);
        var sql = $"select * from orders limit 10 offset {10*page}";
        return db.Query<Order>(sql).ToList();
    }
    
    public static Order GetOrdersByCustomerId(int id)
    {
        using var db = new NpgsqlConnection(Config.SqlConnectionString);
        var sql = $"select * from orders where customerid = {id}";
        return db.QueryFirstOrDefault<Order>(sql);
    }

    public static Order GetLastOrder()
    {
        using var db = new NpgsqlConnection(Config.SqlConnectionString);
        var sql = $"select * from orders order by id desc limit 1";
        return db.QuerySingleOrDefault<Order>(sql);
    }
}