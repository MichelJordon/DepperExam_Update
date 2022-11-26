using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController
    {
        private QuoteService _quoteService;

        public QuoteController()
        {
            _quoteService = new QuoteService();
        }
        [HttpGet("GetAll")]
        public List<Quote> GetQuotes()
        {
            return _quoteService.GetQuotes();
        }

        [HttpPost("Insert")]
        public int InsertQuote(Quote quote)
        {
            return _quoteService.InsertQuote(quote);
        }

        [HttpPut]
        public int UpdateQuote(Quote quote)
        {
            return _quoteService.UpdateQuote(quote);
        }

        [HttpDelete]
        public int DeleteQuote(int id)
        {
            return _quoteService.DeleteQuote(id);
        }
        [HttpGet("GetRendomQuotes")]
        public List<Quote> GetRendomQuotes()
        {
            return _quoteService.GetRendomQuotes();
        }
        [HttpGet("GetQuotesByCategoty")]
        public List<Quote> GetQuotesByCategory(int id)
        {
            return _quoteService.GetQuotesByCategory(id);
        }
    }
}