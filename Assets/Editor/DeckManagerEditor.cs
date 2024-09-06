using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR 
using UnityEditor;
[CustomEditor(typeof(DeckManager))]
public class DeckManagerEditor : Editor
{
public override void OnInspectorGUI()
{
DrawDefaultInspector();
DeckManager deckManager= (DeckManager)target;
if (GUILayout.Button("Draw Next Card"))
{
            HandManager playerHandManager = GameObject.FindGameObjectWithTag("PlayerHand").GetComponent<HandManager>();

            if (playerHandManager!= null)
{
deckManager.DrawCard(playerHandManager);
}
}
        if (GUILayout.Button("Draw Enemy Card And Play"))
        {
            HandManager enemyHandManager = GameObject.FindGameObjectWithTag("EnemyHand").GetComponent<HandManager>();
            HandManager handManager = FindObjectOfType<HandManager>();
            if (handManager != null)
            {
                deckManager.DrawCard(enemyHandManager);
            }
        }
    }
}
#endif
