using Entities.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.League;

public class Add : LeagueBase
{
    public Add(ISender sender) : base(sender)
    {
    }
    [BindProperty] public string Title { get; set; }
    [BindProperty] public int TeamCount { get; set; }
    public async Task<IActionResult> OnPost()
    {
        var result = await Sender.Send(new LeagueAddCommand(Title, TeamCount));
        //return RedirectToPage("/leagues/display", new { leagueId = result });
        return RedirectToPage("/League/AddTeams", new { leagueId = result });
    }
}