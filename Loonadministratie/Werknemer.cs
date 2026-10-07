using System.Globalization;

namespace Loonadministratie;

/// <summary>
/// Abstracte base class voor elke soort werknemer. Ze legt vast wat elke
/// werknemer moet kunnen (een maandloon berekenen), zonder dat al in te vullen.
/// Je kan geen Werknemer rechtstreeks aanmaken; enkel een concrete afgeleide.
/// </summary>
public abstract class Werknemer
{
    // protected: enkel aanroepbaar vanuit afgeleide klassen via base(...).
    protected Werknemer(string naam)
    {
        if (string.IsNullOrWhiteSpace(naam))
        {
            throw new ArgumentException("Naam is verplicht.", nameof(naam));
        }

        Naam = naam;
    }

    public string Naam { get; }

    // Abstracte method: geen body. Elke afgeleide klasse moet ze invullen.
    public abstract decimal BerekenMaandloon();

    // Virtual method: er is een standaardtekst, maar een afgeleide klasse
    // mag ze overschrijven.
    public virtual string Loonstrook() =>
        $"{Naam}: {BerekenMaandloon().ToString("0.00", CultureInfo.InvariantCulture)} euro";
}

/// <summary>
/// Markeert een werknemer die recht heeft op een bonus. Niet elke werknemer
/// implementeert deze interface, dus we testen ze met een type check.
/// </summary>
public interface IBonusGerechtigd
{
    decimal BerekenBonus();
}
