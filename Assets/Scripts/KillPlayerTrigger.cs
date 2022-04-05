using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerTrigger : MonoBehaviour {

    GameObject Died;
    bool die;
    Collider col;
    float close;
    float PosX;
    float razn;
    public AudioSource kill;

    public bool yeah;

    private void Start()
    {
        col = GetComponent<Collider>();
        Died = GameObject.Find("PlayerMain");
        close = col.bounds.extents.z;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            kill.Play();
            if (gameObject.tag == "Delete")
            {
                die = true;
                PosX = Died.transform.position.x;
                razn = Died.transform.position.z - transform.position.z;
                if (Close())
                    yeah = true;
                StartCoroutine(Die());
            }
            else
            {
                Died.GetComponent<Die>().dead = true;
            }
        }
    }

    private void Update()
    {
        if (die == true)
        {
            if(yeah)
                Died.transform.position = new Vector3(Died.transform.position.x, 74f,Died.transform.position.z);
            else
                Died.transform.position = new Vector3(PosX, Died.transform.position.y, transform.position.z + razn);
        }
    }

    IEnumerator Die()
    {
        Died.GetComponent<Die>().dead1 = true;
        Died.GetComponentInChildren<Animator>().enabled = false;
        Died.GetComponent<Move>().enabled = false;
        if (!yeah)
            Died.transform.localScale = new Vector3(0.1f, Died.transform.localScale.y, Died.transform.localScale.z);
        else Died.transform.localScale = new Vector3(Died.transform.localScale.x, 0.1f, Died.transform.localScale.z);
        yield return new WaitForSeconds(1.5f);
        Died.GetComponent<Die>().dead = true;
    }
    bool Close()
    {
        return Physics.Raycast(transform.position, Vector3.forward, close + 1f);
    }
}
