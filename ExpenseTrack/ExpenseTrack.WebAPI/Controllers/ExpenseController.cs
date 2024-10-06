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
    public class ExpenseController : ControllerBase
    {

        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // GET: api/Expense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseViewModel>>> Get()
        {
            // Busca todas as despesas
            var expenses = await _expenseService.GetAllAsync();
            return Ok(expenses);
        }

        // GET api/Expense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseViewModel>> Get(int id)
        {
            // Busca a despesa pelo ID
            var expense = await _expenseService.GetByIdAsync(id);

            if (expense == null)
            {
                return NotFound(); // Retorna 404 se não encontrar
            }

            return Ok(expense);
        }

        // POST api/Expense
        [HttpPost]
        public IActionResult Post([FromBody] ExpenseViewModel expense)
        {
            // Valida o modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Adiciona a despesa
            _expenseService.AddAsync(expense);
            return CreatedAtAction(nameof(Get), new { id = expense.Id }, expense);
        }

        // PUT api/Receipt/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ExpenseViewModel expense)
        {
            // Verifica se o modelo é válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Atualiza a despesa
            _expenseService.UpdateAsync(expense);
            return NoContent(); // Retorna 204 se for atualizado com sucesso
            // TODO: Verificar esse output!
        }

        // DELETE api/Receipt/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Remove a despesa
            _expenseService.DeleteAsync(id);
            return NoContent(); // Retorna 204 se for deletado com sucesso
            // TODO: Verificar esse output!
        }
    }
}
