using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfWater : MonoBehaviour {

    public bool Watter;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Watter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Watter = false;
        }
    }
}
