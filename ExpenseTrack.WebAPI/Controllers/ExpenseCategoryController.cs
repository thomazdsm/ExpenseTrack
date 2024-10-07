using ExpenseTrack.Application.Interfaces;
using ExpenseTrack.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseCategoryController : ControllerBase
    {

        private readonly IExpenseCategoryService _expenseCategoryService;

        public ExpenseCategoryController(IExpenseCategoryService expenseCategoryService)
        {
            _expenseCategoryService = expenseCategoryService;
        }

        // GET: api/ExpenseCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseCategoryViewModel>>> Get()
        {
            // Busca todas as categorias de despesas
            var categories = await _expenseCategoryService.GetAllAsync();
            return Ok(categories);
        }

        // GET api/ExpenseCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseCategoryViewModel>> Get(int id)
        {
            // Busca a categoria pelo ID
            var category = await _expenseCategoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound(); // Retorna 404 se não encontrar
            }

            return Ok(category);
        }

        // POST api/ExpenseCategory
        [HttpPost]
        public IActionResult Post([FromBody] ExpenseCategoryViewModel expenseCategory)
        {
            // Valida o modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Adiciona a categoria
            _expenseCategoryService.AddAsync(expenseCategory);
            return CreatedAtAction(nameof(Get), new { id = expenseCategory.Id }, expenseCategory);
        }

        // PUT api/ExpenseCategory/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ExpenseCategoryViewModel expenseCategory)
        {
            // Verifica se o modelo é válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Atualiza a categoria
            _expenseCategoryService.UpdateAsync(expenseCategory);
            return NoContent(); // Retorna 204 se for atualizado com sucesso
            // TODO: Verificar esse output!
        }

        // DELETE api/ExpenseCategory/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Remove a categoria
            _expenseCategoryService.DeleteAsync(id);
            return NoContent(); // Retorna 204 se for deletado com sucesso
            // TODO: Verificar esse output!
        }
    }
}
