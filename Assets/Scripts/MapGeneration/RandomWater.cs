using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWater : MonoBehaviour
{

    public GameObject[] Objects;
    public GameObject SpawnPos;
    GameObject obj;
    int rand2 = -1;
    int timer = 0;

    public float speed = 0;
    float speedChange;
    bool Spawn = false;

    void Start()
    {
        speedChange = GameObject.Find("WorldGenerationScript").GetComponent<WorldGeneration>().speedChangeWater;
        StartCoroutine(Starting());
        speed = Random.Range(speedChange, speedChange + 10);
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
                if (rand2 == -1)
                {
                    rand2 = Random.Range(0, Objects.Length);
                    timer = 0;
                }
                yield return new WaitForSeconds(timer);
                Instantiate(Objects[rand2], SpawnPos.transform.position, new Quaternion(0, 0, 0, 0), transform);
                rand2 = Random.Range(0, Objects.Length);
                if (rand2 == 2)
                    timer = Random.Range(2,4);
                else timer = Random.Range(2, 4);
                Spawn = false;
            }
        }
    }
}
