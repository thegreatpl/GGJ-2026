using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int CurrentHP; 

    public int MaxHP = 3;

    public DamageComponent DamageComponent;

    public AudioSource DamageAudio;

    public AudioClip ImpactClip; 
    public AudioClip SuffocateClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHP = MaxHP; 
        DamageComponent = GameManager.Instance.UI.GetComponentInChildren<DamageComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(string source)
    {
        CurrentHP--;
        //play damage sound here. 
        if (source == "attk")
        {
            DamageAudio.clip = ImpactClip;
            DamageAudio.Play();
        }
        else if (source == "suffo")
        {
            DamageAudio.clip = SuffocateClip;
            DamageAudio.Play();
        }

            DamageComponent.ShowDamageWindow();
        DamageComponent.SetMaskDamageLevel(CurrentHP);

        if (CurrentHP <= 0 )
        {
            GameManager.Instance.GameOver();
        }
    }
}
