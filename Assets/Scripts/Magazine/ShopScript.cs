using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour {

    public GameObject[] Models;
    public GameObject[] Players;
    public int LastNumber;
    

    private void Start()
    {
        if (PlayerPrefs.GetInt("Player") != 0)
            LastNumber = PlayerPrefs.GetInt("Player");
        else LastNumber = 1;
        for (int i = 0; i < Models.Length; i++)
        {
            if (i != LastNumber - 1)
            {
                Players[i].SetActive(false);
            }
            else
            {
                Players[i].SetActive(true);
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < Models.Length; i++)
        {
            if (i != LastNumber - 1)
            {
                Players[i].SetActive(false);
            }
            else
            {
                PlayerPrefs.SetInt("Player", LastNumber);
                Players[i].SetActive(true);
            }
        }
    }
}
