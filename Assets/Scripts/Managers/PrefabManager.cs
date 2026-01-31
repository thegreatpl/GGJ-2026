using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{

    public List<PrefabType> Prefabs; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public GameObject GetPrefab(string prefabName)
    {
        return Prefabs.FirstOrDefault(x => x.Name == prefabName)?.Prefab;
    }

}
