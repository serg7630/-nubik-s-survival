using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiBossAtack : ZombiControl
{
    //[SerializeField] Animator _animator;
    void Start()
    {
        
    }
    public override void move()
    {
        base.move();

        
        if (Target)
        {
            _animator.SetBool("Steps", true);
            transform.LookAt(_transformTarget.position);
            //transform.position = Vector3.Lerp(transform.position, _transformTarget.position, speedSteps * Time.deltaTime);
            //Debug.LogError("Steps");
           

        }
        else
        {
            _animator.SetBool("Steps", false);
        }
        Vector3 newRotation = transform.rotation.eulerAngles;
        newRotation.x = 0;
        transform.rotation = Quaternion.Euler(newRotation);
        if (!Down) transform.position = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);
    }

    void Update()
    {
        move();
    }
    
}
