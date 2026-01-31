using System.Collections;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject Door;

    public bool DoorOpen;

    public float DoorMovement = 0.1f; 

    float downY; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DoorOpen = false;
        downY = Door.transform.localPosition.y;
        StartCoroutine(DoorCoroutine()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DoorOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DoorOpen =false;
        }
    }

    IEnumerator DoorCoroutine()
    {
        while (true)
        {
            if (DoorOpen && Door.transform.localPosition.y < Door.transform.localScale.y + downY)
            {
                Door.transform.localPosition += new Vector3(0, DoorMovement);
            }
            else if (!DoorOpen && Door.transform.localPosition.y > downY)
            {
                Door.transform.localPosition -= new Vector3(0, DoorMovement);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
