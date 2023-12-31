using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeModify 
{
    None,
    firepower,
    recharge
    
}
public class ModifierShootableYear : ModifierBase
{
    public TypeModify typeModify=TypeModify.None;

    [SerializeField] private float yearToAdd = 2;
    [SerializeField] private float reachargeTime = .03f;
    [SerializeField] private ModifierView modifierView;
    public int indexModify;
    [SerializeField] bool StartModifier;
    

    private void Start()
    {
        var isPositive = yearToAdd > 0;
        
        if (typeModify == TypeModify.firepower)
        {
            indexModify = 1;
            modifierView.SetVisuals(isPositive, indexModify);
        }
        else
        {
            indexModify = 2;
            modifierView.SetVisuals(isPositive, indexModify);
        }
        if (StartModifier) indexModify = 3;
    }

    public override void Modify(PlayerController playerController, int index)
    {

        //Debug.LogError(typeModify+" ��� ������������ � ����� �����������"+ reachargeTime);

        var playerCrowd = playerController.GetComponent<PlayerCrowd>();
        switch (index) {
            case 1: 
                playerCrowd.AddYearToCrowd(yearToAdd);
                break;
            case 2:
                //print("����� �����������");
                playerCrowd.AddRechargeToCrowd(reachargeTime);
                
                break;
            case 3:
                //print("����� �����������");
                playerCrowd.AddRechargeToCrowd(reachargeTime);
                playerCrowd.AddYearToCrowd(yearToAdd);
                break;

        }
        Destroy(this.gameObject);
            
    }
    public void AddRecharge()
    {
        reachargeTime += .03f ;
    }
    public void AddDamage()
    {
        yearToAdd++;
    }
}
