using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour {

    public bool forward;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tree" || other.gameObject.tag == "Border")
        {
            forward = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        forward = false;
    }

}
