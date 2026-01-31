using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;



    public PrefabManager prefabManager;

    public GameObject Player;

    public GameObject UI; 

    public MapScript CurrentMap; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null)
        {
            return; 
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        prefabManager = GetComponent<PrefabManager>();

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            StartCoroutine(StartTestLevel()); 
        }
    }

    IEnumerator StartTestLevel()
    {
        yield return StartCoroutine(SpawnPlayer());
        yield return StartCoroutine(LoadLevelCoroutine(SceneManager.GetActiveScene().name, "Default")); 
    }

    public void StartNewGame()
    {
        StartCoroutine(StartGame()); 
    }

    IEnumerator StartGame()
    {
        yield return StartCoroutine(SpawnPlayer());
        yield return StartCoroutine(LoadLevelCoroutine("", "")); //TODO: First level name here. 
    }

    IEnumerator SpawnPlayer()
    {
        if (Player != null)
        {
            Destroy(Player);
        }
        if (UI != null)
            Destroy(UI); 

        var ui = prefabManager.GetPrefab("UI");
        var uiobj = Instantiate(ui);
        yield return null;
        var player = prefabManager.GetPrefab("Player");
        Player = Instantiate(player);
        yield return null;
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(uiobj);
    }

    public void LoadLevel(string levelName, string spawnloc)
    {
        StartCoroutine(LoadLevelCoroutine(levelName, spawnloc));
    }

    IEnumerator LoadLevelCoroutine(string levelname, string spawnloc)
    {
        SceneManager.LoadScene(levelname, LoadSceneMode.Single);
        yield return null;
        CurrentMap = FindFirstObjectByType<MapScript>(); 
        yield return null;
        Player.transform.position = CurrentMap.GetStartLocation(spawnloc); 

    }



    public void GameOver()
    {
        Destroy(Player); 
        Destroy(UI); 
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); 
    }

}
