using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiControl : MonoBehaviour
{
    [Header("Анимация")]
    [SerializeField] Animator _animator;
    public bool Staeps;


    [Header("Управление ")]
    [SerializeField] Transform _transformTarget;
    public float speedSteps = 1;
    
    public bool Target;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Target)
        {
            _animator.SetBool("Steps", true);
            transform.LookAt(_transformTarget.position);
            transform.position=Vector3.Lerp(transform.position, _transformTarget.position, speedSteps*Time.deltaTime);
        }
        else
        {
            _animator.SetBool("Steps", false);
        }
    }
    public void SetTarget(Transform target)
    {
        Target = true;
        _transformTarget = target;
    }
    public void invokeSetIdle()
    {
        Invoke("SetIdle", 1f);
    }
    public void SetIdle()
    {
        Target = false;
        //_transformTarget = null;
        if (transform.position.z < _transformTarget.position.z)
        {
            _animator.SetTrigger("Dead");
            Destroy(this.gameObject, 3f);
        }
    }
}
