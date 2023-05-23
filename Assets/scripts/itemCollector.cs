using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemCollector : MonoBehaviour

{
    private int coin = 0;
    public TextMeshProUGUI coinText;
    int coincount;
    public AudioSource audiosource;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            coin++;
            Debug.Log("count" + coin);
            audiosource.Play();

            coinText.text = "COINS: " + coin.ToString();
        }

    }
}

