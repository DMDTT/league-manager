using Application.Entities;
using Entities.Entities;

namespace Entities.Services;
public class TableCalculator
{
    public Table Get(League league, int upToGameDay)
    {
        Dictionary<Team, TeamContainer> positions = new Dictionary<Team, TeamContainer>();
        for (int i = 0; i < upToGameDay; i++)
        {
            GameDay gameDay = league.GameDays[i];
            foreach (var gameDayMatch in gameDay.Matches)
            {
                var homeTeam = GetPosition(positions, gameDayMatch, x => x.Home);
                var awayTeam = GetPosition(positions, gameDayMatch, x => x.Away);

                homeTeam.Goals += gameDayMatch.GoalsHome;
                homeTeam.GoalsAgainst += gameDayMatch.GoalsAway;
                
                awayTeam.Goals += gameDayMatch.GoalsAway;
                awayTeam.GoalsAgainst += gameDayMatch.GoalsHome;

                if (gameDayMatch.GoalsHome > gameDayMatch.GoalsAway)
                {
                    homeTeam.Wins++;
                    homeTeam.Points += 3;
                    awayTeam.Losses++;
                }

                if (gameDayMatch.GoalsHome < gameDayMatch.GoalsAway)
                {
                    awayTeam.Points += 3;
                    awayTeam.Wins++;

                    homeTeam.Losses++;
                }

                if (gameDayMatch.GoalsHome == gameDayMatch.GoalsAway)
                {
                    homeTeam.Points += 1;
                    awayTeam.Points += 1;
                    homeTeam.Draws++;
                    awayTeam.Draws++;
                }
            }
        }

        positions = positions.OrderByDescending(x => x.Value.Points)
            .ThenByDescending(x => x.Value.Goals)
            .ThenBy(x => x.Value.Goals - x.Value.GoalsAgainst)
            .ToDictionary();

        foreach (KeyValuePair<Team, TeamContainer> tablePosition in positions)
        {
        }
        
        return new Table() { Teams = positions.Select(x => x.Value).ToList() };
    }

    private static TeamContainer GetPosition(Dictionary<Team, TeamContainer> positions, Match match, Func<Match, Team> getTeam)
    {
        var team = getTeam(match);
        if (positions.TryGetValue(team, out TeamContainer position))
        {
            return position;
        }
        
        positions.TryAdd(team, new TeamContainer { Team = getTeam(match) });
        positions.TryGetValue(team, out position!);

        return position;
    }
}
