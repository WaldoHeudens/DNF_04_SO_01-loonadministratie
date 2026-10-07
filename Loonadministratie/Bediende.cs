namespace Loonadministratie;

/// <summary>
/// Een bediende met een vast maandsalaris. Implementeert naast de overerving
/// van Werknemer ook de interface IBonusGerechtigd.
/// </summary>
public class Bediende : Werknemer, IBonusGerechtigd
{
    private readonly decimal _maandsalaris;

    public Bediende(string naam, decimal maandsalaris) : base(naam)
    {
        if (maandsalaris < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(maandsalaris), "Maandsalaris kan niet negatief zijn.");
        }

        _maandsalaris = maandsalaris;
    }

    // override: we vullen de abstracte method uit Werknemer in.
    public override decimal BerekenMaandloon() => _maandsalaris;

    // Een bediende krijgt 8 procent van het maandsalaris als bonus.
    public decimal BerekenBonus() => _maandsalaris * 0.08m;
}
