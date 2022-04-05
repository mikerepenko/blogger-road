using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrain : MonoBehaviour {

    public GameObject[] Trains;
    public GameObject SpawnPos;
    GameObject obj;

    public float speed = 0;
    bool Spawn = false;
    float speedChange;

    void Start()
    {
        speedChange = GameObject.Find("WorldGenerationScript").GetComponent<WorldGeneration>().speedChangeTrain;
        StartCoroutine(Starting());
        speed = Random.Range(speedChange, speedChange + 15);
    }

    IEnumerator Starting()
    {
        while (true)
        {
            if (Spawn == false)
            {
                Spawn = true;
            }
            if (Spawn == true)
            {
                Instantiate(Trains[Random.Range(0, Trains.Length)], SpawnPos.transform.position, new Quaternion(0, 0, 0, 0), transform.parent);
                yield return new WaitForSeconds(Random.Range(3f, 5f));
                Spawn = false;
            }
        }
    }

}
