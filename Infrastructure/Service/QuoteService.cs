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
    public class QuoteService
    {
        private string _connectionString = "Server=127.0.0.1;Port=5432;Database=quote_service;User Id=postgres;Password=shohrukh;";

        public List<Quote> GetQuotes()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Quotes";

                return conn.Query<Quote>(sql).ToList();
            }
        }

        public int InsertQuote(Quote quote)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql =
                    $"insert into Quotes (CategoryId, QuoteText) VALUES " +
                    $"( {quote.CategoryId}, '{quote.QuoteText}')";
                var result = conn.Execute(sql);

                return result;
            }
        }

        public int UpdateQuote(Quote quote)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                string sql = $"Update Quotes Set quotetext = '{quote.QuoteText}', CategoryId = {quote.CategoryId} where id = {quote.Id}";
            
                var result = conn.Execute(sql);

                return result;
            }
        }
        public List<Quote> GetRendomQuotes()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"Select * from Quotes Order by random() limit 1;";
            
                var result = conn.Query<Quote>(sql).ToList();

                return result;
            }
        }
        public int DeleteQuote(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"DELETE FROM Quotes WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }
        }
        public List<Quote> GetQuotesByCategory(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Quotes WHERE CategoryId = {id}";

                var result = conn.Query<Quote>(sql).ToList();

                return result;
            }
        }

    }
}