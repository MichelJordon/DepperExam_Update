using Dapper;
using Domain.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CategoryService
    {
        private string _connectionString = "Server=127.0.0.1;Port=5432;Database=quote_service; User Id=postgres;Password=shohrukh;";

        public List<Category> GetCategorys()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Categorys";

                return conn.Query<Category>(sql).ToList();
            }
        }

        public int InsertCategory(Category category)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql =
                    $"insert into Categorys (CategoryText) VALUES " +
                    $"('{category.CategoryText}')";
                var result = conn.Execute(sql);

                return result;
            }
        }

        public int UpdateCategory(Category category)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                 string sql = $"UPDATE Categorys Set QuoteText = '{category.CategoryText}' where id = {category.Id}";
                var result = conn.Execute(sql);

                return result;
            }
        }

        public int DeleteCategory(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"DELETE FROM Categorys WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }
        }
        
    }
}