using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainExit : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            GetComponentInParent<Alarm>().Alaarm = false;
        }
    }
}
