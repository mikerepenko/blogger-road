using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    public GameObject Road;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Border")
        {
            if (Road.GetComponent<CloseToLog>() != null)
                Road.GetComponent<CloseToLog>().speeed *= 2;
            if (Road.GetComponent<CloseToLog1>() != null)
                Road.GetComponent<CloseToLog1>().speeed *= 2;
            if (Road.GetComponent<CloseToLog2>() != null)
                Road.GetComponent<CloseToLog2>().speeed *= 2;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Border")
        {
            if (Road.GetComponent<CloseToLog>() != null)
                Road.GetComponent<CloseToLog>().speeed /= 2;
            if (Road.GetComponent<CloseToLog1>() != null)
                Road.GetComponent<CloseToLog1>().speeed /= 2;
            if (Road.GetComponent<CloseToLog2>() != null)
                Road.GetComponent<CloseToLog2>().speeed /= 2;
        }
    }
}
