using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BreathElement : MonoBehaviour
{
    public Image BreathElementImg;

    public float BreathTime; 

    float width;


    bool holdingBreath; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BreathElementImg = GetComponent<Image>();
        width = BreathElementImg.rectTransform.sizeDelta.x;
        holdingBreath = false;
        BreathElementImg.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HoldBreath()
    {
        if (holdingBreath)
            return;         
        holdingBreath = true; 
        BreathElementImg.gameObject.SetActive(true);
        StartCoroutine(HoldingBreath());
    }

    public void CanBreathe()
    {        
        holdingBreath = false;
        BreathElementImg.gameObject.SetActive(false);
        StopCoroutine(HoldingBreath());
        BreathElementImg.rectTransform.sizeDelta = new Vector2(  
            width, 
            BreathElementImg.rectTransform.sizeDelta.y);

    }

    IEnumerator HoldingBreath()
    {
        float breathetime = BreathTime;

        while(breathetime > 0)
        {   
            //put this at the beginning so the counter starts with the exact amount of seconds. 
            yield return new WaitForSeconds(1f);

            if (!holdingBreath)
            {
                BreathElementImg.rectTransform.sizeDelta = new Vector2(
                    width,
                    BreathElementImg.rectTransform.sizeDelta.y);
                yield break;
            }

            BreathElementImg.rectTransform.sizeDelta = new Vector2(
                (breathetime/BreathTime) * width, 
                BreathElementImg.rectTransform.sizeDelta.y );
            breathetime--;
        }

        yield return null;
        //insert game over here. 
        while ( holdingBreath )
        {
            GameManager.Instance.Player?.GetComponent<PlayerHealth>().TakeDamage("suffo");
            yield return new WaitForSeconds(1f); 
        }
    }
}
