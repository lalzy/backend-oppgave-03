namespace kalk.tests;

public class UnitTest1
{
    [Fact]
    public void TestNevner()
    {
        Assert.False(Kalkulator.ErNevner('s'));
        Assert.True(Kalkulator.ErNevner('+'));
    }

    [Fact]
    public void TestArithmetic(){
        Assert.Equal(6, Kalkulator.Mult(3, 2));
        Assert.Equal(3, Kalkulator.Div(6, 2));
    }

    [Fact]
    public void TestKalkulererSetter(){
        List<String> numSequence = new List<string>{"2", "*", "2"};
        Console.WriteLine(Kalkulator.MulDivCheck(numSequence));
        int res = int.Parse(numSequence[0]);
        // int.TryParse(numSequence[0], out int res);
        Assert.Equal(4, res);
        
        numSequence = new List<string>{"4", "/", "2"};
        Console.WriteLine(Kalkulator.MulDivCheck(numSequence));
        res = int.Parse(numSequence[0]);
        Assert.Equal(2, res);
    }

    [Fact]
    public void TestKalkuler(){
        Assert.Equal(5, Kalkulator.Kalkuler("2 + 1 * 3"));
    }

    [Fact]
    public void TestParseInput(){
        List<string> res = Kalkulator.ParseInput("2 * 3 / 4");
        Assert.Equal("2", res[0]);
        Assert.Equal("*", res[1]);
        Assert.Equal("3", res[2]);
        Assert.Equal("/", res[3]);
        Assert.Equal("4", res[4]);
    }

    [Fact]
    public void TestGetNum(){
        Assert.Equal(4, Kalkulator.GetNum("4"));
    }
}