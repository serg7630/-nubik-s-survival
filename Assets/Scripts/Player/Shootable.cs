using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public PlayerController controller;
    [SerializeField] private float shootableSurviveTime = 3f;       //����� ����� �������
    private float _damagePerHit = 10;       //���� �������

    public void Init(float damagePerHit)        //������������� ���� � �����
    {
        _damagePerHit = damagePerHit;
        Invoke(nameof(DestroyShootable), shootableSurviveTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ////Debug.LogError(collision.transform.name);
        //if (collision.transform.CompareTag("enemyZomb"))
        //{
            
        //    IDamageable damageable = collision.transform.GetComponentInChildren<IDamageable>();
        //    damageable.Damage(_damagePerHit);
            
        //    DestroyShootable();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("enemyZomb"))
        {

            IDamageable damageable = other.transform.GetComponentInChildren<IDamageable>();
            damageable.Damage(_damagePerHit);

            DestroyShootable();
        }
    }
    private void DestroyShootable()
    {
        Destroy(gameObject);
    }
}
