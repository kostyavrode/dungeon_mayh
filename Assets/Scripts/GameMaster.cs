using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private CardInfo[] cardInfos;
    [SerializeField] private Card cardPrefab;
    public bool TESTisGameStarted;
    public int deckLength;
    private void Start()
    {
        GenerateDeck();
    }
    private void GenerateDeck()
    {
        Transform parentt = GameObject.FindGameObjectWithTag("canvas").transform;
        for (int i = 0; i < deckLength; i++)
        {
            Card newCard = Instantiate(cardPrefab,parentt);
            newCard.Init(cardInfos[Random.Range(0,cardInfos.Length)]);
            deckManager.ReceiveCardInDeck(newCard);
            newCard.gameObject.SetActive(false);
        }
    }
}
