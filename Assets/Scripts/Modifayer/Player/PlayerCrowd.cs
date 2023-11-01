
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class PlayerCrowd : MonoBehaviour
{
    [Header("установка энергии")]
    [SerializeField] private MenegerEnergy _menegerEnergy;

    [SerializeField] private int crowdSizeForDebug = 5;
    [Header("Стартовые данные")]
    [SerializeField] private int startingCrowdSize = 1;
    [Range(1, 3)]
    [SerializeField] private int startIndexShoot;

    [SerializeField] private PlayerShooter[] shooterPrefabs;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    public List<PlayerShooter> _shooters = new List<PlayerShooter>();
    public List<PlayerShooter> Shooters => _shooters;
    [ContextMenu("Set")]
    public void Debug_ResizeCrowd() => Set(crowdSizeForDebug);

    [SerializeField] private TMP_Text yearText;
    [SerializeField] BoxCollider PlayerColider;
    [SerializeField] private ControlAgressEnemy _cae;

    private float _year;
    private float _recharge;

    [Header("Расчет энергии")]
    [SerializeField] MenegerEnergy _energy;

    private void Start()
    {

        //_menegerEnergy.maxShooters = crowdSizeForDebug;
        Set(startingCrowdSize);
        //yearText.text = _year.ToString();
        //Invoke("SetEnergy", .5f);
        //SetEnergy();
        Invoke("SetEnergy", .2f);

    }

    public void AddRechargeToCrowd(float RechargTime)
    {
        _recharge = 0;
        _recharge -= RechargTime;
        foreach (PlayerShooter shooter in _shooters)
        {
            shooter.UpdateWeaponRecharge(_recharge);
            //Debug.LogError(_recharge+" первое передаваемое значение");
        }
        //yearText.text = _year.ToString();


    }

    public void AddYearToCrowd(float yearToAdd)
    {
        _year += yearToAdd;
        foreach (PlayerShooter shooter in _shooters)
        {
            //Debug.LogError(yearToAdd);
            shooter.UpdateWeaponYear(yearToAdd);
        }
        //yearText.text = _year.ToString();
    }
    public void Set(int amount)
    {
        if (_shooters.Count == amount) return;
        bool needToRemove = amount < _shooters.Count;
        bool needToAdd = amount > _shooters.Count;
        while (amount != _shooters.Count)
        {
            if (needToRemove) RemoveShooter();
            else if (needToAdd) AddShooter(startIndexShoot);
        }
       
    }

    public bool CanAdd()
    {
        return _shooters.Count + 1 <= spawnPoints.Count;
    }

    public bool CanRemove()
    {
        return _shooters.Count - 2 >= 0;
    }
    public void RemoveShooter()
    {
        if (!CanRemove()) return;
        PlayerShooter lastShooter = _shooters[_shooters.Count - 1];
        _shooters.Remove(lastShooter);
        Destroy(lastShooter.gameObject);
        if (_shooters.Count <= 2) ColliderMinus();
        SetEnergy();
    }
    public void RemoveThisShooter(PlayerShooter playerShooter)
    {
        if (!CanRemove()) return;
        _shooters.Remove(playerShooter);
        
        Destroy(playerShooter.gameObject);
        if (_shooters.Count <= 2) ColliderMinus();
        SetEnergy();
    }

    public void AddShooter(int index)
    {
        if (!CanAdd()) return;
        int lastShooterIndex = _shooters.Count - 1;
        Vector3 position = spawnPoints[lastShooterIndex + 1].position;
        
        PlayerShooter shooter = Instantiate(shooterPrefabs[index-1], position,Quaternion.identity /*Quaternion.Euler(0,0,0)*/, transform);
        shooter.GetComponent<PlayerShooter>().CAE = _cae;
        //shooter.GetComponent<PlayerShooter>().enabled = true;
        shooter.GetComponent<PlayerShooter>().PCrowd = this;
        shooter.transform.localScale = new Vector3(1, 1, 1);
        _shooters.Add(shooter);
        if(_shooters.Count >= 3)  ColliderPlus();
        SetEnergy();

    }
    void ColliderPlus()
    {
        PlayerColider.size=new Vector3(2.5f,1,1);
    }
    void ColliderMinus()
    {
        PlayerColider.size = new Vector3(1f, 1, 1);
    }

    public void SetEnergy()
    {
        _menegerEnergy.CalculationRealEnergy(_shooters);
    }

    public void AnimateIdle()
    {
        foreach (var shooter in _shooters)
        {
            //Debug.LogError("idle");
            shooter.GetComponent<PlayerShooter>().PlayerIdle();
        }
    }

    public void FinishDirect()
    {
        foreach (var shooter in _shooters)
        {
            //Debug.LogError("finish");
            shooter.GetComponent<PlayerShooter>().Finishen=true;
        }
    }


    //public void upgradePlayerOnStart(int Recharge, int Damage)
    //{
    //    for (int i = 0; i < Recharge; i++)
    //    {
    //        AddRechargeToCrowd(0.03f);
    //    }
    //    for (int i = 0; i < Damage; i++)
    //    {
    //        AddYearToCrowd(3);
    //    }
    //}
    public void StartGame()
    {
        foreach (var shooter in _shooters)
        {
            //Debug.LogError("finish");
            shooter.GetComponent<PlayerShooter>().enabled = true;
        }
    }
    public void DeadPlayers()
    {
        foreach (var shooter in _shooters)
        {
            //Debug.LogError("Dead");
            shooter.GetComponent<PlayerShooter>().DeadPlayer();
            shooter.GetComponent<PlayerShooter>().enabled=false;
        }
        GameMeneger.S.GameOverFinishInvoke();
    }
}
