using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Delete")
        {
            other.gameObject.transform.position -= new Vector3(0,0,100);
        }
    }

}
