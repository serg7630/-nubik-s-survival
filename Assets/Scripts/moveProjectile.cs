using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveProjectile : MonoBehaviour
{
    [SerializeField] float speed=30f;
    void Start()
    {
        Vector3 rotate = transform.eulerAngles;
        rotate.x = 90;
        transform.rotation = Quaternion.Euler(rotate);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        
    }
}
