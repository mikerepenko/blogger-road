using UnityEngine;
using System.Collections;

public class ScrollBig : MonoBehaviour{
    
    public GameObject panel;
    public Transform Stratpos;

    public float p;
    public float g;

    private void Start()
    {
        panel.transform.localPosition = new Vector3(Mathf.Abs(Stratpos.localPosition.x), transform.localPosition.y, transform.localPosition.z);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            p = Mathf.Abs(panel.transform.localPosition.x);
            g = Mathf.Abs(other.gameObject.transform.localPosition.x);
            other.gameObject.GetComponent<ActiveModel>().Big = true;
            if (Mathf.Abs(panel.transform.localPosition.x) > Mathf.Abs(other.gameObject.transform.localPosition.x) && Mathf.Abs(panel.transform.localPosition.x) < Mathf.Abs(other.gameObject.transform.localPosition.x))
            {
                panel.transform.localPosition = new Vector3(Mathf.Abs(other.gameObject.transform.localPosition.x), transform.localPosition.y, transform.localPosition.z);
            }
            else
            {
                if (Mathf.Abs(panel.transform.localPosition.x - 4f) > Mathf.Abs(other.gameObject.transform.localPosition.x))
                {
                    panel.transform.localPosition -= new Vector3(panel.transform.localPosition.x * Mathf.Lerp(0f, 1f, Time.deltaTime * 0.3f), transform.localPosition.y, transform.localPosition.z);
                }
                if (Mathf.Abs(panel.transform.localPosition.x + 4f) < Mathf.Abs(other.gameObject.transform.localPosition.x))
                {
                    panel.transform.localPosition += new Vector3(panel.transform.localPosition.x * Mathf.Lerp(0f, 1f, Time.deltaTime * 0.3f), transform.localPosition.y, transform.localPosition.z);
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            other.gameObject.GetComponent<ActiveModel>().Big = false;
        }
    }
}
