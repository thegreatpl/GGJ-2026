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



    public BreathElement BreathElement; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaskElement = gameObject.GetComponent<RectTransform>();
        height = MaskElement.rect.yMax;
        SwitchMask = InputSystem.actions.FindAction("Sprint"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (SwitchMask.IsPressed())
        {
            if (!MaskAnimated)
            {
                if (MaskOn)
                {
                    StartCoroutine(PutMaskOff());
                    BreathElement.HoldBreath(); 
                }
                else
                {
                    StartCoroutine(PutMaskOn());
                    BreathElement.CanBreathe(); 
                }
            }
        }
    }


    IEnumerator PutMaskOn()
    {
        MaskAnimated = true;
        while (MaskElement.anchoredPosition.y > -(height - MaskSpeed))
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
