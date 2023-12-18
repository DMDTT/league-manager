using Entities.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.League;

public class Import : PageModel
{
    private readonly ISender _Sender;

    public Import(ISender sender)
    {
        _Sender = sender;
    }

    public void OnGet()
    {
 
    }
    
    public async Task<IActionResult> OnPostAsync(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            // Save the file to a location or process it as needed
            var filePath = Path.Combine(Path.GetTempPath(), file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Add your processing logic here
            int id = await _Sender.Send(new LeagueImportCommand(filePath));
            return RedirectToPage("/League/Display", new { leagueId = id }); // Redirect to a different page after successful upload
        }

        return Page(); // Stay on the same page if the file is not provided or is empty
    }
}