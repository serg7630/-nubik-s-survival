using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] private PlayerCrowd playerCrowd;
    void Start()
    {
        
    }

    
    void Update()
    {

         
            transform.position += Vector3.forward * speed * Time.deltaTime;
           

        
        
        
        
    }
   
}
