using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Card Data", menuName = "Game Data", order = 0)]
public class CardsData : ScriptableObject
{
    public List<ECard> cards;


    public Stack<ECard> GetStack()
    {
        Stack<ECard> localCards = new Stack<ECard>(cards);
Debug.Log($"GetStack {localCards.Count}");
        // for (int i = 0; i < this.cards.Count; i++)
        // {
        //     localCards.Push(cards[i]);
        // }

        return localCards;
    }
    
    public List<ECard> GetList()
    {
        List<ECard> localCards = new List<ECard>();

        for (int i = 0; i < this.cards.Count; i++)
        {
            localCards.Add(cards[i]);
        }

        return localCards;
    }
}
