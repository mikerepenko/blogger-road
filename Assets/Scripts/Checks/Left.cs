using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour {

    public bool left;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tree" || other.gameObject.tag == "Border")
        {
            left = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        left = false;
    }

}
