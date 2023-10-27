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

    [SerializeField] private float yearToAdd = 5;
    [SerializeField] private float reachargeTime = .05f;
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

        Debug.LogError(typeModify);
        var playerCrowd = playerController.GetComponent<PlayerCrowd>();
        switch (index) {
            case 1: 
                playerCrowd.AddYearToCrowd(yearToAdd);
                break;
            case 2:
                playerCrowd.AddRechargeToCrowd(reachargeTime);
                break;

        }
        Destroy(this.gameObject);
            
    }
}
