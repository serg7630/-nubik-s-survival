using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private HealtBarEnemy healtBarEnemy;
    [SerializeField] private bool healtBar;
    [SerializeField] ZombiControl control;
    [SerializeField] private float hitPoints = 100f;
    private float _currentHitPoints;
    public PlayerShooter shooter;
    [SerializeField] private int addCoin=100;
    private bool _dead = false;

    private void Start()
    {
        _currentHitPoints = hitPoints;
        control=GetComponent<ZombiControl>();
        if (healtBar)
        {
            healtBarEnemy = GetComponent<HealtBarEnemy>();
            healtBarEnemy.MaxHealth = hitPoints;
        }

    }

    public void Damage(float damage)
    {
        _currentHitPoints -= damage;
        if(healtBar) healtBarEnemy.SetValue(_currentHitPoints);
        if (_currentHitPoints <= 0f)
        {   if (_dead) return;
            //Debug.LogError("Dead "+ gameObject.name);
            MenegerCoins.S.AddCoins(addCoin);
            _dead = true;
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