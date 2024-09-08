using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager instance;
    public Transform handTransform;
    public GridType type;
    public List<Card> handObjects = new List<Card>();

    public float fanSpread = 5f;
    public float horizontalSpacing = 5f;
    public float verticalSpacing = 100f;


    [SerializeField] private Transform playerDeckParent;
    [SerializeField] private Transform enemyDeckParent;
    private void Awake()
    {
        instance = this;
    }
    public void AddCartToHand(Card card)
    {
        card.transform.parent = handTransform;
        card.GetComponent<CardInteractComponent>().SetType(type);
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
    public void UpdateHandVisual()
    {
        Debug.Log("Update Hand");
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
