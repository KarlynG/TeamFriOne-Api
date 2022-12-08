using Microsoft.AspNetCore.Mvc;
using TeamFriOne_Core;
using TeamFriOne_Infrastructure.Services;

namespace TeamFriOne_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TEntity> : ControllerBase where TEntity : class, IBaseEntity
    {
        private readonly IBaseService<TEntity> _service;

        public BaseController(IBaseService<TEntity> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(TEntity entity)
        {
            var result = await _service.AddAsync(entity);
            return Ok(result);
        }
        [HttpPut]
        public virtual async Task<IActionResult> Update(TEntity entity)
        {
            var result = await _service.UpdateAsync(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }
    }
}
