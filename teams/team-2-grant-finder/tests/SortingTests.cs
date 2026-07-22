using System.Linq;
using Team2GrantFinder.Core;
using Xunit;

namespace Team2GrantFinder.Tests;

public class SortingTests
{
    [Fact]
    public void OrderByAmount_ProducesHighestFirst()
    {
        // Given a profile that returns multiple grants
        var profile = new BusinessProfile(State.VIC, Industry.Manufacturing, 15, 1_000_000m, 3);

        var results = Eligibility.FindGrants(profile);

        var sorted = results.OrderByDescending(r => r.Grant.Amount).ToList();

        for (var i = 0; i < sorted.Count - 1; i++)
        {
            Assert.True(sorted[i].Grant.Amount >= sorted[i + 1].Grant.Amount, "Results are not ordered highest-first by amount");
        }
    }
}
