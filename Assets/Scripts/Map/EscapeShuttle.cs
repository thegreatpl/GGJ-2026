using System.Collections;
using TreeEditor;
using UnityEngine;

public class EscapeShuttle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //StartCoroutine(Launch()); 
            GameManager.Instance.Victory(); 
        }
    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds(0.1f); 
        //bring the player with us. 
        GameManager.Instance.Player.transform.parent = transform;

        while (true)
        {
            transform.position += Vector3.up;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
