using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAtacZombiBoss : MonoBehaviour
{
    [SerializeField] private float damage=100f;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.CompareTag("enemyZomb"))
        //{
        //    Enemy enemy = collision.transform.GetComponent<Enemy>();
        //    enemy.Damage(damage);
        //}
    }
    void Update()
    {
        
    }
}
