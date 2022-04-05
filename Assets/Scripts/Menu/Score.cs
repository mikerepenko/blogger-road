using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Canvas canv;
    public Text txt;
    public Text txt2;
    public int MyScore;
    public int Monets;

    private void Awake()
    {
        if (Screen.height == 1080)
        {
            canv.GetComponent<CanvasScaler>().scaleFactor = 1.8f;
        }
        else if (Screen.height >= 720 && Screen.height < 1080)
        {
            canv.GetComponent<CanvasScaler>().scaleFactor = 1.2f;
        }
        else { canv.GetComponent<CanvasScaler>().scaleFactor = 0.6f; }
    }

    private void Update()
    {
        txt.GetComponent<Text>().text = MyScore.ToString();
        txt2.GetComponent<Text>().text = Monets.ToString();
    }
}
