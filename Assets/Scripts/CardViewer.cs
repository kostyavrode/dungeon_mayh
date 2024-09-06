using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardViewer : MonoBehaviour
{
    [SerializeField] private Image sprite;
    [SerializeField] private new TMP_Text name;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text healthBar;
    [SerializeField] private TMP_Text armorBar;
    [SerializeField] private TMP_Text damageBar;
    public void InitCardView(Sprite cardSprite,string cardName, string cardHealth, string cardDamage)
    {
        sprite.sprite = cardSprite;
        name.text= cardName;
        healthBar.text= cardHealth;
        damageBar.text= cardDamage;
    }
}
