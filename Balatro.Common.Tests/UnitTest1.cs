namespace Balatro.Common.Tests;

public class UnitTest1
{
    [Fact]
    public void TestNormalHand()
    {
        //arrange
        var state = new GameState();
        state.PlayedCards.AddRange([
            new PlayingCard(Rank.Five, Suit.Heart),
            new PlayingCard(Rank.Six, Suit.Heart),
            new PlayingCard(Rank.Seven, Suit.Heart),
            new PlayingCard(Rank.Eight, Suit.Heart),
            new PlayingCard(Rank.Nine, Suit.Heart),
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
            new PlayingCard(Rank.Five, Suit.Heart),
            new PlayingCard(Rank.Six, Suit.Heart),
            new PlayingCard(Rank.Seven, Suit.Heart),
            new PlayingCard(Rank.Eight, Suit.Heart),
            new PlayingCard(Rank.Nine, Suit.Heart),
        ]);
        state.Jokers.Add(new Joker5());
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
            new PlayingCard(Rank.Five, Suit.Heart),
            new PlayingCard(Rank.Six, Suit.Heart),
            new PlayingCard(Rank.Seven, Suit.Heart),
            new PlayingCard(Rank.Eight, Suit.Heart),
            new PlayingCard(Rank.Nine, Suit.Heart),
        ]);
        state.Jokers.Add(new Joker5());
        state.Jokers.Add(new JokerX5());
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
            new PlayingCard(Rank.Five, Suit.Heart),
            new PlayingCard(Rank.Six, Suit.Heart),
            new PlayingCard(Rank.Seven, Suit.Heart),
            new PlayingCard(Rank.Eight, Suit.Heart),
            new PlayingCard(Rank.Nine, Suit.Heart),
        ]);
        state.Jokers.Add(new JokerX5());
        state.Jokers.Add(new Joker5());
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
            new PlayingCard(Rank.Five, Suit.Heart),
            new PlayingCard(Rank.Six, Suit.Heart),
            new PlayingCard(Rank.Seven, Suit.Heart),
            new PlayingCard(Rank.Eight, Suit.Heart),
            new PlayingCard(Rank.Nine, Suit.Heart),
        ]);
        state.Jokers.Add(new JokerX5());
        state.Jokers.Add(new Joker5());
        state.Jokers.Add(new ReplayJoker());
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
            new PlayingCard(Rank.Five, Suit.Heart),
            new PlayingCard(Rank.Six, Suit.Heart),
            new PlayingCard(Rank.Seven, Suit.Heart),
            new PlayingCard(Rank.Eight, Suit.Heart),
            new PlayingCard(Rank.Nine, Suit.Heart),
        ]);
        state.Jokers.Add(new ReplayJoker());
        //act
        var result = state.RunHand();
        //assert
        Assert.Equal(2700, result);
    }
}