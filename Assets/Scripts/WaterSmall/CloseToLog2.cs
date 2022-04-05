using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseToLog2 : MonoBehaviour {

    public bool Close = false;
    public GameObject road;
    GameObject Player;

    public GameObject _pozF;
    public GameObject _pozS;
    public GameObject _pozT;

    public float speeed;

    float _pozZ1;
    float _pozZ2;
    float _pozZ3;

    float _dist1;
    float _dist2;
    float _dist3;


    private void Start()
    {
        speeed = road.GetComponent<RandomWater>().speed;
        Close = false;
        _pozZ1 = _pozF.transform.position.z;
        _pozZ2 = _pozS.transform.position.z;
        _pozZ3 = _pozT.transform.position.z;
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
        if (Close)
        {
            _pozZ1 = _pozF.transform.position.z;
            _pozZ2 = _pozS.transform.position.z;
            _pozZ3 = _pozT.transform.position.z;
            if (!Player.GetComponent<Move>().Jump)
            {
                _dist1 = Vector3.Distance(Player.transform.position, _pozF.transform.position);
                _dist2 = Vector3.Distance(Player.transform.position, _pozS.transform.position);
                _dist3 = Vector3.Distance(Player.transform.position, _pozT.transform.position);
            }
            if (_dist1 < _dist2 && _dist1 < _dist3)
            {
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Mathf.Lerp(Player.transform.position.z, _pozZ1, 7 * Time.deltaTime));
            }
            else if (_dist2 < _dist1 && _dist2 < _dist3)
            {
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Mathf.Lerp(Player.transform.position.z, _pozZ2, 7 * Time.deltaTime));
            }
            else if (_dist3 < _dist1 && _dist3 < _dist2)
            {
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Mathf.Lerp(Player.transform.position.z, _pozZ3, 7 * Time.deltaTime));
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
