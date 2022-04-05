using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shtorka : MonoBehaviour {

    public GameObject[] buttons;
    bool on;

    private void Start()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
    }

    public void OnMouseDown()
    {
        if (!on){
            buttons[0].SetActive(true);
            buttons[1].SetActive(true);
            on = true;
        }
        else if (on) {
            buttons[0].SetActive(false);
            buttons[1].SetActive(false);
            on = false;
        }
    }
}
