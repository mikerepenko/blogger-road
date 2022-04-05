using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public GameObject Magazine;
    public GameObject Menu;

    public void OnMouseDown()
    {
        Magazine.SetActive(false);
        Menu.SetActive(true);
    }
}
