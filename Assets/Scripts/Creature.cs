using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature:Card
{
    private int health;
    private int armor;
    private int damage;
    public int Health { get { return health; } }
    public int Armor { get { return armor; } }
    public int Damage { get { return damage; } }
    public void Attack(Creature target)
    {
        target.ReceiveDamage(damage);
    }
    public void ReceiveDamage(int damage)
    {
        armor -= damage;
        if (armor<0)
        {
            health += armor;
            armor = 0;
        }
    }
    
}
