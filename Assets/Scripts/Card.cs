using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private CardInfo cardInfo;
    private CardViewer viewer;
    private string name;
    private int health;
    private int damage;
    private CardType type;
    public string Name { get { return name; } }
    public CardType CardType { get { return type; } }
    public int Health { get { return health; } }
    public int Damage { get { return damage; } }

    private void Awake()
    {
        if (viewer == null)
        {
            viewer = GetComponent<CardViewer>();
        }
    }
    public void Init(CardInfo info)
    {
        cardInfo = info;
        viewer.InitCardView(cardInfo.sprite, cardInfo.name, cardInfo.health.ToString(), cardInfo.damage.ToString());
        type = cardInfo.cardType;
        name = cardInfo.name;
        health= cardInfo.health;
        damage = cardInfo.damage;
    }
}
