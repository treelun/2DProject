using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyText : MonoBehaviour
{
    GameObject Player;
    int price;
    private void Start()
    {
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        price = Player.GetComponent<PlayerManager>().Money;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Money : " + price;
    }
}
