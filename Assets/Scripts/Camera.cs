using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject Player;
    public float Up;
    public bool go;

    void Update()
	{
        if (Player.transform.position.x - transform.position.x + 60 <= -30) go = true;
        transform.position -= transform.right * Time.deltaTime * 5;
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(transform.position.z, Player.transform.position.z + 30, Time.deltaTime));
        if (go == true)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x + 60, Time.deltaTime * 0.5f), transform.position.y, transform.position.z);
            if (Player.transform.position.x - transform.position.x + 60 >= -20)
                go = false;
        }
    }
}
