using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseToLog1 : MonoBehaviour {

    public bool Close = false;
    public GameObject road;
    GameObject Player;

    public float speeed;
    public GameObject _pozF;
    public GameObject _pozS;

    float _pozZ1;
    float _pozZ2;
    float _dist1;
    float _dist2;


    private void Start()
    {
        speeed = road.GetComponent<RandomWater>().speed;
        Close = false;
        _pozZ1 = _pozF.transform.position.z;
        _pozZ2 = _pozS.transform.position.z;
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
            _pozZ1 = _pozF.transform.position.z;
            _pozZ2 = _pozS.transform.position.z;
            if (Player.GetComponent<Move>().Jump == false)
            {
                _dist1 = Vector3.Distance(Player.transform.position, _pozF.transform.position);
                _dist2 = Vector3.Distance(Player.transform.position, _pozS.transform.position);
            }
            if (_dist1 < _dist2)
            {
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Mathf.Lerp(Player.transform.position.z, _pozZ1, 7 * Time.deltaTime));
            }
            else if (_dist1 > _dist2)
            {
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Mathf.Lerp(Player.transform.position.z, _pozZ2, 7 * Time.deltaTime));
            }
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
