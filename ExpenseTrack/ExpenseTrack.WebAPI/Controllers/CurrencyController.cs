using ExpenseTrack.Application.Interfaces;
using ExpenseTrack.Application.Services;
using ExpenseTrack.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyController : ControllerBase
    {

        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        // GET: api/Currency
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyViewModel>>> Get()
        {
            // Busca todas as moedas de despesas
            var currencies = await _currencyService.GetAllAsync();
            return Ok(currencies);
        }

        // GET api/Currency/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrencyViewModel>> Get(int id)
        {
            // Busca a moeda pelo ID
            var currency = await _currencyService.GetByIdAsync(id);

            if (currency == null)
            {
                return NotFound(); // Retorna 404 se não encontrar
            }

            return Ok(currency);
        }

        // POST api/Currency
        [HttpPost]
        public IActionResult Post([FromBody] CurrencyViewModel currency)
        {
            // Valida o modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Adiciona a moeda
            _currencyService.AddAsync(currency);
            return CreatedAtAction(nameof(Get), new { id = currency.Id }, currency);
        }

        // PUT api/Currency/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CurrencyViewModel currency)
        {
            // Verifica se o modelo é válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Atualiza a moeda
            _currencyService.UpdateAsync(currency);
            return NoContent(); // Retorna 204 se for atualizado com sucesso
            // TODO: Verificar esse output!
        }

        // DELETE api/Currency/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Remove a Moeda
            _currencyService.DeleteAsync(id);
            return NoContent(); // Retorna 204 se for deletado com sucesso
            // TODO: Verificar esse output!
        }
    }
}
