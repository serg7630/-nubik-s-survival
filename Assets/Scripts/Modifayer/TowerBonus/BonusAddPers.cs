using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAddPers : ModifierBase
{
    [Range(1, 3)]
    public int LevelPlayerAdd = 1;
    [SerializeField] private PlayerShooter[] shooterPrefabs;
    [SerializeField] private Transform PosPers;


    public override void Modify(PlayerController playerController, int index)
    {
        PlayerCrowd playerCrowd=playerController.GetComponent<PlayerCrowd>();
        playerCrowd.AddShooter(index);
    }

    void Start()
    {
        GameObject Pers = shooterPrefabs[LevelPlayerAdd - 1].gameObject;
        Instantiate(Pers,PosPers.position, Quaternion.Euler(new Vector3(0, 180, 0)),PosPers);
        Pers.transform.localScale = new Vector3(.6f, .9f, .6f);
        Pers.GetComponent<PlayerShooter>().enabled = false;
    }

    void Update()
    {
        
    }

   
}
