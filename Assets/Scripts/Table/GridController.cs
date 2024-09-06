using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GridController : MonoBehaviour
{
    public static Action<Grid> onGridClicked;
    [SerializeField] private Grid[] grids;
    [SerializeField] private List<Grid> selectedGrids;
    [SerializeField] private GridType type;
    public bool isPlayer;
    private void Awake()
    {
        if (isPlayer)
        {
            type=GridType.PLAYER;
        }
        onGridClicked += SetClickedGrid;
        if (isPlayer )
        {
            foreach( Grid grid in grids )
            {
                grid.SetGridType(GridType.PLAYER);
            }
        }
    }
    private void OnDisable()
    {
        onGridClicked -= SetClickedGrid;
    }
    private void SetClickedGrid(Grid grid)
    {
        //foreach (Grid gr in grids )
        //{
        //    if (gr.GetHashCode()==grid.GetHashCode())
        //    {
        //        selectedGrids.Remove(gr);
        //        return;
        //    }
        //}
        ///if (selectedGrids.Count==0&&grid.GetGridType == type)
        {
            selectedGrids.Add(grid);
            if (selectedGrids.Count == 2)
            {
                selectedGrids[0].gridViewer.AttackCardMove(selectedGrids[1].gameObject.transform.localPosition);
                selectedGrids[0].Interact();
                selectedGrids[1].Interact();
                selectedGrids.Clear();
            }
        }
    }
}
