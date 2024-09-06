using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName ="New Card Info",menuName ="Card Info")]
public class CardInfo : ScriptableObject
{
    public CardType cardType;
    public new string name;
    public string description;
    public Sprite sprite;
    public int health;
    public int armor;
    public int damage;

}
public enum CardType
{
    Spell,
    Creature
}