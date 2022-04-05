using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {

    public bool back;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tree" || other.gameObject.tag == "Border")
        {
            back = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        back = false;
    }

}
