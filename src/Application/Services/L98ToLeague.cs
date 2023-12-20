using System.Text.RegularExpressions;
using Application.Entities;
using static System.Collections.Specialized.BitVector32;
using Match = Application.Entities.Match;

namespace Entities.Services;
public class L98ToLeague
{
    private const string OptionsSection = "[Options]";
    
    private const string TeamsSection = "[Teams]";
    private const string EndSection = "--EndSection--";
    public static League Migrate(string path)
    {
        string content = File.ReadAllText(path).ReplaceLineEndings("###").Replace("######", EndSection); // replace emptyline with endsection
        League league = new League();
        TempOptions tempOptions = new TempOptions();
        IList<string> sections = content.Split(EndSection).ToList();
        ProcessOptions(sections.FirstOrDefault(x => x.StartsWith(OptionsSection)) + "###", league, tempOptions);
        ProcessTeams(sections.FirstOrDefault(x => x.StartsWith(TeamsSection)) + "###", league, tempOptions);

        for (int i = 1; i <= tempOptions.RoundsCount; i++)
        {
            ProcessGameDay(sections.FirstOrDefault(x => x.StartsWith($"[Round{i}]")), league, tempOptions, i);
        }

        return league;
    }

    private static string ProcessOptions(string content, League league, TempOptions tempOptions)
    {
        string relevantContent = content;

        //get name of league
        System.Text.RegularExpressions.Match m = Regex.Match(relevantContent, "Name=(.*?)###");
        if (m.Success)
        {
            league.Title = m.Groups[1].Value;
        }

        m = Regex.Match(relevantContent, "Teams=(.*?)###");
        if (m.Success)
        {
            tempOptions.TeamCount = Convert.ToInt32(m.Groups[1].Value);
        }

        m = Regex.Match(relevantContent, "Rounds=(.*?)###");
        if (m.Success)
        {
            tempOptions.RoundsCount = Convert.ToInt32(m.Groups[1].Value);
        }

        m = Regex.Match(relevantContent, "Matches=(.*?)###");
        if (m.Success)
        {
            tempOptions.MatchCount = Convert.ToInt32(m.Groups[1].Value);
        }

        return content.Replace(relevantContent + EndSection, string.Empty);
    }

    private static string ProcessTeams(string content, League league, TempOptions tempOptions)
    {
        string relevantContent = content;

        for (int i = 1; i <= tempOptions.TeamCount; i++)
        {
            System.Text.RegularExpressions.Match m = Regex.Match(relevantContent, $"{i}=(.*?)(###|{EndSection})");
            if (m.Success)
            {
                league.Teams.Add(new TempTeam() { Code = m.Groups[1].Value, TempId = i });
            }
        }

        return content.Replace(relevantContent + EndSection, string.Empty);
    }

    private static void ProcessGameDay(string content, League league, TempOptions tempOptions, int round)
    {
        var gameDay = new GameDay() { League = league, Day = round};
        league.GameDays.Add(gameDay);
        for (int matchIndex = 1; matchIndex <= tempOptions.MatchCount; matchIndex++)
        {
            TempTeam home = null;
            TempTeam away = null;
            int? goalsHome = null;
            int? goalsAway = null;
            System.Text.RegularExpressions.Match m = Regex.Match(content, $"TA{matchIndex}=(.*?)###");
            if (m.Success)
            {
                home = league.Teams.First(x => (x as TempTeam).TempId == Convert.ToInt32(m.Groups[1].Value)) as TempTeam;
            }

            m = Regex.Match(content, $"GA{matchIndex}=(.*?)###");
            if (m.Success)
            {
                goalsHome = Convert.ToInt32(m.Groups[1].Value);
            }

            m = Regex.Match(content, $"TB{matchIndex}=(.*?)###");
            if (m.Success)
            {
                away = league.Teams.First(x => (x as TempTeam).TempId == Convert.ToInt32(m.Groups[1].Value)) as TempTeam;
            }

            m = Regex.Match(content, $"GA{matchIndex}=(.*?)###");
            if (m.Success)
            {
                goalsHome = Convert.ToInt32(m.Groups[1].Value);
            }

            m = Regex.Match(content, $"GB{matchIndex}=(.*?)###");
            if (m.Success)
            {
                goalsAway = Convert.ToInt32(m.Groups[1].Value);
            }

            gameDay.Matches ??= new List<Match>();
            gameDay.Matches.Add(new Match() { GameDay = gameDay, Home = home, Away = away, GoalsHome = goalsHome, GoalsAway = goalsAway });
        }
    }

    private class TempTeam : Team
    {
        public int TempId { get; set; }
    }

    private class TempOptions
    {
        public int TeamCount { get; set; }
        public int RoundsCount { get; set; }
        public int MatchCount { get; set; }
    }
}
