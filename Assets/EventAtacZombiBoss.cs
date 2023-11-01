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
        if (collision.transform.CompareTag("MainPlayer"))
        {
            Debug.LogError("PlayerDead");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("MainPlayer"))
        {
            //Debug.LogError("PlayerDead");
            //if (GetComponent<ZombiBossAtack>().Dead)
            //{
            //    return;
            //}

            other.GetComponent<PlayerCrowd>().DeadPlayers();
        }
    }
    void Update()
    {
        
    }
}
