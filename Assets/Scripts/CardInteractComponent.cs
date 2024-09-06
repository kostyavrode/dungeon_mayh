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
                if ((!gr.IsGridFull && gr.GetGridType==type))
                {
                    hitObject.GetComponent<Grid>().SetCardToGrid(GetComponent<Card>());
                    return true;
                }
            }
        }
        return false;
    }
}
