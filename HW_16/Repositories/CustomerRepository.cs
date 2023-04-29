using Dapper;
using HW_16.Models;
using Npgsql;

namespace HW_16.Repositories;

internal static class CustomerRepository
{
    public static List<Customer> GetCustomers(int page)
    {
        using var db = new NpgsqlConnection(Config.SqlConnectionString);
        var sql = $"select * from customers limit 10 offset {10 * page}";
        return db.Query<Customer>(sql).ToList();
    }

    public static List<Customer> GetSortedCustomersUnderAge(int age)
    {
        using var db = new NpgsqlConnection(Config.SqlConnectionString);
        var sql = $"select * from customers where age<{age} order by lastname desc";
        return db.Query<Customer>(sql).ToList();
    }
}