using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GridController : MonoBehaviour
{
    public static GridController instance;
    public static Action<Grid> onGridClicked;
    [SerializeField] private Grid[] grids;
    [SerializeField] private List<Grid> selectedGrids;
    [SerializeField] private GridType type;
    public bool isPlayer;
    private void Awake()
    {
        instance = this;
        if (isPlayer)
        {
            type = GridType.PLAYER;
        }
        onGridClicked += SetClickedGrid;
        if (isPlayer)
        {
            foreach (Grid grid in grids)
            {
                grid.SetGridType(GridType.PLAYER);
            }
        }
    }
    private void OnDisable()
    {
        onGridClicked -= SetClickedGrid;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            selectedGrids.Clear();
        }
    }
    private void SetClickedGrid(Grid grid)
    {
        {
            selectedGrids.Add(grid);
            if (selectedGrids.Count == 2)
            {
                selectedGrids[1].Interact();
                if (selectedGrids[0] != null && selectedGrids[1] != null)
                {
                    if (selectedGrids[0].GetGridType == GridType.PLAYER && selectedGrids[1].GetGridType == GridType.ENEMY)
                    {
                        Debug.Log("Attackeym");
                        selectedGrids[0].gridViewer.AttackCardMove(selectedGrids[1].gameObject.transform.position);
                        selectedGrids[0].GetComponentInChildren<CardInteractComponent>().DealDamage(selectedGrids[1].GetComponentInChildren<CardInteractComponent>());
                        selectedGrids[0].Interact();
                        //selectedGrids[1].Interact();
                        selectedGrids.Clear();
                    }
                    else
                    {
                        //selectedGrids[0].Interact();
                        //selectedGrids[1].Interact();

                    }
                }
                selectedGrids.Clear();
            }
        }
    }
    public void ClearSelectedGrids()
    {

    selectedGrids.Clear(); 
    }
}
