using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDie : MonoBehaviour {

    bool onWater;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("PlayerMain");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            onWater = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            onWater = false;
        }
    }

    private void Update()
    {
        if (onWater == true && Player.GetComponent<OnLog>().PlayerOnLog == false)
        {
            Player.GetComponent<Die>().dead = true;
        }
    }
}
