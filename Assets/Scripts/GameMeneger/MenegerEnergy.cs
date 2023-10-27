using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenegerEnergy : MonoBehaviour
{
    [Header("������ ��� ������� �������")]
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
        foreach (PlayerShooter shooter in playerShooter)  //����� � ������� ������ ������
        {
            valueRecharge += shooter.TimeShootDaley;
            valueDamage += shooter.ValueDamage;
        }
        float ValueEnergyRecharge = (valueRecharge / playerShooter.Count);  //�������� ������� �����������

        float ValueEnergyDamage = (valueDamage / playerShooter.Count);  //  ������� ����

        int CountShooter=playerShooter.Count;
        realEnergy = CountShooter * valueDamage / valMaxEnergy; //������ ������� �������

        ShowEnergyGroup(realEnergy);
    }


    private void ShowEnergyGroup(float ValueEnergy)  //����� ������� �� �����
    {
        Debug.LogError("������� �������� ������� " + ValueEnergy + " � ������������ " + valMaxEnergy);
        fuulEnergy.fillAmount = ValueEnergy / valMaxEnergy;

    }
    void Update()
    {
        
    }
}
