using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hokm_GameManager : MonoBehaviour
{


    public static Action<Symbol> OnSetKingSymbol;
    
    public List<ECard> cards;
    public List<ECard> buffCardsChooseRuler;
    public List<User> users;
    
    public User kingUser;
    public Symbol KingSymbol;
    
    public TurnObject turn;



    [SerializeField] private Transform placeCreatedCard;
    [SerializeField] private List<Transform> placeCards_ChooseRuler;
    [SerializeField] private List<Transform> userPlaceCards;
    [SerializeField] private List<Transform> userRotateCards;

    [SerializeField] private GameObject uiKingSymbolsPanel;
    IEnumerator Start()
    {
        OnSetKingSymbol = SetKingSymbol;
        
        turn = new TurnObject(users.Count, 1);

        InitMainCard();
        ChooseRuler();
        
        InitMainCard();
        DealTheCards();

       
        RunTasks(IE_ChooseRulerView(null),IE_DealTheCardsView(0,5, ()=>uiKingSymbolsPanel.gameObject.SetActive(true)));
        
        yield return new WaitForSeconds(1);
    }

    void RunTasks(params IEnumerator[] IEs)
    {
        StartCoroutine(IE_RunTasks(IEs));
    }

    IEnumerator IE_RunTasks(params IEnumerator[] IEs)
    {
        foreach (var task in IEs)
        {
            yield return StartCoroutine(task);
        }
    }
    #region Init Main Cards

    void InitMainCard()
    {
        cards.Clear();
        int counter=0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                counter++;
                
                var id = counter;
                var number = j + 1;
                var symbol = (Symbol)i;
                var fullName = $"{GetCardName(number)} {symbol}";
                var order = number == 1 ? 13 : number - 1;
                
                cards.Add(new ECard(){fullName = fullName,id = id,number = number,order = order,symbol = symbol});
            }
        }
        
        
    }

    string GetCardName(int number)
    {
        switch (number)
        {
            case 1:
                return "Ace";
            case 11:
                return "Jack";
            case 12:
                return "Queen";
            case 13:
                return "King";
            default:
                return number.ToString();
        }
    }


    #endregion

    User GetUserAtTurn(int index) => users.Find(x => x.turn == index);
    
    void ChooseRuler()
    {
        var max = cards.Count;
        for (int i = 0; i < max; i++)
        {
            var rndCard = cards[Random.Range(0, cards.Count)];
            buffCardsChooseRuler.Add(rndCard);
            cards.Remove(rndCard);
            if (rndCard.order == 13)
            {
                kingUser = GetUserAtTurn(turn.Current);
                break;
            }

            turn.Next();
        }
    }

    Coroutine ChooseRulerView(Action OnEnd)
    {
        return StartCoroutine(IE_ChooseRulerView(OnEnd));
    }

    IEnumerator IE_ChooseRulerView(Action OnEndMethos)
    {
        turn = new TurnObject(users.Count, 1);
        List<Card> cardsCreated = new List<Card>();
        foreach (var eCard in buffCardsChooseRuler)
        {
            var card = CardCreator.instance.Create(eCard, placeCreatedCard.position, Quaternion.identity,
                placeCards_ChooseRuler[turn.Current-1].transform);
            card.StartMove(placeCreatedCard, userPlaceCards[turn.Current-1].transform, 4, (-25, 100), null, null);
            card.StartRotate(placeCreatedCard, userRotateCards[turn.Current-1].transform, 4, (-15, 15), null, null);
            card.ShowFront();
            turn.Next();
            cardsCreated.Add(card);
            yield return new WaitForSeconds(0.2f);
        }

        foreach (var c in cardsCreated)
        {

            Destroy(c.gameObject);

        }
        
        OnEndMethos?.Invoke();
    }

    void SetKingSymbol(Symbol symbol)
    { 
        KingSymbol = symbol;
        uiKingSymbolsPanel.SetActive(false);
        RunTasks(
            IE_DealTheCardsView(5,4,null),
            IE_DealTheCardsView(5,4,null)
            );
    }
    
    void DealTheCards()
    {
        foreach (var user in users)
        {
            for (int i = 0; i < 5; i++)
            {
                var eCard = cards[Random.Range(0, cards.Count)];
                user.card.Add(eCard);
                cards.Remove(eCard);
            }
        }
        
        foreach (var user in users)
        {
            for (int i = 0; i < 4; i++)
            {
                var eCard = cards[Random.Range(0, cards.Count)];
                user.card.Add(eCard);
                cards.Remove(eCard);
            }
        }
        
        foreach (var user in users)
        {
            for (int i = 0; i < 4; i++)
            {
                var eCard = cards[Random.Range(0, cards.Count)];
                user.card.Add(eCard);
                cards.Remove(eCard);
            }
        }
    }

    Coroutine DealTheCardsView(int startIndex,int count,Action OnEnd) => StartCoroutine(IE_DealTheCardsView(startIndex,count,OnEnd));
    IEnumerator IE_DealTheCardsView(int startIndex,int count,Action OnEnd)
    {
        turn = new TurnObject(users.Count, kingUser.turn);
        for (int u = 0; u < users.Count; u++)
        {
            var cardsTrs = new List<Transform>();
            for (int i = 0; i < count; i++)
            {
                var cardTrs = new GameObject("card",typeof(RectTransform))
                {
                    transform =
                    {
                        position = Vector3.zero
                    }
                };
                cardTrs.transform.SetParent(userPlaceCards[turn.Current-1]);
                cardsTrs.Add(cardTrs.transform);
            }
            
            for (int j = 0; j < count; j++)
            {
                var eCard = GetUserAtTurn(turn.Current).card[j+startIndex];
                
                
                yield return new WaitForEndOfFrame();
                Canvas.ForceUpdateCanvases();
                
                var card = CardCreator.instance.Create(eCard,placeCreatedCard.position,Quaternion.identity, cardsTrs[j].transform);
                
                
                card.StartMove(placeCreatedCard,cardsTrs[j].transform,4,(-0,0),null,null);
                card.StartRotate(placeCreatedCard.rotation, userRotateCards[turn.Current-1].transform.rotation,4,(-0,0),null,null);
                //if(users[turn].isOwner)
                    card.ShowFront();
                yield return new WaitForSeconds(0.2f);
            }
            turn.Next();
        }
        OnEnd?.Invoke();
    }

}

[System.Serializable]
public class TurnObject
{
    private int max;
    public int Current;

    public TurnObject(int max, int current)
    {
        this.max = max;
        this.Current = current;
    }

    public void Next()
    {
        if (Current + 1 > max)
            Current = 1;
        else
            Current++;
    }
}
