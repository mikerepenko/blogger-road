using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMonets : MonoBehaviour {

    void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Monets").ToString();
    }
}
