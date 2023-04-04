using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public Text MycoinText;
    private int CoinNum;

    void start()
    {
        CoinNum = 0;
        MycoinText.text = "Coin : " + CoinNum;
    }

    private void OnTriggerEnter2D(Collider2D coin)
    {
        if(coin.tag == "Coin")
        {
            CoinNum += 1;
            Destroy(coin.gameObject);
            MycoinText.text = "Coin : " + CoinNum;
        }
    }

    public void IncreaseCoin(int amount)
    {
        CoinNum += 10;
        MycoinText.text = "Coin : " + CoinNum;
    }
}
