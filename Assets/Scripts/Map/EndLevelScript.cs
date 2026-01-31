using UnityEngine;

public class EndLevelScript : MonoBehaviour
{
    public string NextLevel;

    public string StartLocationName = "Default"; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.LoadLevel(NextLevel, StartLocationName);   
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.LoadLevel(NextLevel, StartLocationName);
        }
    }

}
