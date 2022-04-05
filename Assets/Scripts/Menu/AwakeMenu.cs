using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeMenu : MonoBehaviour {

    public bool ingame = false;
    public bool destroyt = false;
    public float speed;
    public GameObject Player;
    public GameObject title;
    public GameObject StartMenu;
    public GameObject InGame;
    public GameObject Cam;

    void Awake () {
		Player.transform.rotation = Quaternion.Euler(0, -90, 0);
        Cam.GetComponent<Camera>().enabled = false;
        StartMenu.SetActive(true);
        InGame.SetActive(false);
    }

    public void OnMouseDown()
    {
        destroyt = true;
        ingame = true;
        Player.transform.rotation = Quaternion.Euler(0, 90, 0);
        Cam.GetComponent<Camera>().enabled = true;
        StartMenu.SetActive(false);
        InGame.SetActive(true);
    }

    void Update () {
        if (destroyt) { title.transform.position += Vector3.forward * speed; StartCoroutine(DestroyTitle()); }
        if (!ingame)
           InGame.SetActive(false);
        else  if (ingame && Player.GetComponentInParent<Die>().dead == false) InGame.SetActive(true);
    }

    IEnumerator DestroyTitle()
    {
        yield return new WaitForSecondsRealtime(2f);
        destroyt = false;
        title.SetActive(false);
    }
}
