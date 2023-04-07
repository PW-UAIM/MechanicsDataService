using System.Text.Json;
using majumi.CarService.MechanicsDataService.Model;

namespace majumi.CarService.MechanicsDataService.Logic;

public class MechanicCollectionReader
{
    public static Mechanic[]? ReadFromJSON(string path) {
        return JsonSerializer.Deserialize<Mechanic[]>(File.ReadAllText(path));
    }
}
