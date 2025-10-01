using LBMS_V1.Models;
using LBMS_V1.NewFolder;
using LBMS_V1.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LBMS_V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibrary _libraryService;
        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILibrary libraryService , ILogger<LibraryController> logger)
        {
            _libraryService = libraryService;
            _logger = logger;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateBookDTO book)
        {
            try
            {
                _logger.LogInformation("Create called with Title={Title}, Author={Author}, PublishedYear={Year}", book.Title, book.Author, book.PublishedYear);

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Model state invalid for book creation");
                    return BadRequest(ModelState);
                }

                await _libraryService.CreateBookAsync(book);

                _logger.LogInformation("Book created successfully");
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating book");
                return StatusCode(500, new { message = "An error occurred while creating the book." });
            }
        }


        // PUT: Library/Update/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, CreateBookDTO bookDto)
        {
            try
            {
                _logger.LogInformation("Update called for ID={Id} with Title={Title}, Author={Author}, PublishedYear={Year}", id, bookDto.Title, bookDto.Author, bookDto.PublishedYear);

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Update failed: invalid model state for ID={Id}", id);
                    return BadRequest(ModelState);
                }

                var success = await _libraryService.UpdateBookAsync(id, bookDto);

                if (success)
                {
                    _logger.LogInformation("Book updated successfully for ID={Id}", id);
                    return Ok(new { message = "Book updated successfully" });
                }

                _logger.LogWarning("Update failed: book not found for ID={Id}", id);
                return NotFound(new { message = "Book not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while updating book ID={Id}", id);
                return StatusCode(500, new { message = "An error occurred while updating the book." });
            }
        }

        // DELETE: Library/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Delete called for ID={Id}", id);

                var success = await _libraryService.DeleteBookAsync(id);

                if (success)
                {
                    _logger.LogInformation("Book deleted successfully for ID={Id}", id);
                    return Ok(new { message = "Book deleted successfully" });
                }

                _logger.LogWarning("Delete failed: book not found for ID={Id}", id);
                return NotFound(new { message = "Book not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while deleting book ID={Id}", id);
                return StatusCode(500, new { message = "An error occurred while deleting the book." });
            }
        }

        // GET: Library/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAll called");

                var books = await _libraryService.GetAllBooksAsync();

                _logger.LogInformation("GetAll returned {Count} books", books?.Count());

                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while fetching all books");
                return StatusCode(500, new { message = "An error occurred while fetching books." });
            }
        }

    }
}
