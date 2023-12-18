using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities;
using Entities.Services;

namespace Application.Tests;
public class L98ToLeagueTest
{
    [Fact]
    public void Should_Convert_L98_File_To_League()
    {
        League result = L98ToLeague.Migrate("test.l98");

        Assert.Multiple(
            () => Assert.Equal("Liga", result.Title),
            () => Assert.Equal(4, result.Teams.Count),
            () => Assert.Equal("Barcelona", result.Teams[0].Code),
            () => Assert.Equal("Madrid", result.Teams[1].Code),
            () => Assert.Equal("Valencia", result.Teams[2].Code),
            () => Assert.Equal("Villareal", result.Teams[3].Code),
            () => Assert.Equal(6, result.GameDays.Count),

            // Round1
            () => Assert.Equal("Barcelona", result.GameDays[0].Matches[0].Home.Code),
            () => Assert.Equal(1, result.GameDays[0].Matches[0].GoalsHome),
            () => Assert.Equal("Madrid", result.GameDays[0].Matches[0].Away.Code),
            () => Assert.Equal(2, result.GameDays[0].Matches[0].GoalsAway),

            () => Assert.Equal("Valencia", result.GameDays[0].Matches[1].Home.Code),
            () => Assert.Equal(5, result.GameDays[0].Matches[1].GoalsHome),
            () => Assert.Equal("Villareal", result.GameDays[0].Matches[1].Away.Code),
            () => Assert.Equal(0, result.GameDays[0].Matches[1].GoalsAway),

            // Round2
            () => Assert.Equal("Valencia", result.GameDays[1].Matches[0].Home.Code),
            () => Assert.Equal(0, result.GameDays[1].Matches[0].GoalsHome),
            () => Assert.Equal("Barcelona", result.GameDays[1].Matches[0].Away.Code),
            () => Assert.Equal(3, result.GameDays[1].Matches[0].GoalsAway),

            () => Assert.Equal("Villareal", result.GameDays[1].Matches[1].Home.Code),
            () => Assert.Equal(1, result.GameDays[1].Matches[1].GoalsHome),
            () => Assert.Equal("Madrid", result.GameDays[1].Matches[1].Away.Code),
            () => Assert.Equal(1, result.GameDays[1].Matches[1].GoalsAway),

            // Round3
            () => Assert.Equal("Barcelona", result.GameDays[2].Matches[0].Home.Code),
            () => Assert.Equal(3, result.GameDays[2].Matches[0].GoalsHome),
            () => Assert.Equal("Villareal", result.GameDays[2].Matches[0].Away.Code),
            () => Assert.Equal(1, result.GameDays[2].Matches[0].GoalsAway),

            () => Assert.Equal("Madrid", result.GameDays[2].Matches[1].Home.Code),
            () => Assert.Equal(2, result.GameDays[2].Matches[1].GoalsHome),
            () => Assert.Equal("Valencia", result.GameDays[2].Matches[1].Away.Code),
            () => Assert.Equal(0, result.GameDays[2].Matches[1].GoalsAway),

            // Round4
            () => Assert.Equal("Madrid", result.GameDays[3].Matches[0].Home.Code),
            () => Assert.Equal(2, result.GameDays[3].Matches[0].GoalsHome),
            () => Assert.Equal("Barcelona", result.GameDays[3].Matches[0].Away.Code),
            () => Assert.Equal(2, result.GameDays[3].Matches[0].GoalsAway),

            () => Assert.Equal("Villareal", result.GameDays[3].Matches[1].Home.Code),
            () => Assert.Equal(0, result.GameDays[3].Matches[1].GoalsHome),
            () => Assert.Equal("Valencia", result.GameDays[3].Matches[1].Away.Code),
            () => Assert.Equal(0, result.GameDays[3].Matches[1].GoalsAway),

            // Round5
            () => Assert.Equal("Barcelona", result.GameDays[4].Matches[0].Home.Code),
            () => Assert.Equal(0, result.GameDays[4].Matches[0].GoalsHome),
            () => Assert.Equal("Valencia", result.GameDays[4].Matches[0].Away.Code),
            () => Assert.Equal(3, result.GameDays[4].Matches[0].GoalsAway),

            () => Assert.Equal("Madrid", result.GameDays[4].Matches[1].Home.Code),
            () => Assert.Equal(4, result.GameDays[4].Matches[1].GoalsHome),
            () => Assert.Equal("Villareal", result.GameDays[4].Matches[1].Away.Code),
            () => Assert.Equal(0, result.GameDays[4].Matches[1].GoalsAway),

            // Round5
            () => Assert.Equal("Valencia", result.GameDays[5].Matches[0].Home.Code),
            () => Assert.Equal(1, result.GameDays[5].Matches[0].GoalsHome),
            () => Assert.Equal("Madrid", result.GameDays[5].Matches[0].Away.Code),
            () => Assert.Equal(4, result.GameDays[5].Matches[0].GoalsAway),

            () => Assert.Equal("Villareal", result.GameDays[5].Matches[1].Home.Code),
            () => Assert.Equal(5, result.GameDays[5].Matches[1].GoalsHome),
            () => Assert.Equal("Barcelona", result.GameDays[5].Matches[1].Away.Code),
            () => Assert.Equal(3, result.GameDays[5].Matches[1].GoalsAway)
            );
    }
}
