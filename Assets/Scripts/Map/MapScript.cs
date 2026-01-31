using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public Dictionary<string, Vector3> StartLocations; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetStartLocation(string locationName)
    {
        if (StartLocations.ContainsKey(locationName))
        {
            return StartLocations[locationName];
        }
        return StartLocations.ElementAt(0).Value; 
    }
}
