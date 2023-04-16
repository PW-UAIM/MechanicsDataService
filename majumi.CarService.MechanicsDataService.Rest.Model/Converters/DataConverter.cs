using majumi.CarService.MechanicsDataService.Model;
using majumi.CarService.MechanicsDataService.Rest.Model.Model;

namespace majumi.CarService.MechanicsDataService.Rest.Model.Converters;

public static class DataConverter
{
    public static MechanicData ConvertToMechanicData(this Mechanic mechanic)
    {
        return new MechanicData
        {
            MechanicID = mechanic.MechanicID,
            Name = mechanic.Name,
            Surname = mechanic.Surname,
            BirthDate = mechanic.BirthDate,
            HireDate = mechanic.HireDate,
            Specialty = mechanic.Specialty,
            VacationDays = mechanic.VacationDays,
            Address = mechanic.Address,
            Phone = mechanic.Phone,
            Email = mechanic.Email
        };
    }

    public static List<MechanicData> ConvertToMechanicDataList(List<Mechanic> mechanics)
    {
        List<MechanicData> mechanicData = new();

        foreach (Mechanic m in mechanics)
        {
            mechanicData.Add(ConvertToMechanicData(m));
        }

        return mechanicData;
    }
}