using Loonadministratie;

namespace Loonadministratie.Tests;

public class WerknemerTests
{
    [Fact]
    public void Bediende_BerekentVastMaandsalaris()
    {
        var bediende = new Bediende("Sam", 3000m);

        Assert.Equal(3000m, bediende.BerekenMaandloon());
    }

    [Fact]
    public void Arbeider_BerekentUurloonMaalUren()
    {
        var arbeider = new Arbeider("Jamie", uurloon: 25m, gewerkteUren: 160);

        Assert.Equal(4000m, arbeider.BerekenMaandloon());
    }

    [Fact]
    public void Freelancer_BerekentDagtariefMaalDagen()
    {
        var freelancer = new Freelancer("Robin", dagtarief: 400m, gewerkteDagen: 12);

        Assert.Equal(4800m, freelancer.BerekenMaandloon());
    }

    [Fact]
    public void Freelancer_Loonstrook_ToontFreelanceLabel()
    {
        var freelancer = new Freelancer("Robin", dagtarief: 400m, gewerkteDagen: 12);

        Assert.Equal("Robin (freelance): 4800.00 euro", freelancer.Loonstrook());
    }

    [Fact]
    public void Bediende_Loonstrook_GebruiktStandaardtekst()
    {
        var bediende = new Bediende("Sam", 3000m);

        Assert.Equal("Sam: 3000.00 euro", bediende.Loonstrook());
    }

    [Fact]
    public void Werknemer_ZonderNaam_GooitFout()
    {
        Assert.Throws<ArgumentException>(() => new Bediende("  ", 3000m));
    }

    [Fact]
    public void Arbeider_MetNegatieveUren_GooitFout()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new Arbeider("Jamie", uurloon: 25m, gewerkteUren: -1));
    }
}

public class LoonverwerkerTests
{
    private static Werknemer[] MaakTeam() =>
    [
        new Bediende("Sam", 3000m),
        new Arbeider("Jamie", uurloon: 25m, gewerkteUren: 160),
        new Freelancer("Robin", dagtarief: 400m, gewerkteDagen: 12),
    ];

    [Fact]
    public void TotaleLoonkost_TeltAlleWerknemersOp()
    {
        // Polymorfisme: 3000 + (25 * 160) + (400 * 12) = 11800.
        Assert.Equal(11800m, Loonverwerker.TotaleLoonkost(MaakTeam()));
    }

    [Fact]
    public void TotaleBonus_TeltEnkelBonusgerechtigden()
    {
        // Enkel de bediende is IBonusGerechtigd: 3000 * 0,08 = 240.
        Assert.Equal(240m, Loonverwerker.TotaleBonus(MaakTeam()));
    }

    [Fact]
    public void TotaleBonus_ZonderBonusgerechtigden_IsNul()
    {
        Werknemer[] team =
        [
            new Arbeider("Jamie", uurloon: 25m, gewerkteUren: 160),
        ];

        Assert.Equal(0m, Loonverwerker.TotaleBonus(team));
    }
}
