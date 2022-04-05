using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour {

    public bool right;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tree" || other.gameObject.tag == "Border")
        {
            right = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        right = false;
    }

}
