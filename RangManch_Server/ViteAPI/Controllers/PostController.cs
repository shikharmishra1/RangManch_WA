using Microsoft.AspNetCore.Mvc;
using ViteAPI.Models;
using ViteAPI.Services;

//webapi
namespace ViteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly RangmanchDBServices _rangmanchDB_services;
        public PostController(RangmanchDBServices rangmanchDB_services)
        {
            _rangmanchDB_services = rangmanchDB_services;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _rangmanchDB_services.readAsync();
            return Ok(posts);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            
            await _rangmanchDB_services.createAsync(post);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(string id, Post post)
        {
            await _rangmanchDB_services.updateAsync(id, post);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _rangmanchDB_services.deleteAsync(id);
            return Ok();
        }
    }
}