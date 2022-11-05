using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hokm_GameManager : MonoBehaviour
{
    public List<ECard> cards;
    public List<ECard> buffCardsChooseRuler;
    public List<User> users;
    public User kingUser;
    public int turn;



    [SerializeField] private Transform placeCreatedCard;
    [SerializeField] private List<Transform> placeCards_ChooseRuler;
    [SerializeField] private List<Transform> userPlaceCards;
    [SerializeField] private List<Transform> userRotateCards;
    [SerializeField] private List<Transform> dealTheCardsView_Rotation;
    IEnumerator Start()
    {
        InitMainCard();
        ChooseRuler();
        
        InitMainCard();
        DealTheCards();

        bool isEndAct = false;
        ChooseRulerView(()=>isEndAct=true);
        yield return new WaitUntil(() => isEndAct);
        isEndAct = false;
        yield return new WaitForSeconds(1);
        DealTheCardsView(0,5,()=>isEndAct=true);
        yield return new WaitUntil(() => isEndAct);
        isEndAct = false;
        yield return new WaitForSeconds(1);
        DealTheCardsView(5,4,()=>isEndAct=true);
        yield return new WaitUntil(() => isEndAct);
        isEndAct = false;
        yield return new WaitForSeconds(1);
        DealTheCardsView(9,4,()=>isEndAct=true);
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
                kingUser = users[turn];
                break;
            }

            turn = turn + 1 >= 4 ? 0 : ++turn;
        }
    }

    void ChooseRulerView(Action OnEnd)
    {
        StartCoroutine(IE_ChooseRulerView(OnEnd));
    }

    IEnumerator IE_ChooseRulerView(Action OnEnd)
    {
        List<Card> cardsCreated = new List<Card>();
        turn = 0;
        foreach (var eCard in buffCardsChooseRuler)
        {
            var card = CardCreator.instance.Create(eCard, placeCreatedCard.position, Quaternion.identity,
                placeCards_ChooseRuler[turn].transform);
            card.StartMove(placeCreatedCard, userPlaceCards[turn].transform, 3, (-25, 100), null, null);
            card.StartRotate(placeCreatedCard, userRotateCards[turn].transform, 3, (-15, 15), null, null);
            turn = turn + 1 >= 4 ? 0 : ++turn;
            cardsCreated.Add(card);
            yield return new WaitForSeconds(0.2f);
        }

        foreach (var c in cardsCreated)
        {

            Destroy(c.gameObject);

        }
    

        OnEnd?.Invoke();
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

    void DealTheCardsView(int startIndex,int count,Action OnEnd) => StartCoroutine(IE_DealTheCardsView(startIndex,count,OnEnd));
    IEnumerator IE_DealTheCardsView(int startIndex,int count,Action OnEnd)
    {
        

        foreach (var user in users)
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
                cardTrs.transform.SetParent(userPlaceCards[turn]);
                cardsTrs.Add(cardTrs.transform);
            }
            
            for (int j = 0; j < count; j++)
            {
                var eCard = user.card[j+startIndex];
                
                
                yield return new WaitForEndOfFrame();
                Canvas.ForceUpdateCanvases();
                
                var card = CardCreator.instance.Create(eCard,placeCreatedCard.position,Quaternion.identity, cardsTrs[j].transform);
                
                
                card.StartMove(placeCreatedCard,cardsTrs[j].transform,3,(-0,0),null,null);
                card.StartRotate(placeCreatedCard.rotation, userRotateCards[turn].transform.rotation,3,(-0,0),null,null);
                
                yield return new WaitForSeconds(0.2f);
            }
            turn = turn + 1 >= 4 ? 0 : ++turn;
        }
        OnEnd?.Invoke();
    }

}
