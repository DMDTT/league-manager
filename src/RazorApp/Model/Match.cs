using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace RazorApp.Model;

public class Match(Application.Entities.Match source)
{
    public int Id { get; } = source.Id;
    public int IdHome { get; } = source.Home.Id;
    public string CodeHome { get; } = source.Home.Code;
    public int IdAway { get; } = source.Away.Id;
    public string CodeAway { get; } = source.Away.Code;
    public int? GoalsHome { get; } = source.GoalsHome;
    public int? GoalsAway { get; } = source.GoalsAway;
    public int GameDay { get; } = source.GameDay.Day;
}