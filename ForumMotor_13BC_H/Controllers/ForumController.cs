using ForumMotor_13BC_H.Data;
using ForumMotor_13BC_H.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumMotor_13BC_H.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ForumController : ControllerBase
    {
        
        private readonly ApplicationDbContext _context;

        public ForumController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost()
        {
            var post = await _context.Posts.FirstOrDefaultAsync();

            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet]
        public async Task<ActionResult<Post>> PostPosts(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id}, post);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Route("{id}/Like")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<String>> Like(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            post.Like++;
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(post.Like);
        }

        [Route("{id}/DisLike")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<String>> DisLike(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            post.DisLike++;
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(post.DisLike);
        }
    }
}
