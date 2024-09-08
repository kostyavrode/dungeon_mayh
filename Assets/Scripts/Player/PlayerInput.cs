using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject aim;
    public bool isInteracting = false;
    private void Update()
    {
        ReceiveClick();
        ActivateTrajectoryLine();
        if (!isInteracting)
        {
            lineRenderer.gameObject.SetActive(false);
            aim.SetActive(false);
        }
    }
    private void ActivateTrajectoryLine()
    {
        if (isInteracting)
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit.tag=="Table")
                {
                    aim.transform.position=hit.point;
                    aim.SetActive(true);
                    lineRenderer.SetPosition(1, hit.point);
                    lineRenderer.gameObject.SetActive(true);
                }
                else
                {
                    //lineRenderer.gameObject.SetActive(false);
                    //aim.SetActive(false);
                }
            }

        }
    }
    public void ReceiveClick()
    {
        if (Input.GetMouseButtonDown(0) && GameMaster.Instance.TurnType == GridType.PLAYER)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (hit.transform.tag=="Grid")
                {
                    Grid grid = hit.transform.GetComponent<Grid>();
                    if (grid.IsGridFull)
                    {
                        grid.Interact();
                        lineRenderer.SetPosition(0, grid.transform.position);
                    }
                }
            }
            //if (isInteracting)
            //{
            //    if (Physics.Raycast(ray, out hit ))
            //    {
            //        Transform objHit = hit.transform;
            //        if (hit.transform.tag=="Grid")
            //        {
            //            Grid gr=objHit.GetComponent<Grid>();
            //            //gr.GetComponent<GridViewer>().AttackCardMove(new Vector3(10, 10, 10));
            //        }
            //    }
            //}
        }
    }
}
