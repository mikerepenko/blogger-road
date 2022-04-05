using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trig : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Delete")
        {
            Destroy(other.gameObject);
        }
    }

}
