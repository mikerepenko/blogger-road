using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour {

    public GameObject[] Objects;
    public GameObject SpawnPos;
    public GameObject Monetka;

    public float speed = 0;
    float speedChange;
    bool Spawn = false;
	
	void Start ()
    {
        speedChange = GameObject.Find("WorldGenerationScript").GetComponent<WorldGeneration>().speedChangeRoad;
        StartCoroutine(Starting());
        speed = Random.Range(speedChange, speedChange + 20);
        for (int i = (int)transform.parent.position.z - 150; i < (int)transform.parent.position.z + 150; i += 10)
        {
            if (Random.Range(0, 8) == 1)
            {
                Instantiate(Monetka, new Vector3(SpawnPos.transform.position.x, SpawnPos.transform.position.y - 4.5f, i), new Quaternion(0, 0, 0, 0), transform);
            }
        }
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
                Instantiate(Objects[Random.Range(0, Objects.Length)], SpawnPos.transform.position, new Quaternion(0,0,0,0), transform.parent);
                if (speed > 100)
                    yield return new WaitForSeconds(Random.Range(0.3f, 2f));
                else yield return new WaitForSeconds(Random.Range(1f, 4f));
                Spawn = false;
            }
        }
    }
}
