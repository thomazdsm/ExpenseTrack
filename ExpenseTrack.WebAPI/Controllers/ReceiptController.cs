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
    public class ReceiptController : ControllerBase
    {

        private readonly IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        // GET: api/Receipt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptViewModel>>> Get()
        {
            // Busca todos os recibos  de despesas
            var receipts = await _receiptService.GetAllAsync();
            return Ok(receipts);
        }

        // GET api/Receipt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceiptViewModel>> Get(int id)
        {
            // Busca o recibo pelo ID
            var receipt = await _receiptService.GetByIdAsync(id);

            if (receipt == null)
            {
                return NotFound(); // Retorna 404 se não encontrar
            }

            return Ok(receipt);
        }

        // POST api/Receipt
        [HttpPost]
        public IActionResult Post([FromBody] ReceiptViewModel receipt)
        {
            // Valida o modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Adiciona o recibo
            _receiptService.AddAsync(receipt);
            return CreatedAtAction(nameof(Get), new { id = receipt.Id }, receipt);
        }

        // PUT api/Receipt/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReceiptViewModel receipt)
        {
            // Verifica se o modelo é válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Atualiza o recibo
            _receiptService.UpdateAsync(receipt);
            return NoContent(); // Retorna 204 se for atualizado com sucesso
            // TODO: Verificar esse output!
        }

        // DELETE api/Receipt/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Remove o recibo
            _receiptService.DeleteAsync(id);
            return NoContent(); // Retorna 204 se for deletado com sucesso
            // TODO: Verificar esse output!
        }
    }
}
