using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Image PanelImage; 

    public GameObject DiedText;

    public GameObject VictoryText; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideScreen()
    {
        PanelImage.color = Color.clear; 
        DiedText.SetActive(false);
        VictoryText.SetActive(false);
    }


    public void ShowGameOver()
    {
        StartCoroutine(GameOver()); 
    }

    IEnumerator GameOver()
    {
        DiedText?.SetActive(true);
        PanelImage.color = Color.black; 

        yield return new WaitForSeconds(10);
        HideScreen(); 
        GameManager.Instance.BootToMenu(); 
    }


    public void ShowVictory()
    {
        StartCoroutine(Victory());
    }

    IEnumerator Victory()
    {
        VictoryText?.SetActive(true);
        PanelImage.color = Color.black;

        yield return new WaitForSeconds(10);
        HideScreen();
        GameManager.Instance.BootToMenu();
    }
}
