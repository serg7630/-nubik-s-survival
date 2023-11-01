using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiBossAtack : ZombiControl
{
    //[SerializeField] Animator _animator;
    [SerializeField] private bool _finalAttack;
    
    void Start()
    {
        
    }

    public override void SetIdle()
    {
        base.SetIdle();
        return;
        
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
            float distance = Vector3.Distance(transform.position, _transformTarget.position);
            //print(distance);
            if (distance <= 5.5f)
            {
                _animator.SetBool("NearAttack", true);
                GetComponent<Enemy>().ItSLate = true;
                this.enabled = false;
            }



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

    public override void DestroyThis()
    {
        base.DestroyThis();
        //_animator.SetTrigger("Dead");
        Destroy(this.gameObject, 6.5f);
        Invoke("ColisionTriger", 1.7f);
    }
    public override void destroyEnemy()
    {
        ControlAgressEnemy.S.RemoveEnemyFromList(this.transform);
        _animator.SetTrigger("Dead");
        Destroy(this.gameObject, 6.5f);
        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;
        Dead = true;

    }
}
