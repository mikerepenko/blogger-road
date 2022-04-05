using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public bool isPause;
    public GameObject Player;
    public GameObject Text;
    public GameObject img;
    public GameObject PauseImg;
    public GameObject butt;
    public bool ativ;

    void Start ()
    {
        butt.SetActive(false);
        isPause = false;
        Text.SetActive(false);
        img.SetActive(false);
        PauseImg.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (isPause == false)
        {
            Time.timeScale = 0;
            PauseImg.SetActive(true);
            butt.SetActive(true);
            Player.GetComponent<Move>().enabled = false;
            img.SetActive(true);
            Text.SetActive(true);
            isPause = true;
        }
    }

    private void Update()
    {
        if (ativ){ StartCoroutine(Play()); ativ = false; PauseImg.SetActive(false);}
    }

    public IEnumerator Play()
    {
        butt.SetActive(false);
        Text.GetComponent<Text>().text = "3";
        yield return new WaitForSecondsRealtime(1f);
        Text.GetComponent<Text>().text = "2";
        yield return new WaitForSecondsRealtime(1f);
        Text.GetComponent<Text>().text = "1";
        yield return new WaitForSecondsRealtime(1f);
        Text.GetComponent<Text>().text = "";
        Time.timeScale = 1f;
        Player.GetComponent<Move>().enabled = true;
        isPause = false;
        img.SetActive(false);
        Text.SetActive(false);
    }
}
