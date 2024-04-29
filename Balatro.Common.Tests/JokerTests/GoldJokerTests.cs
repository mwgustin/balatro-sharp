
namespace Balatro.Common.Tests.JokerTests;
public class GoldJokerTests
{
    [Fact]
    public async Task CalculateHandTest()
    {
        // arr
        var state = new GameState();
        state.CurrentScore = new Score()
        {
            Chips = 100,
            Mult = 50
        };;

        var joker = new GoldJoker();
    
        // act

        joker.CalculateHand(state);
    
        // assrt
        Assert.Equal(new Score() { Chips = 100, Mult = 50 }, state.CurrentScore);
        await Verify(state);

    }

    [Theory]
    [InlineData(0, 4)]
    [InlineData(5, 9)]
    [InlineData(Double.MaxValue, Double.MaxValue)]
    public void CalculateStartRoundTests(double startingMoney, double expected)
    {
        // arr
        var state = new GameState();
        
        state.Money = startingMoney;

        var joker = new GoldJoker();
    
        // act

        joker.CalculateStartRound(state);
    
        // assrt
        Assert.Equal(expected, state.Money);
    }

    [Theory]
    [InlineData(0, 4)]
    [InlineData(5, 9)]
    [InlineData(Double.MaxValue, Double.MaxValue)]
    public void CalculateEndRoundTests(double startingMoney, double expected)
    {
        // arr
        var state = new GameState();
        
        state.Money = startingMoney;

        var joker = new GoldJoker();
    
        // act

        joker.CalculateEndRound(state);
    
        // assrt
        Assert.Equal(expected, state.Money);
    }
}