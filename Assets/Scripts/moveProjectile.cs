using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveProjectile : MonoBehaviour
{
    [SerializeField] float speed=30f;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
