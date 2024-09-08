using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class CardMovementComponent : MonoBehaviour, IDragHandler,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler,IDropHandler,IPointerUpHandler
{
    private CardInteractComponent interactComponent;
    private RectTransform rectTransform;
    private bool isCardPlayed;
    private Canvas canvas;
    private Vector3 pastPosition;
    private Quaternion pastRotation;
    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas= GetComponentInParent<Canvas>();
        interactComponent=GetComponent<CardInteractComponent>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.DOScale(rectTransform.localScale*1.1f,0.2f);
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.DOScale(Vector3.one, 0.2f);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isCardPlayed && GameMaster.Instance.TurnType==GridType.PLAYER)
        {
            pastRotation = rectTransform.rotation;
            pastPosition = rectTransform.localPosition;
            rectTransform.DOLocalRotate(Vector3.zero, 0.3f);
        }
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        
        if (rectTransform.localPosition.y > 150 && GameMaster.Instance.TurnType == GridType.PLAYER && interactComponent.CheckCardPosition())
        {
            {
                GetComponent<CardInteractComponent>().PlayCard();
                isCardPlayed = true;
            }
        }
        else
        // if (!isCardPlayed)
        {
            Debug.Log("BACK CARD");

            rectTransform.DOLocalMove(pastPosition, 0.3f);
            rectTransform.DOLocalRotateQuaternion(pastRotation, 0.3f).OnComplete(UpdateHand);
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!isCardPlayed)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        
    }
    private void UpdateHand()
    {
        HandManager.instance.UpdateHandVisual();
    }
}
