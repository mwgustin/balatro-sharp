namespace Balatro.Common.Tests;

public class UnitTest1
{
    [Fact]
    public void TestNormalHand()
    {
        //arrange
        var state = new GameState();
        state.PlayedCards.AddRange([
            new Card() { ChipValue = 5 },
            new Card() { ChipValue = 6 },
            new Card() { ChipValue = 7 },
            new Card() { ChipValue = 8 },
            new Card() { ChipValue = 9 }
        ]);
        //act
        var result = state.RunHand();
        //assert
        Assert.Equal(2700, result);
    }
    [Fact]
    public void TestHandWith5Joker()
    {
        //arrange
        var state = new GameState();
        state.PlayedCards.AddRange([
            new Card() { ChipValue = 5 },
            new Card() { ChipValue = 6 },
            new Card() { ChipValue = 7 },
            new Card() { ChipValue = 8 },
            new Card() { ChipValue = 9 }
        ]);
        state.Jokers.Add(new Test5Joker());
        //act
        var result = state.RunHand();
        //assert
        Assert.Equal(3375, result);
    }
    [Fact]
    public void TestHandWithMultipleJoker()
    {
        //arrange
        var state = new GameState();
        state.PlayedCards.AddRange([
            new Card() { ChipValue = 5 },
            new Card() { ChipValue = 6 },
            new Card() { ChipValue = 7 },
            new Card() { ChipValue = 8 },
            new Card() { ChipValue = 9 }
        ]);
        state.Jokers.Add(new Test5Joker());
        state.Jokers.Add(new Testx5Joker());
        //act
        var result = state.RunHand();
        //assertb
        Assert.Equal(16875, result);
    }
    [Fact]
    public void TestHandWithJokersSwapped()
    {
        //arrange
        var state = new GameState();
        state.PlayedCards.AddRange([
            new Card() { ChipValue = 5 },
            new Card() { ChipValue = 6 },
            new Card() { ChipValue = 7 },
            new Card() { ChipValue = 8 },
            new Card() { ChipValue = 9 }
        ]);
        state.Jokers.Add(new Testx5Joker());
        state.Jokers.Add(new Test5Joker());
        //act
        var result = state.RunHand();
        //assert
        Assert.Equal(14175, result);
    }

    [Fact]
    public void TestHandWithReplayJoker()
    {
        //arrange
        var state = new GameState();
        state.PlayedCards.AddRange([
            new Card() { ChipValue = 5 },
            new Card() { ChipValue = 6 },
            new Card() { ChipValue = 7 },
            new Card() { ChipValue = 8 },
            new Card() { ChipValue = 9 }
        ]);
        state.Jokers.Add(new Testx5Joker());
        state.Jokers.Add(new Test5Joker());
        state.Jokers.Add(new TestReplayJoker());
        //act
        var result = state.RunHand();
        //assert
        Assert.Equal(70875, result);
    }

    [Fact]
    public void TestHandWithOnlyReplayJoker()
    {
        //arrange
        var state = new GameState();
        state.PlayedCards.AddRange([
            new Card() { ChipValue = 5 },
            new Card() { ChipValue = 6 },
            new Card() { ChipValue = 7 },
            new Card() { ChipValue = 8 },
            new Card() { ChipValue = 9 }
        ]);
        state.Jokers.Add(new TestReplayJoker());
        //act
        var result = state.RunHand();
        //assert
        Assert.Equal(2700, result);
    }
}