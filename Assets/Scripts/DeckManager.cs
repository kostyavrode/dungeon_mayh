using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private List<Card> playerDeckCards=new List<Card>();
    private List<Card> enemyDeckCards=new List<Card>();
    public HandManager playerHandManager;
    public HandManager enemyHandManager;

    public Transform playerDeckParent;
    public Transform enemyDeckParent;
    public void DrawCard(HandManager handManager)
    {
        if  (playerDeckCards.Count==0 && handManager==playerHandManager)
        {
            Debug.Log("Deck is Empty");
            return;
        }
        if (enemyDeckCards.Count == 0 && handManager == enemyHandManager)
        {
            Debug.Log("Deck is Empty");
            return;
        }
        if (handManager == playerHandManager)
        {
            Card nextCard = playerDeckCards[playerDeckCards.Count - 1];
            handManager.AddCartToHand(nextCard);
            playerDeckCards.Remove(nextCard);
        }
        else if (handManager == enemyHandManager)
        {
            Card nextCard = enemyDeckCards[enemyDeckCards.Count - 1];
            handManager.AddCartToHand(nextCard);
            enemyDeckCards.Remove(nextCard);
        }
    }
    public void ReceiveCardInDeck(Card newCard,GridType deckType)
    {
        if (deckType == GridType.PLAYER)
        {
            playerDeckCards.Add(newCard);
        }
        else if (deckType == GridType.ENEMY)
        {
            enemyDeckCards.Add(newCard);
        }
    }
    public void StartDestribution(int countCards)
    {
        for (int i = 0; i < countCards; i++)
        {
            DrawCard(playerHandManager);
            DrawCard(enemyHandManager);
        }
    }
}
