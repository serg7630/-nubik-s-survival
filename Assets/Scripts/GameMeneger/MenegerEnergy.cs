using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenegerEnergy : MonoBehaviour
{
    [Header("данные для расчета энергии")]
    [SerializeField] private int maxShooters=8;
    [SerializeField] private float minReachargeTime=0.03f;
    [SerializeField] private float maxfirepower=100;
    [SerializeField] private Image fuulEnergy;
    [SerializeField] private float valMaxEnergy;
    [SerializeField] private float realEnergy;

    [SerializeField] PlayerShooter shooter;
    private float _maxValueEnergy;
    void Start()
    {
        //minReachargeTime = shooter.maxShootDalay;
        //maxfirepower = shooter.maxShootDamag;
        calculationMaxEnergy();
    }

    private void calculationMaxEnergy()
    {
         valMaxEnergy = maxShooters * maxfirepower/minReachargeTime;

    }

    public void CalculationRealEnergy(List<PlayerShooter> playerShooter)
    {
        float valueRecharge = 0;
        float valueDamage = 0;
        foreach (PlayerShooter shooter in playerShooter)  //берем у каждого шутера данные
        {
            valueRecharge += shooter.TimeShootDaley;
            valueDamage += shooter.ValueDamage;
        }
        float ValueEnergyRecharge = (valueRecharge / playerShooter.Count);  //значение средней перезарядки

        float ValueEnergyDamage = (valueDamage / playerShooter.Count);  //  средний урон

        int CountShooter=playerShooter.Count;
        realEnergy = CountShooter * valueDamage / valMaxEnergy; //расчет текущей энергии

        ShowEnergyGroup(realEnergy);
    }


    private void ShowEnergyGroup(float ValueEnergy)  //вывод энергии на экран
    {
        Debug.LogError("текущее значении энергии " + ValueEnergy + " и максимальгое " + valMaxEnergy);
        fuulEnergy.fillAmount = ValueEnergy / valMaxEnergy;

    }
    void Update()
    {
        
    }
}
