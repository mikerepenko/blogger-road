using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Price : MonoBehaviour {

    private int price = 1;
    public GameObject BuyButton;

    public int ModelPrice { get { return price; } }
    void Start()
    {
        price = 1000;
    }
    private void Update()
    {
        BuyButton.GetComponentInChildren<Text>().text = price + "$";
    }

}
