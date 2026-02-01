using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int CurrentHP; 

    public int MaxHP = 3;

    public DamageComponent DamageComponent; 

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

    public void TakeDamage()
    {
        CurrentHP--;
        //play damage sound here. 
        DamageComponent.ShowDamageWindow();
        DamageComponent.SetMaskDamageLevel(CurrentHP);

        if (CurrentHP <= 0 )
        {
            GameManager.Instance.GameOver();
        }
    }
}
