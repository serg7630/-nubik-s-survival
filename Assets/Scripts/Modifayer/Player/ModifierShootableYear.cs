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
    }

    public override void Modify(PlayerController playerController, int index)
    {

        //Debug.LogError(typeModify+" тип модификатора и бонус перезарядки"+ reachargeTime);

        var playerCrowd = playerController.GetComponent<PlayerCrowd>();
        switch (index) {
            case 1: 
                playerCrowd.AddYearToCrowd(yearToAdd);
                break;
            case 2:
                //print("бонус перезарядки");
                playerCrowd.AddRechargeToCrowd(reachargeTime);
                
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
