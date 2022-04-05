using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour {

    public GameObject Player;
    public GameObject cam;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !Player.GetComponent<Die>().dead1)
        {
            StartCoroutine(dead());
            cam.GetComponent<Camera>().enabled = false;
        }
    }

    void Update () {
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
	}

    IEnumerator dead()
    {
        Player.GetComponent<Move>().enabled = false;
        ShakeCamera.Shake(5f, 5f);
        yield return new WaitForSeconds(1f);
        ShakeCamera.Shake(0,0);
        Player.GetComponent<Die>().dead = true;
    }
}
