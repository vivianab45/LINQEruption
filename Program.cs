

using System.Diagnostics.Tracing;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
//-----------Usee LINQ to find the first eruption that is in Chile and print the result.-----------------///
///all volcanos by descending year
// List <Eruption> OldToYoung = eruptions.OrderBy(t=>t.Year).ToList();
// OldToYoung.ForEach(Console.WriteLine);
List <Eruption> OldestChile = eruptions.OrderBy(t=>t.Year).Where(c=>c.Location=="Chile").Take(1).ToList();
OldestChile.ForEach(Console.WriteLine);


//----------Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."----------///
Eruption? firstHawaiian= eruptions.FirstOrDefault(p=>p.Location == "Hawaiian Is");
if (firstHawaiian == null)
{
    Console.WriteLine("No Greenland Eruption");
} else{
    Console.WriteLine(firstHawaiian);
}
//----------Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."---------------///
Eruption? GreenLand=eruptions.FirstOrDefault(c=> c.Location=="Greenland");
if (GreenLand==null)
{
    Console.WriteLine("No Greenland Eruption");
}



//----------Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
List<Eruption>first1900Nz = eruptions.Where(t=>t.Year >= 1900).ToList();
first1900Nz.ForEach(Console.WriteLine);


//---------Find all eruptions where the volcano's elevation is over 2000m and print them.------------------///
List<Eruption> over2000 = eruptions.Where(t=>t.ElevationInMeters >= 2000).ToList();
over2000.ForEach(Console.WriteLine);

//---------Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.----//

List <Eruption> nameWithL= eruptions.Where(t=>t.Volcano.StartsWith("L")).ToList();
nameWithL.ForEach(Console.WriteLine);


//---------Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)------------------/////
int maxElev = eruptions.Max(c=>c.ElevationInMeters);
Console.WriteLine(maxElev);


//---------Use the highest elevation variable to find and print the name of the Volcano with that elevation.-------------//


List<string> highestVolcano= eruptions.Where(c=>c.ElevationInMeters==maxElev).Select(c=>c.Volcano).ToList();
 highestVolcano.ForEach(Console.WriteLine);

//--------Print all Volcano names alphabetically.----------------------------------------------------------------------//
 List <string> alphaOrder = eruptions.OrderBy(c=>c.Volcano).Select(c=>c.Volcano).ToList();
 alphaOrder.ForEach(Console.WriteLine);

//--------Print the sum of all the elevations of the volcanoes combined.------------------------------------------------//
int sumElevations = eruptions.Sum(c=>c.ElevationInMeters);
Console.WriteLine(sumElevations);


//--------Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)---------------------------//

bool Erupted2000= eruptions.Any(c=>c.Year==2000);
Console.WriteLine($"Did any volcanos errupt in the year 2000?{Erupted2000}");


//--------Find all stratovolcanoes and print just the first three (Hint: look up Take)--------------------------------//
List <Eruption> stratovolcanoEruptions = eruptions.Where(c=>c.Type=="Stratovolcano").Take(3).ToList();
stratovolcanoEruptions.ForEach(Console.WriteLine);

//--------Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.------//
List<Eruption> before1000 = eruptions.OrderBy(t=>t.Volcano).Where(t=>t.Year <= 1000).ToList();
before1000.ForEach(Console.WriteLine);

//--------Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.

List<string> before1000Names = eruptions.OrderBy(t=>t.Volcano).Where(t=>t.Year <= 1000).Select(t=>t.Location).ToList();
before1000Names.ForEach(Console.WriteLine);


// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
// static void PrintEach(IEnumerable<Eruption> items, string msg = "")
// {
//     Console.WriteLine("\n" + msg);
//     foreach (Eruption item in items)
//     {
//         Console.WriteLine(item.ToString());
//     }
// }



