using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMonetka : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Monet").GetComponent<Score>().Monets+=1;
            Destroy(transform.gameObject);
        }
    }
}
