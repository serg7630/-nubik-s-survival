using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarEnemy : MonoBehaviour
{
    

    [SerializeField] private Image FullBar;
    public float MaxHealth;
    [SerializeField] private float Damage;


    private void Start()
    {
        ShowBarHealt(MaxHealth);
    }
    void Update()
    {
        
    }
    public void SetValue(float LostHealt)
    {
        float RealHeal = LostHealt / MaxHealth;
        
        ShowBarHealt(RealHeal);
    }
    private void ShowBarHealt(float Healt)
    {
        FullBar.fillAmount = Healt;
        //Debug.LogError(Healt);
    }
}
