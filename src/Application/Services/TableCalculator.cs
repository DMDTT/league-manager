using Entities.Entities;

namespace Entities.Services;
public class TableCalculator
{
    public Table Get(League league, int upToGameDay)
    {
        Dictionary<Team, TablePosition> positions = new Dictionary<Team, TablePosition>();
        for (int i = 0; i < upToGameDay; i++)
        {
            GameDay gameDay = league.GameDays[i];
            foreach (var gameDayMatch in gameDay.Matches)
            {
                if (!positions.TryGetValue(gameDayMatch.Home, out TablePosition homePosition))
                {
                    positions.TryAdd(gameDayMatch.Home, new TablePosition { Team = gameDayMatch.Home });
                    positions.TryGetValue(gameDayMatch.Home, out homePosition!);
                }

                if (!positions.TryGetValue(gameDayMatch.Away, out TablePosition awayPosition))
                {
                    positions.TryAdd(gameDayMatch.Away, new TablePosition { Team = gameDayMatch.Away });
                    positions.TryGetValue(gameDayMatch.Away, out awayPosition!);
                }

                homePosition.Goals += gameDayMatch.GoalsHome;
                homePosition.GoalsAgainst += gameDayMatch.GoalsAway;
                
                awayPosition.Goals += gameDayMatch.GoalsAway;
                awayPosition.GoalsAgainst += gameDayMatch.GoalsHome;

                if (gameDayMatch.GoalsHome > gameDayMatch.GoalsAway)
                {
                    homePosition.Wins++;
                    homePosition.Points += 3;

                    awayPosition.Losses++;
                }

                if (gameDayMatch.GoalsHome < gameDayMatch.GoalsAway)
                {
                    awayPosition.Points += 3;
                    awayPosition.Wins++;

                    homePosition.Losses++;
                }

                if (gameDayMatch.GoalsHome == gameDayMatch.GoalsAway)
                {
                    homePosition.Points += 1;
                    awayPosition.Points += 1;
                    homePosition.Draws++;
                    awayPosition.Draws++;
                }
            }
        }

        positions = positions.OrderByDescending(x => x.Value.Points)
            .ThenByDescending(x => x.Value.Goals)
            .ThenBy(x => x.Value.Goals - x.Value.GoalsAgainst)
            .ToDictionary();

        foreach (KeyValuePair<Team, TablePosition> tablePosition in positions)
        {
        }
        
        return new Table() { Positions = positions.Select(x => x.Value).ToList() };
    }
}
