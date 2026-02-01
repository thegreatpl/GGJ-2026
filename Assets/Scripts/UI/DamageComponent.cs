using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageComponent : MonoBehaviour
{
    public Image Image;

    public Image MaskImage; 

    public float SecondsToShow = 1f;

    public Sprite DamagedMask;

    public Sprite HeavilyDamagedMask; 

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

    public void SetMaskDamageLevel(int level)
    {
        if (level == 2)
        {
            MaskImage.sprite = DamagedMask; 
        }
        else if (level == 1)
        {
            MaskImage.sprite = HeavilyDamagedMask;
        }
    }
}
