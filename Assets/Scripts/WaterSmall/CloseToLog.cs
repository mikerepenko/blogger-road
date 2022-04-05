using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseToLog : MonoBehaviour {
    public bool Close = false;
    public GameObject road;
    GameObject Player;

    public float speeed;

    public GameObject _pozF;
    
    float _dist1;


    private void Start()
    {
        speeed = road.GetComponent<RandomWater>().speed;
        Close = false;
        Player = GameObject.Find("PlayerMain");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Player.GetComponent<OnLog>().speed = speeed;
            Close = true;
        }
    }

    private void Update()
    {
        if (Close == true)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Mathf.Lerp(Player.transform.position.z, _pozF.transform.position.z + 1f, 7 * Time.deltaTime));
        }
        transform.parent.position += transform.parent.forward * Time.deltaTime * speeed;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponentInParent<OnLog>().PlayerCloseToLog = false;
            Close = false;
        }
    }

}
