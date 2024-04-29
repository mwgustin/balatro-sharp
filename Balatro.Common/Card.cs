namespace Balatro.Common;

public enum Suit
{
    Heart,
    Spade,
    Club,
    Diamond
}
public enum Rank
{
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}
public record PlayingCard : CardBase
{
    public PlayingCard(Rank rank, Suit suit)
    {
        Rank = rank;
        Suit = suit;
        this.Name = $"{Rank} of {Suit}";
        this.Description = $"{Rank} of {Suit} - Gives {BaseChips}";
    }

    public Rank Rank {get;init;}
    public Suit Suit {get; init;}
    
    public double BaseChips => this.Rank switch
    {
        Rank.Ace => 11,
        Rank.Two => 2,
        Rank.Three => 3,  
        Rank.Four => 4,
        Rank.Five => 5,
        Rank.Six => 6,
        Rank.Seven => 7,
        Rank.Eight => 8,
        Rank.Nine => 9,
        Rank.Ten => 10,
        Rank.Jack => 10,
        Rank.Queen => 10,
        Rank.King => 10,
        _ => 0,
    };

    public Enhancement Enhancement {get;}
    public Seal Seal {get;}
    public Edition Edition {get;}

    public Score CalculateCard(Score currentScore)
    {
        currentScore.Chips += BaseChips;

        return Enhancement switch
        {
            Enhancement.Bonus => currentScore with { Chips = currentScore.Chips + 30},
            Enhancement.Mult => currentScore with { Mult = currentScore.Mult + 4},
            Enhancement.Glass => currentScore with {Mult = currentScore.Mult * 1.5},
            _ => currentScore 
        };
    }
}
