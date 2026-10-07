namespace Loonadministratie;

/// <summary>
/// Verwerkt een lijst van werknemers. Hier zie je polymorfisme in actie: de
/// verwerker werkt met Werknemer en hoeft niet te weten welk soort werknemer
/// het precies is.
/// </summary>
public static class Loonverwerker
{
    // We roepen BerekenMaandloon() aan op elke Werknemer. Elk object weet zelf
    // welke implementatie het moet uitvoeren.
    public static decimal TotaleLoonkost(IEnumerable<Werknemer> werknemers)
    {
        decimal totaal = 0m;
        foreach (Werknemer werknemer in werknemers)
        {
            totaal += werknemer.BerekenMaandloon();
        }

        return totaal;
    }

    // Enkel werknemers die IBonusGerechtigd implementeren, tellen mee. We
    // herkennen ze met een type check (is met een patroon).
    public static decimal TotaleBonus(IEnumerable<Werknemer> werknemers)
    {
        decimal totaal = 0m;
        foreach (Werknemer werknemer in werknemers)
        {
            if (werknemer is IBonusGerechtigd gerechtigd)
            {
                totaal += gerechtigd.BerekenBonus();
            }
        }

        return totaal;
    }
}
