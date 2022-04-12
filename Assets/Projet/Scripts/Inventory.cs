using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public bool isSave = false;

    public int coinsCount;
    public TextMeshProUGUI coinsCountText;

    public void AddCoins(int count)
    {
        coinsCount += count;
        isSave = true;
    }

    void Update()
    {
        coinsCountText.text = coinsCount.ToString();
        isSave = false;
    }
}
