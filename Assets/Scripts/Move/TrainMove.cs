using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour {

    public GameObject TrainLine;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * TrainLine.GetComponent<RandomTrain>().speed;
    }
}
