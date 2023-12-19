using Entities.Entities;

namespace RazorApp.Model;

public class TableResult
{
    public List<Team> Teams { get; } = new List<Team>();
    public TableResult(Table source)
    {
        foreach (var teamContainer in source.Teams)
        {
            Teams.Add(new Team(teamContainer));
        }
    }
}