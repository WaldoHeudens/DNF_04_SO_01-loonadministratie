using System.Globalization;

namespace Loonadministratie;

/// <summary>
/// Een freelancer die per gewerkte dag een dagtarief aanrekent.
/// sealed: van deze klasse kan je niet verder overerven.
/// </summary>
public sealed class Freelancer : Werknemer
{
    private readonly decimal _dagtarief;
    private readonly int _gewerkteDagen;

    public Freelancer(string naam, decimal dagtarief, int gewerkteDagen) : base(naam)
    {
        if (dagtarief < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(dagtarief), "Dagtarief kan niet negatief zijn.");
        }

        if (gewerkteDagen < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(gewerkteDagen), "Gewerkte dagen kunnen niet negatief zijn.");
        }

        _dagtarief = dagtarief;
        _gewerkteDagen = gewerkteDagen;
    }

    public override decimal BerekenMaandloon() => _dagtarief * _gewerkteDagen;

    // We overschrijven de virtual method uit Werknemer met een eigen tekst.
    public override string Loonstrook() =>
        $"{Naam} (freelance): {BerekenMaandloon().ToString("0.00", CultureInfo.InvariantCulture)} euro";
}
