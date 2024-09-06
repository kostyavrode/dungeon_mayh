using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public Transform handTransform;

    public List<Card> handObjects = new List<Card>();

    public float fanSpread = 5f;
    public float horizontalSpacing = 5f;
    public float verticalSpacing = 100f;
    private void Update()
    {
        //UpdateHandVisual();
    }
    public void AddCartToHand(Card card)
    {
        //card=Instantiate(card,handTransform.position,Quaternion.identity,handTransform);
        card.transform.parent = handTransform;
        
        handObjects.Add(card);
        UpdateHandVisual();
        StartCoroutine(Wait01Sec(card));
    }
    public void RemoveCardFromHand(Card card)
    {
        //card.transform.parent = GetComponentInParent<Canvas>().transform;
        handObjects.Remove(card);
        UpdateHandVisual();
    }
    private void UpdateHandVisual()
    {
        if (handObjects.Count == 1)
        {
            handObjects[0].transform.localRotation=Quaternion.Euler(0,0,0);
            handObjects[0].transform.localPosition = Vector3.zero;
            return;
        }
        int cardCount=handObjects.Count;
        for (int i = 0; i < cardCount; i++)
        {
            float rotationAngle=(fanSpread*(i-(cardCount-1)/2));
            handObjects[i].transform.localRotation=Quaternion.Euler(0f,0f,rotationAngle);
            float normalPosition = (2f * i / (cardCount - 1) - 1f);
            float horizontalOffset = (horizontalSpacing * (i - (cardCount - 1) / 2));
            float verticalOffset = (verticalSpacing * (1 - normalPosition * normalPosition)); 
            
            handObjects[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
    }
    private IEnumerator Wait01Sec(Card card)
    {
        yield return new WaitForSeconds(0.1f);
        card.gameObject.SetActive(true);
    }
}
