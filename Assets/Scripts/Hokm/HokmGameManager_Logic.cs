using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class HokmGameManager_Logic
{
    
    
    private Queue<ECard> buffCardsDetermineTheRuler = new Queue<ECard>();

    public List<EUser> Users;
    Stack<ECard> cards = new Stack<ECard>();
    public SessionController_Hokm session;

    public PublicMethod.Symbol groundedSymbol;
    public List<ECard> groundCards = new List<ECard>();
    public void InitCards()
    {
        cards = ShareResources.instance.cardsData.GetStack();
        Debug.Log($"init card {cards.Count}");
    }

    public void ShuffleCards()
    {
        cards = cards.Shuffle();
        Debug.Log($"Shuffle Cards {cards.Count}");
    }

    public void InitUser()
    {
        for (int i = 0; i < 4; i++)
        {
            Users.Add(new EUser(SampleUserName.GetRandomName(), i, new List<ECard>()));
        }

        SampleUserName.Close();
    }

    public void Distribute(int place)
    {
        Debug.Log($"Distribute user {place} _ cards.count = {cards.Count}");
        Users[place].cards.Add(cards.Pop());
    }

    public void SetSymbol(int value)
    {
        session.SetSymbol(value);
    }
        
    public void SetSymbol(PublicMethod.Symbol value)
    {
        session.SetSymbol(value);
    }
    /// <summary>
    /// ==========> تعین حاکم
    /// </summary>
    public void DetermineTheRuler()
    {

        #region آماده سازی کارتها

        InitCards();
        ShuffleCards();

        #endregion

        var turn = new TurnManager(Users.Count);

        while (true)
        {
            var card = cards.Pop();
            buffCardsDetermineTheRuler.Enqueue(card);
            if (card.number == 1)
            {
                session.SetRuler(Users[turn.Get]);
                break;
            }

            turn.NextTurn();
        }
        
        //====>>>>>>>>>>>>>>>>>> test see Buff
        var seeBuff = new List<ECard>(buffCardsDetermineTheRuler);
        string msg = "";
        seeBuff.ForEach(x=>msg +=x.number+"_"+x.symbol+"\n");
        Debug.Log($"card buffer for DetermineTheRuler\n{msg}");
    }

    public void Distribute5Card()
    {
        #region آماده سازی کارتها

        InitCards();
        ShuffleCards();

        #endregion


        var turn = new TurnManager(session.ruler.place, Users.Count);
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Distribute(turn.Get);
            }

            turn.NextTurn();
        }

    }

    public void Distribute4Card()
    {

        var turn = new TurnManager(session.ruler.place, Users.Count);
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Distribute(turn.Get);
            }

            turn.NextTurn();
        }

    }


    public void DropOnTheGround(int elementNumber)
    {
        
            
        
        
        var turn = new TurnManager(session.starter.place, Users.Count);
        var selectedCard = Users[turn.Get].cards[elementNumber];

        if (groundCards.Count == 0)
            groundedSymbol = selectedCard.symbol;
        
        groundCards.Add(selectedCard);
        
        Users[turn.Get].cards.Remove(selectedCard);
        
        turn.NextTurn();
        session.starter.place = turn.Get;

        if (groundCards.Count >= 4)
        {
            session.state = SessionController_Hokm.GameState.CheckGroundedCards;
            CheckGroundedCard();
        }
    }

    public void CheckGroundedCard()
    {
        var topCard = groundCards.Max(x => x.score);
    }
}
