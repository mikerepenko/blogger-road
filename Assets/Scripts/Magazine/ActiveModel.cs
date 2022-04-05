using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActiveModel : MonoBehaviour {
    
    public bool Big;
    public GameObject Magazine;
    public GameObject Galka;
    public GameObject Buy;
    protected static bool[] avlble = new bool [50];
    private int price;
    public int ModelPrice { get { return price; } }
    Vector3 Before;
    Vector3 After;
    string s;
    string s2;
    int k = 0;
    int z = 0;

    private void Start()
    {

        Galka.SetActive(false);
        Buy.SetActive(false);
        price = 1;
        Before = transform.localScale * 0.5f;
        After = transform.localScale * 1.5f;
        s = PlayerPrefs.GetString("Models");
        while (k < s.Length)
        {
            if (s[k] != ' ')
            {
                s2 += s[k];
                k++;
            }
            else if (s[k] == ' ')
            {
                avlble[z] = bool.Parse(s2);
                s2 = "";
                k++;
                z++;
            }
        }
        avlble[0] = true;
    }
    
    private void Update()
    {
        if (PlayerPrefs.GetInt("Monets") - GetComponent<Price>().ModelPrice > 0 && avlble[int.Parse(name) - 1] == false && Buy.GetComponentInChildren<Buy>().BuyCompl == true)
        {
            avlble[int.Parse(name) - 1] = true;
            PlayerPrefs.DeleteKey("Models");
            for (int i = 0; i < 50; i++)
            {
                PlayerPrefs.SetString("Models", PlayerPrefs.GetString("Models") + avlble[i] + " ");
            }
            PlayerPrefs.SetInt("Monets", PlayerPrefs.GetInt("Monets") - GetComponent<Price>().ModelPrice);
        }
        else if (PlayerPrefs.GetInt("Monets") - GetComponent<Price>().ModelPrice < 0 && avlble[int.Parse(name) - 1] == false && Buy.GetComponentInChildren<Buy>().BuyCompl == true)
        {
            Buy.GetComponentInChildren<Buy>().BuyCompl = false;
        }
        if (Big == true && avlble[int.Parse(name) - 1] == true)
        {
            Galka.SetActive(true);
            Buy.SetActive(false);
            Magazine.GetComponent<ShopScript>().LastNumber = int.Parse(name) - 1;
        }
        else if (Big == true && avlble[int.Parse(name) - 1] == false)
        {
            Galka.SetActive(false);
            Buy.SetActive(true);
        }
        if (Big == true)
        {
            transform.localScale = After;
        }
        else
        {
            transform.localScale = Before;
            Galka.SetActive(false);
            Buy.SetActive(false);
        }
    }
}
