using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageComponent : MonoBehaviour
{
    public Image Image;

    public float SecondsToShow = 1f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Image = GetComponent<Image>(); 
        Image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDamageWindow()
    {
        StartCoroutine(DamageDisplay());
    }

    IEnumerator DamageDisplay()
    {
        Image.enabled = true;
        yield return new WaitForSeconds(SecondsToShow);
        Image.enabled = false;
    }
}
