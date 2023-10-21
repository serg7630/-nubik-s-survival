using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("добавление цели")]
    public ControlAgressEnemy CAE;
    [SerializeField] Transform EnemyTarget;
   [SerializeField] private Transform GoalTarget;
    public float SpeedRotation = 2;

    [Header("параметры стрельбы")]
    [SerializeField] private float defaultShootDelay = 1f;
    [SerializeField] private float damagePerShootable = 100f;
    [SerializeField] private Shootable shootablePrefab;
    [SerializeField] private Transform shootFrom;
    [SerializeField] private float damageAddPerYear = 2f;
    private float _shootDelay;
    private float _runningTimer;
    private float _damagePerShootable;
    private int _year = 0;

    [Header("Анимация")]
    [SerializeField] Animator _animator;
    public bool PlayerRun;

    private void Start()
    {
        _shootDelay = defaultShootDelay;
        _damagePerShootable = damagePerShootable;
        _animator.SetBool("Run", true);
        GoalTarget = GameObject.Find("GoalTarget").transform;
    }

    private void Update()
    {
        if (EnemyTarget==null)
        {
            EnemyTarget = GoalTarget;
        }
        Vector3 directions = EnemyTarget.position - transform.position;
        if (transform.position.z > EnemyTarget.position.z)
        {
            CAE.RemoveEnemyFromList(EnemyTarget);
            return;
        }
        Quaternion rotation = Quaternion.LookRotation(directions);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, SpeedRotation * Time.deltaTime);

        
        
            _runningTimer += Time.deltaTime;
        if (_runningTimer >= _shootDelay)
        {
            if (CAE.targetsEnemy.Count==0) return;
            if (CAE.targetsEnemy.Count == 1)
            {
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
            Shoot();
        }

       


    }

    public void UpdateWeaponYear(int toAdd)
    {
        _year += toAdd;
        float damageToAdd = _year * damageAddPerYear;
        _damagePerShootable = damagePerShootable + damageToAdd;
    }

    public void Shoot()
    {
        Instantiate(shootablePrefab, shootFrom.position, Quaternion.identity).Init(_damagePerShootable);
    }
}