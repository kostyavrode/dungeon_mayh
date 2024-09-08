using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteractComponent : MonoBehaviour
{
    private RectTransform rectTransform;
    [SerializeField] private GridType type;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void SetType(GridType type)
    {

    this.type = type; 
    }
    public void PlayCard()
    {
        Debug.Log("Card Played");
        GameObject.FindObjectOfType<HandManager>().RemoveCardFromHand(GetComponent<Card>());
        CheckCardPosition();
    }
    public bool CheckCardPosition()
    {
        RaycastHit hit;
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Transform hitObject = hit.transform;
            if (hitObject.tag == "Grid")
            {
                Grid gr= hitObject.GetComponent<Grid>();
                if ((!gr.IsGridFull && gr.GetGridType==type && GameMaster.Instance.TurnType == GridType.PLAYER))
                {
                    hitObject.GetComponent<Grid>().SetCardToGrid(GetComponent<Card>());
                    return true;
                }
            }
        }
        return false;
    }
    public void DealDamage(CardInteractComponent cardToAttack)
    {
        Card card = GetComponent<Card>();
        int dmg = card.Damage;
        cardToAttack.ReceiveDamage(dmg);
    }
    public void ReceiveDamage(int dmg)
    {
        Debug.Log("Damage Received"+dmg);
        Card card = GetComponent<Card>();
        card.Health -= dmg;
        card.UpdateStats();
        if (card.Health <= 0)
        {
            GetComponentInParent<Grid>().ClearGrid();
        }
    }
}
