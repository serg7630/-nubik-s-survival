using _Project.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    [SerializeField] private float shootableSurviveTime = 3f;       //время жизни снаряда
    private float _damagePerHit = 10;       //уроп снаярда

    public void Init(float damagePerHit)        //устанавливает врем я жизни
    {
        _damagePerHit = damagePerHit;
        Invoke(nameof(DestroyShootable), shootableSurviveTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.CompareTag("Damageable"))
        //{
        //    IDamageable damageable = collision.transform.GetComponentInChildren<IDamageable>();
        //    damageable.Damage(_damagePerHit);
        //    DestroyShootable();
        //}
    }

    private void DestroyShootable()
    {
        Destroy(gameObject);
    }
}
