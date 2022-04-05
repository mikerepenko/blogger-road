using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logmove : MonoBehaviour {
    
    public GameObject child;
    bool vniz;
    float TrY;

    void Start()
    {
        TrY = child.transform.position.y;
    }

    void Update()
    {
        if (vniz == false && child.transform.position.y < TrY)
        {
            child.transform.position += child.transform.up * Time.deltaTime * 4;
        }
        if (vniz == true && child.transform.position.y > TrY - 0.8f)
        {
            child.transform.position -= child.transform.up * Time.deltaTime * 4;
        }
        if (vniz == true && child.transform.position.y <= TrY - 0.8f)
            vniz = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponentInParent<OnLog>().PlayerOnLog = true;
            vniz = true;
        }
    }

    private void OnDestroy()
    {
        Destroy(transform.parent.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.GetComponentInParent<OnLog>().PlayerOnLog = false;
        }
    }
}
