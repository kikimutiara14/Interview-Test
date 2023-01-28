namespace EngineerTest;

public class Pharmacy : IPharmacy
{
    private readonly IDrug[] _drugs;

    public Pharmacy(IEnumerable<IDrug> drugs)
    {
        _drugs = drugs.ToArray();
    }

    public IEnumerable<IDrug> UpdateBenefitValue()
    {
        foreach (var drug in _drugs)
        {
            if (drug.Name == "Magic Pill") continue;
            if (drug.Name is "Herbal Tea" or "Fervex")
            {
                drug.Benefit++;
            }
            else
            {
                if (drug.Name == "Dafalgan")
                {
                    drug.Benefit--;
                }
                drug.Benefit--;
            }

            if (drug is { ExpiresIn: < 11, Name: "Fervex" })
            {
                drug.Benefit++;
            }
                
            if (drug is { ExpiresIn: < 6, Name: "Fervex" })
            {
                drug.Benefit++;
            }

            drug.ExpiresIn--;

            if (drug.ExpiresIn < 0)
            {
                if (drug.Name == "Herbal Tea")
                {
                    drug.Benefit++;
                }
                else if (drug.Name == "Fervex")
                {
                    drug.Benefit = 0;
                }
                else
                {
                    if (drug.Name == "Dafalgan")
                    {
                        drug.Benefit--;
                    }
                    drug.Benefit--;
                }
            }

            // Set Benefit to it's outer bound if it goes out of it
            if (drug.Benefit < 0) drug.Benefit = 0;
            if (drug.Benefit > 50) drug.Benefit = 50;
        }

        return _drugs;
    }
}