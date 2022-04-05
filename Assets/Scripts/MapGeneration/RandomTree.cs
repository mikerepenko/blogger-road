using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTree : MonoBehaviour {

    public GameObject[] Plants;
    public GameObject Place;
    public GameObject Monetka;
    bool rand = false;
    int random;

    void Update()
    {
        if (rand == false)
        {
            for (int i = (int)Place.transform.parent.position.z - 150; i < (int)Place.transform.parent.position.z + 150; i += 10)
            {
                if (i < (int)Place.transform.parent.position.z - 40 || i > (int)Place.transform.parent.position.z + 40)
                {
                    Instantiate(Plants[Random.Range(0, Plants.Length - 1)], new Vector3(Place.transform.parent.position.x, Place.transform.parent.position.y + 6, i), new Quaternion(0, 0, 0, 0), transform);
                }
                else
                {
                    random = Random.Range(0, 4);
                    if (random == 2 && Random.Range(0,2) == 1)
                    {
                        Instantiate(Plants[Random.Range(0, Plants.Length)], new Vector3(Place.transform.parent.position.x, Place.transform.parent.position.y + 6, i), new Quaternion(0, 0, 0, 0), transform);
                    }
                    if (random == 1 && Random.Range(0, 5) == 1)
                    {
                        Instantiate(Monetka, new Vector3(Place.transform.parent.position.x, Place.transform.parent.position.y + 6.5f, i), new Quaternion(0, 0, 0, 0), transform);
                    }
                }
                if (i == (int)Place.transform.position.z + 140)
                {
                    rand = true;
                }
            }
        }
    }
}
