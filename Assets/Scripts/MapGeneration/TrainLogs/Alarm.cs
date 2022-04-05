using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour {

    public GameObject Light1;
    public GameObject Light2;
    public AudioSource alarmSound;
    public AudioSource engineSound;

    public bool Alaarm;

	void Start () {
        Alaarm = false;
	}
	
	void Update () {
        if (Alaarm == true)
        {
            Light1.SetActive(true);
            Light2.SetActive(true);
            if (!alarmSound.isPlaying)
                StartCoroutine(Sounds());
        }
        else
        {
            Light1.SetActive(false);
            Light2.SetActive(false);
        }
	}

    IEnumerator Sounds()
    {
        alarmSound.Play();
        yield return new WaitForSeconds(0.5f);
        engineSound.Play();
    }
}
