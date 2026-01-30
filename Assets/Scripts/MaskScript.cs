using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaskScript : MonoBehaviour
{
    RectTransform MaskElement;

    public bool MaskOn;

    public bool MaskAnimated = false; 

    public float MaskSpeed = 0.1f;
    public float MaskAnimationSpeedSeconds = 0.1f; 

    float height;

    InputAction SwitchMask; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaskElement = gameObject.GetComponent<RectTransform>();
        height = MaskElement.rect.yMax; 

    }

    // Update is called once per frame
    void Update()
    {
        if (MaskOn && !MaskAnimated)
            StartCoroutine(PutMaskOff());
        else if (!MaskAnimated)
            StartCoroutine(PutMaskOn());

    }


    IEnumerator PutMaskOn()
    {
        MaskAnimated = true;
        while (MaskElement.anchoredPosition.y > -height)
        {
            MaskElement.localPosition = new Vector3(MaskElement.localPosition.x, MaskElement.localPosition.y - MaskSpeed);
            yield return new WaitForSeconds(MaskAnimationSpeedSeconds);
        }
        MaskOn = true; 
        yield return null; 
        MaskAnimated = false;
    }


    IEnumerator PutMaskOff()
    {
        MaskAnimated = true; 
        while (MaskElement.anchoredPosition.y < 0)
        {
            MaskElement.localPosition = new Vector3(MaskElement.localPosition.x,  MaskElement.localPosition.y + MaskSpeed);
            yield return new WaitForSeconds(MaskAnimationSpeedSeconds); 
        }
        MaskOn = false; 
        yield return null;

        MaskAnimated = false;
    }


}
