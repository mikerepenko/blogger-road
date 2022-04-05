using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayShop : MonoBehaviour {
    
    public GameObject Magazine;
    public GameObject Skin;
    
    public void OnMouseDown()
    {
        Magazine.GetComponent<ShopScript>().LastNumber = int.Parse(Skin.name);
        if (Magazine.GetComponent<ShopScript>().LastNumber == int.Parse(Skin.name))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
