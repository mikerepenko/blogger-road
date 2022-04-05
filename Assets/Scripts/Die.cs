using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour {

    public GameObject MyScore;
    public GameObject cam;
    public GameObject Player;
    public GameObject InMenu;
    public GameObject InGame;
    public GameObject Magazine;
    public Button button1;
    public Button button2;
    public Text txt;
    public Text txt2;

    int Score;

    public bool dead = false;
    public bool dead1 = false;
    bool complite;


    void Start()
    {
        InMenu.SetActive(false);
        InGame.SetActive(true);
        Magazine.SetActive(false);
        Score = MyScore.GetComponent<Score>().MyScore;
    }

    void Update()
    {
        if (dead && !complite)
        {
            Score = MyScore.GetComponent<Score>().MyScore;
            InMenu.SetActive(true);
            InGame.SetActive(false);
            Player.SetActive(false);
            gameObject.GetComponent<Move>().enabled = false;
            cam.GetComponent<Camera>().enabled = false;
            txt.enabled = true;
            txt2.enabled = true;
            if (PlayerPrefs.GetInt("HighScore") < Score) {
                PlayerPrefs.SetInt("HighScore", Score);
            }
            PlayerPrefs.SetInt("Monets", PlayerPrefs.GetInt("Monets") + MyScore.GetComponent<Score>().Monets);
            txt.GetComponent<Text>().text = "Your Score: " + Score.ToString();
            txt2.GetComponent<Text>().text = "Your Monets: " + MyScore.GetComponent<Score>().Monets.ToString();
            complite = true;
        }
    }
}
