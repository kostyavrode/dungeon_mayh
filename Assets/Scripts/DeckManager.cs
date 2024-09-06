using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private List<Card> allCards=new List<Card>();
    public void DrawCard(HandManager handManager)
    {
        if  (allCards.Count==0)
        {
            Debug.Log("Deck is Empty");
            return;
        }
        Card nextCard= allCards[allCards.Count-1];
        handManager.AddCartToHand(nextCard);
        allCards.Remove(nextCard);
    }
    public void ReceiveCardInDeck(Card newCard)
    {
        allCards.Add(newCard);
    }
}
