using EngineerTest;
using Xunit;

namespace EngineerTestTest;

public class PharmacyTest
{
    [Fact]
    public void TestShouldDecreaseBenefitAndExpiresIn()
    {
        Assert.Equal(new Drug[] { new Drug("test", 1, 2)}, 
            new Pharmacy(new Drug[] { new Drug("test", 2, 3)}).UpdateBenefitValue());
    }
    
    [Fact]
    public void HerbalTeaShouldIncreaseBenefitAndDecreaseExpiresIn()
    {
        Assert.Equal(new Drug[] { new Drug("Herbal Tea", 1, 4)}, 
            new Pharmacy(new Drug[] { new Drug("Herbal Tea", 2, 3)}).UpdateBenefitValue());
    }
    
    [Fact]
    public void MagicPillShouldStayTheSame()
    {
        Assert.Equal(new Drug[] { new Drug("Magic Pill", 2, 3)}, 
            new Pharmacy(new Drug[] { new Drug("Magic Pill", 2, 3)}).UpdateBenefitValue());
    }
    
    [Fact]
    public void FervexShouldIncreaseInBenefits()
    {
        Assert.Equal(new Drug[] { new Drug("Fervex", 33, 4)}, 
            new Pharmacy(new Drug[] { new Drug("Fervex", 34, 3)}).UpdateBenefitValue());
    }
    
    [Fact]
    public void FervexShouldIncreaseInBenefitsByTwoWhenTenDaysOrLess()
    {
        Assert.Equal(new Drug[] { new Drug("Fervex", 6, 5)}, 
            new Pharmacy(new Drug[] { new Drug("Fervex", 7, 3)}).UpdateBenefitValue());
    }
    
    [Fact]
    public void FervexShouldIncreaseInBenefitsByThreeWhenFiveDaysOrLess()
    {
        Assert.Equal(new Drug[] { new Drug("Fervex", 3, 6)}, 
            new Pharmacy(new Drug[] { new Drug("Fervex", 4, 3)}).UpdateBenefitValue());
    }
    
    [Fact]
    public void FervexShouldHaveNoBenefitsAfterExpirationDate()
    {
        Assert.Equal(new Drug[] { new Drug("Fervex", -1, 0)}, 
            new Pharmacy(new Drug[] { new Drug("Fervex", 0, 3)}).UpdateBenefitValue());
    }
    
    [Fact]
    public void DafalganShouldDecreaseBenefitAndExpiresIn()
    {
        Assert.Equal(new Drug[] { new Drug("Dafalgan", 1, 1)}, 
            new Pharmacy(new Drug[] { new Drug("Dafalgan", 2, 3)}).UpdateBenefitValue());
    }
}