namespace Balatro.Common;

public record Score
{
    public double Chips {get;set;}
    public double Mult {get;set;}
}

public class Consumable
{
}
public enum Enhancement
{
    None,
    Bonus,
    Mult,
    Wild,
    Glass,
    Steel,
    Gold,
    Lucky
}
public enum Edition
{
    None,
    Foil,
    Holo,
    Poly,
    Negative
}
public enum Seal
{
    None,
    Gold,
    Red,
    Blue,
    Purple
}

public record Card
{
    public double ChipValue {get; init;}
    public Enhancement Enhancement {get;}
    public Seal Seal {get;}
    public Edition Edition {get;}

    public Score CalculateCard(Score currentScore)
    {
        currentScore.Chips += ChipValue;

        return Enhancement switch
        {
            Enhancement.Bonus => currentScore with { Chips = currentScore.Chips + 30},
            Enhancement.Mult => currentScore with { Mult = currentScore.Mult + 4},
            Enhancement.Glass => currentScore with {Mult = currentScore.Mult * 1.5},
            _ => currentScore 
        };
    }
}

public record GameState
{
    public List<IJoker> Jokers {get;set;} = new();
    public Score CurrentScore {get;set;} = new();
    public List<Card> PlayedCards {get;set;} = new();
    public List<Card> HeldCards {get;set;} = new();
    public List<Consumable> ConsumablesHeld {get;set;} = new();

    public double RunHand()
    {
        //figure out played hand base
        // using a static set for now
        CurrentScore = new()
        {
            Chips = 100,
            Mult = 20
        };
        //process PlayedCards
        foreach(var card in PlayedCards)
        {
            CurrentScore = card.CalculateCard(CurrentScore);
        }
        //run jokers
        foreach (var joker in Jokers)
        {
            joker.Calculate(this);
        }

        return CurrentScore.Chips * CurrentScore.Mult;
    }

    
}


public interface IJoker
{
    public string? JokerName {get;set;}
    public void Calculate(GameState state);
}



//test joker that adds +5 mult
public class Test5Joker : IJoker
{
    public string? JokerName { get; set; }

    public void Calculate(GameState state)
    {
        state.CurrentScore.Mult += 5;
    }
}
//test joker that adds x5 mult
public class Testx5Joker : IJoker
{
    public string? JokerName { get; set; }

    public void Calculate(GameState state)
    {
        state.CurrentScore.Mult *= 5;
    }
}
//test joker that adds x5 mult
public class TestReplayJoker : IJoker
{
    public string? JokerName { get; set; }

    public void Calculate(GameState state)
    {
        //replay Left Most Joker
        var firstJoker = state.Jokers.FirstOrDefault();
        if(firstJoker != null && firstJoker.GetType() != typeof(TestReplayJoker) )
        {
            firstJoker.Calculate(state);
        }
    }
}