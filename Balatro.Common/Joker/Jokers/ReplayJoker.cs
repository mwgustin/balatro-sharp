namespace Balatro.Common;

//test joker that adds x5 mult
public record ReplayJoker : CardBase, IJoker
{
    public ReplayJoker()
    {
        this.Name = "Replay Joker";
        this.Description = "Retrigger the leftmost Joker's effects";
    }

    

    public void CalculateHand(GameState state)
    {
        //replay Left Most Joker
        var firstJoker = state.Jokers.FirstOrDefault();
        if(firstJoker != null && firstJoker.GetType() != typeof(ReplayJoker) )
        {
            firstJoker.CalculateHand(state);
        }
    }

    public void CalculateStartRound(GameState state)
    {
        var firstJoker = state.Jokers.FirstOrDefault();
        if(firstJoker != null && firstJoker.GetType() != typeof(ReplayJoker) )
        {
            firstJoker.CalculateStartRound(state);
        }
    }
    public void CalculateEndRound(GameState state)
    {
        var firstJoker = state.Jokers.FirstOrDefault();
        if(firstJoker != null && firstJoker.GetType() != typeof(ReplayJoker) )
        {
            firstJoker.CalculateEndRound(state);
        }
    }
}