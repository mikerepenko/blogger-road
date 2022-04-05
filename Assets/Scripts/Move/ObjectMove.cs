using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour {

    public GameObject road;
    public float speed;
    private void Start()
    {
        speed = road.GetComponent<RandomMap>().speed;
    }
    void Update ()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
