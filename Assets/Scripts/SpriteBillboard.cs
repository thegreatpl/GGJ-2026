using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, 
             GameManager.Instance.GetSceneCamera().transform.rotation.eulerAngles.y, 0f);    
    }
}
