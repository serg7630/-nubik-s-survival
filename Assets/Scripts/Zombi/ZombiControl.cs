using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiControl : MonoBehaviour
{
    [Header("Анимация")]
    [SerializeField]protected Animator _animator;
    public bool Staeps;
    public bool Dead=false;
    public bool Down=false;


    [Header("Управление ")]
    [SerializeField] protected Transform _transformTarget;
    public float speedSteps ;
    
    public bool Target;
    void Start()
    {
        
    }

   
    void Update()
    {
        move();
    }

    public virtual void move()
    {
        if (Target)
        {
            _animator.SetBool("Steps", true);
            transform.LookAt(_transformTarget.position);
            transform.position = Vector3.Lerp(transform.position, _transformTarget.position, speedSteps * Time.deltaTime);

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

    public void SetTarget(Transform target)
    {
        Target = true;
        _transformTarget = target;
    }
    public void invokeSetIdle()
    {
        Invoke("SetIdle", 1f);
    }
    public virtual void SetIdle()
    {
        if (!_transformTarget) return;
        if (transform.position.z < _transformTarget.position.z)
        {
          
            Destroy(this.gameObject, 3f);
        }
    }
    public virtual void destroyEnemy()
    {
        ControlAgressEnemy.S.RemoveEnemyFromList(this.transform);
        _animator.SetTrigger("Dead");
        Destroy(this.gameObject, 2.5f);
        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;
        Dead = true;

    }
    public virtual void DestroyThis()
    {
        //_animator.SetTrigger("Dead");
        Destroy(this.gameObject, 6.5f);
        Invoke("ColisionTriger", 1.7f);
    }
    void ColisionTriger()
    {
        Down = true;
        GetComponent<CapsuleCollider>().isTrigger=true;
    }
}
