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


    private Camera CurrentCamera; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject); 
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
        yield return StartCoroutine(LoadLevelCoroutine("JokeLevel1", "Default"));  
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
        UI = Instantiate(ui);
        yield return null;
        var player = prefabManager.GetPrefab("Player");
        Player = Instantiate(player);
        yield return null;
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(UI);
    }

    public void LoadLevel(string levelName, string spawnloc)
    {
        StartCoroutine(LoadLevelCoroutine(levelName, spawnloc));
    }

    IEnumerator LoadLevelCoroutine(string levelname, string spawnloc)
    {
        SceneManager.LoadScene(levelname, LoadSceneMode.Single);
        yield return null;
        CurrentMap = FindAnyObjectByType<MapScript>(FindObjectsInactive.Include); 
        yield return null;
        Player.transform.position = CurrentMap.GetStartLocation(spawnloc); 

    }



    public void GameOver()
    {
        //insert game over screen here. 
        var gameover = UI.GetComponentInChildren<GameOverScreen>(); 

        if (gameover == null)
            BootToMenu(); 
        gameover.ShowGameOver();

    }


    public Camera GetSceneCamera()
    {
        if (CurrentCamera == null)
        {
            if (Player != null)
            {
                CurrentCamera = Player.GetComponentInChildren<Camera>();
            }
            //need to add a main menu camera finder here. 
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                return GameObject.FindFirstObjectByType<Camera>(); 
            }
        }

        return CurrentCamera;
    }


    public void Victory()
    {
        //insert you win screen here. 
        var gameover = UI.GetComponentInChildren<GameOverScreen>();

        if (gameover == null)
            BootToMenu();
        gameover.ShowVictory();


        
    }


    public void BootToMenu()
    {
        Destroy(Player);
        Destroy(UI);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Cursor.lockState = CursorLockMode.None;
    }
}
