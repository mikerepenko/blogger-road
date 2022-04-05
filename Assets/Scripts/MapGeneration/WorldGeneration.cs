using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {

    public GameObject Grass;
    public GameObject GrassDark;
    public GameObject Water;
    public GameObject RoadSmall;
    public GameObject RoadMid;
    public GameObject RoadBig;
    public GameObject Train;
    public GameObject Player;
    public GameObject score;

    bool first;

    int Generation;
    int RGrass;
    int maxRoad;
    int maxTrain;
    int kolv;
    public float speedChangeWater = 15;
    public float speedChangeRoad = 20;
    public float speedChangeTrain = 350;
    float LastPosition;

    void Start () {
        kolv = 0;
        maxRoad = 0;
        maxTrain = 0;
        RGrass = 0;
        speedChangeWater = 15;
        speedChangeRoad = 1;
        speedChangeTrain = 100;
        for (float i = transform.position.x - 20; i > transform.position.x - 150; i-=10)
        {
            if (kolv > 0) Generation = Random.Range(2, 5);
            else if (kolv == 0) Generation = Random.Range(1, 5);
            switch (Generation)
            {
                case 1:
                    Instantiate(RoadSmall, new Vector3(i, 70.59f, transform.position.z), new Quaternion(0, 0, 0, 0));
                    LastPosition = i;
                    kolv++;
                    break;
                case 2:
                    if (RGrass % 2 == 1)
                    {
                        Instantiate(Grass, new Vector3(i, 67.8f, transform.position.z), new Quaternion(0, 0, 0, 0));
                        RGrass++;
                    }
                    else
                    {
                        Instantiate(GrassDark, new Vector3(i, 67.8f, transform.position.z), new Quaternion(0, 0, 0, 0));
                        RGrass++;
                    }
                    kolv = 0;
                    LastPosition = i;
                    break;
                case 3:
                    Instantiate(Train, new Vector3(i, 67.8f, transform.position.z), new Quaternion(0, 0, 0, 0));
                    kolv = 0;
                    LastPosition = i;
                    break;
                case 4:
                    Instantiate(Water, new Vector3(i, 67.8f, transform.position.z), new Quaternion(0, 0, 0, 0));
                    kolv = 0;
                    LastPosition = i;
                    break;
            }
        }
	}

    void Update()
    {
        if (Player.transform.position.x - 140 < LastPosition)
        {
            if (maxRoad == 0 && maxTrain < 3) { Generation = Random.Range(1, 5); }
            else if (maxRoad > 0 && maxTrain < 3) { Generation = Random.Range(2, 5); }
            else if (maxRoad == 0 && maxTrain >= 3) { Generation = Random.Range(1, 4); }
            else if (maxRoad > 0 && maxTrain > 3) { Generation = Random.Range(2, 4); }
            switch (Generation)
            {
                case 1:
                    int rnd = Random.Range(0, 3);
                    if (rnd == 0)
                    {
                        Instantiate(RoadSmall, new Vector3(LastPosition - 10, 70.59f, Mathf.Round(transform.position.z / 10) * 10), new Quaternion(0, 0, 0, 0));
                        LastPosition -= 10;
                    }
                    else if (rnd == 1)
                    {
                        Instantiate(RoadMid, new Vector3(LastPosition - 15, 69.69f, Mathf.Round(transform.position.z / 10) * 10), new Quaternion(0, 0, 0, 0));
                        LastPosition -= 20;
                    }
                    else if (rnd == 2)
                    {
                        Instantiate(RoadBig, new Vector3(LastPosition - 20f, 69.73f, Mathf.Round(transform.position.z / 10) * 10), new Quaternion(0, 0, 0, 0));
                        LastPosition -= 30;
                    }
                    score.GetComponent<Score>().MyScore++;
                    if (speedChangeRoad < 80)
                        speedChangeRoad++;
                    maxTrain = 0;
                    maxRoad++;
                    break;
                case 2:
                    Instantiate(Grass, new Vector3(LastPosition - 10, 67.8f, Mathf.Round(transform.position.z / 10) * 10), new Quaternion(0, 0, 0, 0));
                    score.GetComponent<Score>().MyScore++;
                    LastPosition -= 10;
                    maxTrain = 0;
                    maxRoad = 0;
                    break;
                case 3:
                    Instantiate(Water, new Vector3(LastPosition - 10, 67.8f, Mathf.Round(transform.position.z / 10) * 10), new Quaternion(0, 0, 0, 0));
                    score.GetComponent<Score>().MyScore++;
                    if (speedChangeWater < 50)
                        speedChangeWater++;
                    LastPosition -= 10;
                    maxTrain = 0;
                    maxRoad = 0;
                    break;
                case 4:
                    Instantiate(Train, new Vector3(LastPosition - 10, 67.8f, Mathf.Round(transform.position.z / 10) * 10), new Quaternion(0, 0, 0, 0));
                    score.GetComponent<Score>().MyScore++;
                    if (speedChangeTrain > 250)
                        speedChangeTrain--;
                    LastPosition -= 10;
                    maxTrain++;
                    maxRoad = 0;
                    break;
            }
            if (!first)
            {
                score.GetComponent<Score>().MyScore = 0;
                first = true;
            }
        }
    }
}
