using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TMP_Text turnTime;
    public GameObject endTurnButton;
    private void Awake()
    {
        Instance = this;
    }
    public void ShowEndButton(bool state)
    {
        endTurnButton.SetActive(state);
    }
    public void ShowTime(string time)
    {
        turnTime.text = time;
    }
}
