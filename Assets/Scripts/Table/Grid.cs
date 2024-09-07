using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public enum GridType
{
    ENEMY,
    PLAYER
} 
public class Grid : MonoBehaviour
{
    public GridViewer gridViewer;
    [SerializeField] private bool isGridFull;
    [SerializeField] private bool isSelected;
    [SerializeField] private GridType gridType;
    public GridType GetGridType { get { return gridType; } }
    public bool IsGridFull {  get { return isGridFull; } }
    private Card currentCard;
    private void Awake()
    {
        if (gridViewer == null)
        {
            gridViewer = GetComponent<GridViewer>();
        }
        
    }
    public void Interact()
    {
        if ((currentCard != null) && !isSelected)
        {
            isSelected = true;
            gridViewer.ScaleGrid();
            GameObject.FindObjectOfType<PlayerInput>().isInteracting = true;
            GridController.onGridClicked?.Invoke(this);
            Debug.Log("CLICK TO ADD INTERACT");
        }
        else if (currentCard != null && isSelected)
        {
            gridViewer.DeScaleGrid();
            isSelected = false;
            GameObject.FindObjectOfType<PlayerInput>().isInteracting = false;
            GridController.onGridClicked?.Invoke(this);
            Debug.Log("CLICK TO OFF INTERACT");
        }
    }
    public void SetGridType(GridType type)
    {
        gridType = type; 
    }
    public void SetCardToGrid(Card card)
    {
        isGridFull = true;
        currentCard = card;
        gridViewer.SetCardTransform(card.gameObject);
    }
    public void ClearGrid()
    {
        Debug.Log("Clear Grid");
        currentCard= null;
        isGridFull= false;
        gridViewer.ClearView();
    }
}
