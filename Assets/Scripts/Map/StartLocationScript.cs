using UnityEngine;

/// <summary>
/// Does absolutely nothing except is somewhere where a player can spawn into a level. 
/// </summary>
public class StartLocationScript : MonoBehaviour
{
    public string LocationName; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameManager.Instance.CurrentMap.RegisterSpawnLocation(LocationName, transform.position);
    }

}
