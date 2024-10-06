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
    public class ExchangeRateController : ControllerBase
    {

        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        // GET: api/ExchangeRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExchangeRateViewModel>>> Get()
        {
            // Busca todas os registros de cotação
            var exchangeRates = await _exchangeRateService.GetAllAsync();
            return Ok(exchangeRates);
        }


        // GET api/ExchangeRate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExchangeRateViewModel>> Get(int id)
        {
            // Busca o registro de cotação pelo ID
            var exchangeRate = await _exchangeRateService.GetByIdAsync(id);

            if (exchangeRate == null)
            {
                return NotFound(); // Retorna 404 se não encontrar
            }

            return Ok(exchangeRate);
        }

        // POST api/ExchangeRate
        [HttpPost]
        public IActionResult Post([FromBody] ExchangeRateViewModel exchangeRate)
        {
            // Valida o modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Adiciona o registro de cotação
            _exchangeRateService.AddAsync(exchangeRate);
            return CreatedAtAction(nameof(Get), new { id = exchangeRate.Id }, exchangeRate);
        }

        // PUT api/ExchangeRate/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ExchangeRateViewModel exchangeRate)
        {
            // Verifica se o modelo é válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Atualiza o registro de cotação
            _exchangeRateService.UpdateAsync(exchangeRate);
            return NoContent(); // Retorna 204 se for atualizado com sucesso
            // TODO: Verificar esse output!
        }

        // DELETE api/ExchangeRate/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Remove o registro de cotação
            _exchangeRateService.DeleteAsync(id);
            return NoContent(); // Retorna 204 se for deletado com sucesso
            // TODO: Verificar esse output!
        }
    }
}
