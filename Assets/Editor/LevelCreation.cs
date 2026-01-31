using Mono.Cecil;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;
using static PlasticPipe.PlasticProtocol.Messages.Serialization.ItemHandlerMessagesSerialization;

public class LevelCreation : MonoBehaviour
{

    [MenuItem("LevelEditing/New Level")]
    static void CreateNewLevel()
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        scene.name = "New Level";

        var tilemap = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/LevelEditing/MapObject.prefab");
        var localtilemap = PrefabUtility.InstantiatePrefab(tilemap) as GameObject;
        PrefabUtility.UnpackPrefabInstance(localtilemap, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);

        var gameManager = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/GameManager.prefab");
        PrefabUtility.InstantiatePrefab(gameManager);
        AddFog(); 
    }

    [MenuItem("LevelEditing/GenerateWalls")]
    static void GenerateWalls()
    {
        var editorMap = SceneAsset.FindAnyObjectByType<EditorMap>();

        var floorPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Terrain/Floor.prefab");
        var wallX = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Terrain/XWall.prefab");
        var wallZ = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Terrain/ZWall.prefab");
        var roofprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Terrain/Roof.prefab");


        var waypointPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/MapElements/Waypoint.prefab"); 


        var map = editorMap.Tilemap;

        var bounds = map.cellBounds;

        for (int xdx = bounds.xMin; xdx < bounds.xMax; xdx++)
        {
            for (int ydx = bounds.yMin; ydx < bounds.yMax; ydx++)
            {
                var loc = new Vector3Int(xdx, ydx);
                var tile = map.GetTile(loc);
                if (tile == null)
                    continue;



                GenerateWallsOnTiles(map, loc,floorPrefab, roofprefab, wallZ, wallX); 

                if (tile.name == "waypointIndicator")
                {
                    var waypoint = PrefabUtility.InstantiatePrefab(waypointPrefab) as GameObject;
                    waypoint.transform.position = map.GetCellCenterWorld(loc); 


                }

            }

        }

    }

    static void GenerateWallsOnTiles(Tilemap map, Vector3Int tilepos, GameObject floorprefab,GameObject roofprefab, GameObject wallZ, GameObject wallX)
    {
        var worldpos = map.GetCellCenterWorld(tilepos);
        var tilesize = map.layoutGrid.cellSize;


        var floor = PrefabUtility.InstantiatePrefab(floorprefab) as GameObject;
        floor.transform.position = worldpos;
        var roof = PrefabUtility.InstantiatePrefab(roofprefab) as GameObject;
        roof.transform.position = new Vector3(worldpos.x, worldpos.y + tilesize.z, worldpos.z);

        if (map.GetTile(new Vector3Int(tilepos.x + 1, tilepos.y)) == null)
        {
            //xwall
            var wall = PrefabUtility.InstantiatePrefab(wallX) as GameObject;
            wall.transform.position = new Vector3(worldpos.x + tilesize.x/2, worldpos.y + tilesize.z / 2, worldpos.z);
        }
        if (map.GetTile(new Vector3Int(tilepos.x - 1, tilepos.y)) == null)
        {
            //xwall
            var wall = PrefabUtility.InstantiatePrefab(wallX) as GameObject;
            wall.transform.position = new Vector3(worldpos.x - tilesize.x / 2, worldpos.y + tilesize.z / 2, worldpos.z);
        }
        if (map.GetTile(new Vector3Int(tilepos.x, tilepos.y + 1)) == null)
        {
            //zwall
            var wall = PrefabUtility.InstantiatePrefab(wallZ) as GameObject;
            wall.transform.position = new Vector3(worldpos.x, worldpos.y + tilesize.z/2, worldpos.z + tilesize.y /2);
            wall.transform.eulerAngles 
                = new Vector3(wall.transform.rotation.eulerAngles.x, 180, wall.transform.rotation.eulerAngles.z);
        }
        if (map.GetTile(new Vector3Int(tilepos.x, tilepos.y - 1)) == null)
        {
            //zwall
            var wall = PrefabUtility.InstantiatePrefab(wallZ) as GameObject;
            wall.transform.position = new Vector3(worldpos.x, worldpos.y + tilesize.z / 2, worldpos.z - tilesize.y / 2);
        }



    }

    [MenuItem("LevelEditing/Add all scenes to build")]
    static void CompileScenes()
    {
        List<EditorBuildSettingsScene> scenes = new List<EditorBuildSettingsScene>();

        var files = Directory.GetFiles("Assets/Scenes").Where(x => Path.GetExtension(x) == ".unity").ToList();

        var mainmenu = files.FirstOrDefault(x => Path.GetFileName(x) == "MainMenu.unity");
        scenes.Add(new EditorBuildSettingsScene(mainmenu, true)); 
        files.Remove(mainmenu);

        foreach (var file in files) 
        {
            scenes.Add(new EditorBuildSettingsScene(file, true));
        }
        EditorBuildSettings.scenes = scenes.ToArray();

    }

    [MenuItem("LevelEditing/Add Fog")]
    static void AddFog()
    {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = 0.05f;
        RenderSettings.fogColor = Color.black; 
    }
}
