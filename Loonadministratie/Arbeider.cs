namespace Loonadministratie;

/// <summary>
/// Een arbeider die per gewerkt uur betaald wordt.
/// </summary>
public class Arbeider : Werknemer
{
    private readonly decimal _uurloon;
    private readonly int _gewerkteUren;

    public Arbeider(string naam, decimal uurloon, int gewerkteUren) : base(naam)
    {
        if (uurloon < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(uurloon), "Uurloon kan niet negatief zijn.");
        }

        if (gewerkteUren < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(gewerkteUren), "Gewerkte uren kunnen niet negatief zijn.");
        }

        _uurloon = uurloon;
        _gewerkteUren = gewerkteUren;
    }

    public override decimal BerekenMaandloon() => _uurloon * _gewerkteUren;
}
