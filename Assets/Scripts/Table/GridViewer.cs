using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GridViewer : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Transform cardPlace;
    [SerializeField] private float gridAttackTime=0.5f;
    private Vector3 originalScale;
    private Vector3 originalPosition;
    private GameObject currentObject;
    private void Awake()
    {
        originalScale = transform.localScale;
        if (canvas == null)
            canvas = GetComponentInChildren<Canvas>();
        canvas.worldCamera = Camera.main;
        originalPosition = transform.localPosition;
    }
    public void ScaleGrid()
    {
        transform.DOScale(transform.localScale * 1.1f, 0.3f);
    }
    public void DeScaleGrid()
    {
        transform.DOScale(originalScale, 0.3f);
    }
    public void SetCardTransform(GameObject card)
    {
        card.transform.parent = cardPlace.transform;
        card.transform.localPosition = Vector3.zero;
        card.transform.localRotation = new Quaternion(180, 0, 180, 0);
        card.transform.localScale = Vector3.one;
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public void ClearView()
    {
        Destroy(currentObject);
        Destroy(cardPlace.GetComponentInChildren<Card>().gameObject);
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
    public void AttackCardMove(Vector3 attackPosition)
    {
        transform.DOMove(attackPosition,gridAttackTime).OnComplete(MoveToOriginPosition);
        ///GridController.instance.ClearSelectedGrids();
    }
    public void MoveToOriginPosition()
    {
        transform.DOLocalMove(originalPosition, gridAttackTime);
        GridController.instance.ClearSelectedGrids();
    }
}
