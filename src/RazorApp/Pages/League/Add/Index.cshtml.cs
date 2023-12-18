using Entities.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.League.Add;

public class Index : PageModel
{
    private readonly ISender _Sender;

    public Index(ISender sender)
    {
        _Sender = sender;
    }

    [BindProperty] public string Title { get; set; }
    [BindProperty] public int TeamCount { get; set; }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        _Sender.Send(new LeagueAddCommand(Title, TeamCount));
    }
}