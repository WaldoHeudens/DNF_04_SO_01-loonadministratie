using System.Globalization;
using Loonadministratie;

// We bewaren verschillende soorten werknemers samen als Werknemer.
Werknemer[] team =
[
    new Bediende("Sam", 3000m),
    new Arbeider("Jamie", uurloon: 25m, gewerkteUren: 160),
    new Freelancer("Robin", dagtarief: 400m, gewerkteDagen: 12),
];

// Polymorfisme: elke werknemer weet zelf hoe zijn loonstrook eruitziet.
foreach (Werknemer werknemer in team)
{
    Console.WriteLine(werknemer.Loonstrook());
}

decimal loonkost = Loonverwerker.TotaleLoonkost(team);
decimal bonus = Loonverwerker.TotaleBonus(team);
Console.WriteLine($"Totale loonkost: {loonkost.ToString("0.00", CultureInfo.InvariantCulture)} euro");
Console.WriteLine($"Totale bonus: {bonus.ToString("0.00", CultureInfo.InvariantCulture)} euro");
