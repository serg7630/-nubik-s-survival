using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierCrowd : ModifierBase
{
    [Range(1, 3)]
    public int LevelPlayerAdd = 1;
    [SerializeField] private ModifierView modifierView;
    [SerializeField] private int crowdModifyAmount = 2;
    private bool _isPositive;

    private void Start()
    {
        
        _isPositive = crowdModifyAmount > 0;
        //modifierView.SetVisuals(_isPositive, crowdModifyAmount);
    }


    public override void Modify(PlayerController playerController, int index)
    {
        //var playerCrowd = playerController.GetComponent<PlayerCrowd>();
        //for (int i = 0; i < Mathf.Abs(crowdModifyAmount); i++)
        //{
        //    if (_isPositive) playerCrowd.AddShooter(index);
        //    else playerCrowd.RemoveShooter();
        //}
        //Destroy(this.gameObject);
    }
}
