using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnergyPlayer : MonoBehaviour
{
    public static StartEnergyPlayer S;

    [SerializeField] PlayerCrowd playerCrowd;

    public int CountDamageUpgrate;
    public int CountRechargeUpgrate;
    void Start()
    {
        if (S == null) S = this;
        //Invoke("upgratePlayers", .2f);
    }

   public void upgratePlayers()
    {
        playerCrowd.upgradePlayerOnStart(CountRechargeUpgrate, CountDamageUpgrate);
        playerCrowd.StartGame();
        playerCrowd.SetEnergy();
        GetComponent<PlayerMoving>().enabled = true;
    }
    void Update()
    {
        
    }
    public void AddRecharge()
    {
        CountRechargeUpgrate++;
    }
    public void AddPower()
    {
        CountDamageUpgrate++;
    }
}
