using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPause : MonoBehaviour {

    public GameObject paus;

    public void OnMouseDown() {
        paus.GetComponent<Pause>().ativ = true;
    }

}
