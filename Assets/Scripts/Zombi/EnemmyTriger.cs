using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemmyTriger : MonoBehaviour
{
   
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShooter playerShooter=other.GetComponent<PlayerShooter>();
            PlayerCrowd playerCrowd = playerShooter.GetComponent<PlayerShooter>().PCrowd;
            playerCrowd.RemoveThisShooter(playerShooter);
            GetComponent<Enemy>().Damage(1000);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
