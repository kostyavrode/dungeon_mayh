using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private CardInfo[] cardInfos;
    [SerializeField] private Card cardPrefab;
    [SerializeField] private GridType turnType;
    public GridType TurnType {  get { return turnType; } }
    public bool TESTisGameStarted;
    public bool isGameStarted;
    public int deckLength;
    [SerializeField] private int turnDuration=30;
    private float turnWastedTime;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        turnType = GridType.PLAYER;
        isGameStarted = true;
        GenerateDeck(GridType.PLAYER);
        GenerateDeck(GridType.ENEMY);
        StartGameDestribution();
    }
    private void Update()
    {
        if (isGameStarted)
        {
            turnWastedTime += Time.deltaTime;
            UIManager.Instance.ShowTime(turnWastedTime.ToString());
            if (turnWastedTime >= turnDuration)
            {
                if (turnType == GridType.PLAYER)
                {
                    SwitchTurn(GridType.ENEMY);
                }
                else if (turnType == GridType.ENEMY)
                {
                    SwitchTurn(GridType.PLAYER);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            SwitchTurn(GridType.PLAYER);
        }
    }
    
    private void GenerateDeck(GridType deckType)
    {
        Transform parentt = GameObject.FindGameObjectWithTag("canvas").transform;
        for (int i = 0; i < deckLength; i++)
        {
            Card newCard = Instantiate(cardPrefab,deckManager.playerDeckParent);
            newCard.Init(cardInfos[Random.Range(0,cardInfos.Length)]);
            deckManager.ReceiveCardInDeck(newCard,GridType.PLAYER);
            newCard.gameObject.SetActive(false);
        }
        for (int i = 0; i < deckLength; i++)
        {
            Card newCard = Instantiate(cardPrefab, deckManager.enemyDeckParent);
            newCard.Init(cardInfos[Random.Range(0, cardInfos.Length)]);
            deckManager.ReceiveCardInDeck(newCard, GridType.ENEMY);
            newCard.gameObject.SetActive(false);
        }
    }
    public void StartGameDestribution()
    {
        deckManager.StartDestribution(3);
    }
    public void SwitchTurn(GridType turnType)
    {
        this.turnType=turnType;
        turnWastedTime = 0;
        if (turnType == GridType.PLAYER)
        {
            deckManager.DrawCard(deckManager.playerHandManager);
            UIManager.Instance.ShowEndButton(true);
        }
        else if (turnType == GridType.ENEMY)
        {
            UIManager.Instance.ShowEndButton(false);
            deckManager.DrawCard(deckManager.enemyHandManager);
        }
    }
    public void PlayerEndTurn()
    {
        SwitchTurn(GridType.ENEMY);
    }
}
