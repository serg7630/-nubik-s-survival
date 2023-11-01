using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public PlayerCrowd PCrowd;

    [Header("добавление цели")]
    public ControlAgressEnemy CAE;
     Transform EnemyTarget;
   [SerializeField] private Transform GoalTarget;
    public float SpeedRotation = 5;

    [Header("параметры стрельбы")]
    [SerializeField] private float defaultShootDelay = 1f;
    [SerializeField] private float damagePerShootable = 100f;
    [SerializeField] private Shootable shootablePrefab;
    [SerializeField] private Transform shootFrom;
    [SerializeField] private float damageAddPerYear = 2f;
    [SerializeField] private float _shootDelay;
    private float _runningTimer;
   [SerializeField] private float _damagePerShootable;
    private float _year = 0;
    private float _recharg = 0;
    [Header("ћаксимальна€ прокачка ")]
     public float maxShootDalay = 0.03f;
     public float maxShootDamag = 100f;

    [Header("јнимаци€")]
    [SerializeField] Animator _animator;
    public bool PlayerRun;
    public bool Finishen;


    private bool _finishScene = false;
    private void Start()
    {
        _shootDelay = defaultShootDelay;
        _damagePerShootable = damagePerShootable;
        _animator.SetBool("Run", true);
        GoalTarget = GameObject.Find("GoalTarget").transform;
    }

    private void Update()
    {
        //if (_finishScene) return;
        //поиск ближайшего врага
        if (EnemyTarget==null)
        {
            EnemyTarget = GoalTarget;
            _animator.SetBool("Fire", false);
            
        }
        Vector3 directions = EnemyTarget.position - transform.position;
        if (transform.position.z > EnemyTarget.position.z)
        {
            CAE.RemoveEnemyFromList(EnemyTarget);
            EnemyTarget = null;
            
            return;
        }
        if (EnemyTarget.CompareTag("enemyZomb"))
        {
            if (EnemyTarget.GetComponent<ZombiControl>())
            {
                if (EnemyTarget.GetComponent<ZombiControl>().Dead)
                {
                    CAE.RemoveEnemyFromList(EnemyTarget);
                    EnemyTarget = null;
                }
                   
            }
        }
        Quaternion rotation = Quaternion.LookRotation(directions);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, SpeedRotation * Time.deltaTime);

        
        
            _runningTimer += Time.deltaTime;
        if (_runningTimer >= _shootDelay)
        {
            if (CAE.targetsEnemy.Count == 0)
            {
                if (Finishen)
                {
                    //Debug.LogError("Victory");
                    _animator.SetTrigger("FinalDance");
                    _finishScene = true;
                }
                return;
            }
            if (CAE.targetsEnemy.Count == 1)
            {
                //Debug.LogError("1 enemy");
                EnemyTarget = CAE.targetsEnemy[0];
            }
            else
            {
                EnemyTarget = CAE.FindNearEnemy(this.transform);
            }
            //if (transform.position.z > EnemyTarget.position.z)
            //{
            //    CAE.RemoveEnemyFromList(EnemyTarget);
            //    return;
            //}

            _runningTimer = 0f;
            if (!EnemyTarget)
            {
                
                return;
            }
            ZombiControl ZC = EnemyTarget.GetComponent<ZombiControl>();
            if (ZC)
            {
                if (ZC.Dead)
                {
                    EnemyTarget = null;
                    return;
                }
            }
            Enemy enemy = EnemyTarget.GetComponent<Enemy>();
            if (enemy) enemy.shooter = this;
            _animator.SetBool("Fire", true);
            _animator.SetBool("NoTarget", false);
            Shoot(EnemyTarget.transform);
        }

       


    }

    public void UpdateWeaponRecharge(float rechargTime)
    {
        _recharg = rechargTime;
        //Debug.LogError(_recharg+" получаемое  значение у игрока");
        _shootDelay += _recharg;
        if (_shootDelay >= 1.2) _shootDelay = 1.2f;
        if (_shootDelay <= 0.03) _shootDelay = 0.03f;
        //Debug.LogError(_shootDelay+" итоговое значение");
        PCrowd.SetEnergy();

    }
    public void UpdateWeaponYear(float toAdd)
    {
        _year += toAdd;
        //Debug.Log(_year);
        float damageToAdd = _year * damageAddPerYear;

        _damagePerShootable = damagePerShootable + damageToAdd;
        if (_damagePerShootable <= 4) _damagePerShootable = 4;
        if (_damagePerShootable >= maxShootDamag) _damagePerShootable = maxShootDamag;
        PCrowd.SetEnergy();
        //Debug.Log(_damagePerShootable);
    }

    public void Shoot(Transform enemy)
    {
        Vector3 directions = EnemyTarget.position - transform.position;

        Instantiate(shootablePrefab, shootFrom.position, /*Quaternion.Euler(directions)*/this.transform.rotation).Init(_damagePerShootable);
    }
    public void TargetNuul()
    {
        EnemyTarget=null;
    }

    public float TimeShootDaley => _shootDelay;
    public float ValueDamage => _damagePerShootable;

    public void PlayerIdle()
    {
        _animator.SetBool("final", true);
        //_animator.SetBool("Idle", true);
        _animator.SetBool("Run", false);
    }
   public void DeadPlayer()
    {
        _animator.SetBool("Fire", false);
        _animator.SetBool("Run", false);
        _animator.SetTrigger("Dead");
    }

    
}