using workshop.calculator;

namespace workshop.tests;

public class CalculatorServiceTests
{
    

    [TestCase(1,2,3)]
    public void AddTests(int a, int b, int expectedResult)
    {
        //arrange
        CalculatorService service = new CalculatorService();

        //act
        int result = service.Add(a, b);

        //assert
        Assert.That(result, Is.EqualTo(expectedResult));



    }
}
