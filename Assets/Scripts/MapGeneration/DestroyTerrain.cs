using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTerrain : MonoBehaviour {

    public GameObject Player;

    private void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Terrain" || other.gameObject.tag == "Grass" || other.gameObject.tag == "Delete")
        {
            Destroy(other.transform.parent.gameObject);
        }
        if (other.gameObject.tag == "Tree")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Water")
        {
            Destroy(other.transform.parent.parent.gameObject);
        }
    }

}
