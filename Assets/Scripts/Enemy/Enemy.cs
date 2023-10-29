using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] ZombiControl control;
    [SerializeField] private float hitPoints = 100f;
    private float _currentHitPoints;
    public PlayerShooter shooter;
    [SerializeField] private int addCoin=100;

    private void Start()
    {
        _currentHitPoints = hitPoints;
        control=GetComponent<ZombiControl>();
    }

    public void Damage(float damage)
    {
        _currentHitPoints -= damage;
        if (_currentHitPoints <= 0f)
        {
            Debug.LogError("Dead "+ gameObject.name);
            MenegerCoins.S.AddCoins(addCoin);
            if (shooter)
            {
                //Debug.LogError("zombNul");
                shooter.GetComponent<PlayerShooter>().TargetNuul();
                shooter = null;
            }
            control.destroyEnemy();
            GetComponent<Collider>().enabled = false;
            GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.gray);
        }
    }
}