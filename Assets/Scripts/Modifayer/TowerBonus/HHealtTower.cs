using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HHealtTower : MonoBehaviour, IDamageable
{

    [SerializeField] WievTower wievTower;
    public PlayerController controller;
    [SerializeField] private float _currentHitPoints;
    BonusAddPers _bonusAddPers;
    [SerializeField] bool BonusActivirovan=false;
    [SerializeField] GameObject _persNub;

    public void Damage(float damage)
    {

        _currentHitPoints -= damage;
        
        if (_currentHitPoints <= 0)
        {
            _currentHitPoints = 0;
            if (BonusActivirovan) return;
            _bonusAddPers.Modify(controller, _bonusAddPers.LevelPlayerAdd);
            _persNub.SetActive(false);
            ControlAgressEnemy.S.RemoveEnemyFromList(this.transform);
            GetComponent<BoxCollider>().isTrigger = true;
            BonusActivirovan=true;
            wievTower.destroyTower();
        }
        wievTower.WievCountOnTower(_currentHitPoints);
    }

   
    void Start()
    {

        wievTower=GetComponent<WievTower>();
        controller = GameObject.Find("PlayerCrowd").GetComponent<PlayerController>();
        _bonusAddPers=GetComponent<BonusAddPers>();
        wievTower.WievCountOnTower(_currentHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
