using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public Dictionary<string, Vector3> StartLocations; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var playerstartlocs = FindObjectsByType<StartLocationScript>(FindObjectsSortMode.None);
        foreach (var loc in playerstartlocs)
        {
            RegisterSpawnLocation(loc.LocationName, loc.transform.position); 
        }
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


    public void RegisterSpawnLocation(string locationName, Vector3 location)
    {
        if (StartLocations == null)
            StartLocations = new Dictionary<string, Vector3>();

        if (StartLocations.ContainsKey(locationName))
            return; 

        StartLocations.Add(locationName, location);
    }
}
