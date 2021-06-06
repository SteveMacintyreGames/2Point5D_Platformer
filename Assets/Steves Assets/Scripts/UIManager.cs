using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("UIManager is null!");
            }
            return _instance;
        }
    }

    public Text coinText;
    public Text LivesText;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        coinText.text = "Coins: 0";
    }

    public void UpdateCoinText(int coins)
    {
        coinText.text = "Coins: " + coins;
    }

    public void UpdateLivesText(int lives)
    {
        LivesText.text = "Lives: "+lives;
    }
 
}
