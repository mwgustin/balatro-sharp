namespace Balatro.Common;

public record GameState
{
    public List<IJoker> Jokers {get;set;} = new();
    public Score CurrentScore {get;set;} = new();
    public double PlayedScore {get; set;}
    public List<PlayingCard> PlayedCards {get;set;} = new();
    public List<PlayingCard> HeldCards {get;set;} = new();
    public List<Consumable> ConsumablesHeld {get;set;} = new();

    public double Money {get;set;} = 0;
    
    public int Round {get; private set;} = 1;
    public int Ante {get; private set;} = 1;

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
            // foreach(var joker in Jokers)
            // {
            //     joker.CalculateCardStep(card, state);
            // }
            // if(card.Seal == Seal.Red)
            // {
            //     CurrentScore = card.CalculateCard(CurrentScore);
            //     foreach(var joker in Jokers)
            //     {
            //         joker.CalculateCardStep(card, state);
            //     }
            // }

        }
        //run jokers
        foreach (var joker in Jokers)
        {
            joker.CalculateHand(this);
        }

        return CurrentScore.Chips * CurrentScore.Mult;
    }

    public void UpdateStartRound()
    {
        foreach(var joker in Jokers)
        {
            joker.CalculateStartRound(this);
        }
    }
    public void UpdateEndRound()
    {
        foreach(var joker in Jokers)
        {
            joker.CalculateEndRound(this);
        }
    }

    
}
