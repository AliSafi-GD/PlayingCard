[System.Serializable]
public class SessionController_Hokm
{
    public enum GameState
    {
        StartGame,
        Ruling,
        AllowedToDrop,
        CheckGroundedCards
    }

    public GameState state;
    public EUser ruler;
    public EUser starter;
    public PublicMethod.Symbol Symbol;

    public void SetRuler(EUser user)
    {
        state = SessionController_Hokm.GameState.Ruling;
        ruler = user;
        starter = new EUser("",user.place,null);
    }

    public void SetSymbol(int value)
    {
        state = GameState.AllowedToDrop;
        Symbol = (PublicMethod.Symbol)value;
    }

    public void SetSymbol(PublicMethod.Symbol value)
    {
        state = GameState.AllowedToDrop;
        Symbol = value;
    }
}
