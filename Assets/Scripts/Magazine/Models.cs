using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Models : MonoBehaviour {

    public GameObject Magazine;
    public GameObject InGame;
    public GameObject InMenu;
    public GameObject AwakeMenu;

    public void OnMouseDown ()
    {
        InGame.SetActive(false);
        InMenu.SetActive(false);
        AwakeMenu.SetActive(false);
        Magazine.SetActive(true);
    }
}
