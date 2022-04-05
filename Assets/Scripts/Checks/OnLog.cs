using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLog : MonoBehaviour {

    public bool PlayerOnLog = false;
    public bool PlayerCloseToLog = false;

    public float speed;

    private void Start()
    {
        PlayerOnLog = false;
        PlayerCloseToLog = false;
    }
    private void Update()
    {
        if (PlayerOnLog == true)
            transform.position += transform.forward * Time.deltaTime * speed;
    }
}
