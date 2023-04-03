using majumi.CarService.MechanicsDataService.Model;
using System.Text.Json;

namespace majumi.CarService.MechanicsDataService.Logic;

public class MechanicCollectionReader
{
    public static Mechanic[] ReadFromJSON(string path) {
        return JsonSerializer.Deserialize<Mechanic[]>(File.ReadAllText(path));
    }
}
