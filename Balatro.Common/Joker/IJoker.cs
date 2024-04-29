namespace Balatro.Common;

public interface IJoker
{
    public void CalculateHand(GameState state);
    public void CalculateStartRound(GameState state);
    public void CalculateEndRound(GameState state);

}
