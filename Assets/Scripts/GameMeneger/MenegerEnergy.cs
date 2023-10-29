using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenegerEnergy : MonoBehaviour
{


    [Header("������ ��� ������� �������")]
    [Range(1, 10)]
    [SerializeField] int ValueCoofecientEnergy;
    public int maxShooters=8;
    [SerializeField] private float minReachargeTime=0.03f;
    [SerializeField] private float maxfirepower=50;
    [SerializeField] private Image fuulEnergy;
    [SerializeField] private float valMaxEnergy;
    [SerializeField] private float realEnergy;

    //[SerializeField] PlayerShooter shooter;
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
            //Debug.LogError(shooter.name);

            valueRecharge += shooter.TimeShootDaley;
            //print(valueRecharge);

            valueDamage += shooter.ValueDamage;
            //print(valueDamage);
        }
        
        
        float ValueEnergyRecharge = (valueRecharge / playerShooter.Count);  //�������� ������� �����������

        float ValueEnergyDamage = (valueDamage / playerShooter.Count);  //  ������� ����

        
        //int CountShooter=playerShooter.Count;
        int CountShooter = maxShooters;
        //Debug.LogError("������� �������� ����������� " + ValueEnergyRecharge + " ������� �������� ����� " + ValueEnergyDamage+" ����������� �������� "+CountShooter);
        realEnergy = CountShooter * ValueEnergyDamage / ValueEnergyRecharge; //������ ������� �������

        ShowEnergyGroup(realEnergy);
    }


    private void ShowEnergyGroup(float ValueEnergy)  //����� ������� �� �����
    {
        //Debug.Log(ValueEnergy);
        //Debug.LogError("������� �������� ������� " + ValueEnergy + " � ������������ " + valMaxEnergy);
        fuulEnergy.fillAmount = (ValueEnergy* ValueCoofecientEnergy) / valMaxEnergy;

    }
    void Update()
    {
        
    }
}
