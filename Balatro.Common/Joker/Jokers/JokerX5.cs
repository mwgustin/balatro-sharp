namespace Balatro.Common;

//test joker that adds x5 mult
public record JokerX5 : CardBase, IJoker
{
    public JokerX5()
    {
        Name = "Super Joker";
        Description = "Gives x5 Multiplier";
    }

    public void CalculateHand(GameState state)
    {
        state.CurrentScore.Mult *= 5;
    }

    public void CalculateStartRound(GameState state)
    {
    }

    public void CalculateEndRound(GameState state)
    {
    }

}
