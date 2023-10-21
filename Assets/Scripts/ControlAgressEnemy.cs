using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAgressEnemy : MonoBehaviour
{

     public  List<Transform> targetsEnemy = new List<Transform>();
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject go=other.gameObject;
        if (go.CompareTag("enemyZomb"))
        {
            go.GetComponent<ZombiControl>().SetTarget(this.transform);
            if (targetsEnemy.Count == 0)
            {
                targetsEnemy.Add(go.transform);
            }
            if (targetsEnemy.Count == 1)
            {
                if (go.transform != targetsEnemy[0]) targetsEnemy.Add(go.transform);
                else { return; }
            }
            else
            {
                //Debug.LogError(targetsEnemy.Count);
                foreach (Transform t in targetsEnemy)
                {
                    //print(t);
                    if (t == go.transform) return;
                    
                }
                targetsEnemy.Add(go.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject go = other.gameObject;


        if (go.CompareTag("enemyZomb")) RemoveEnemyFromList(go.transform);
        
    }
    public void RemoveEnemyFromList(Transform RearEnemy)
    {
        targetsEnemy.Remove(RearEnemy);
        if (RearEnemy.CompareTag("enemyZomb"))
        {
            RearEnemy.GetComponent<ZombiControl>().SetIdle();
        }
        //Debug.LogError("ermove");
    }
    public Transform FindNearEnemy(Transform target)
    {
        Transform trans = null;
        float min = float.PositiveInfinity;
        for (int i = 0; i < targetsEnemy.Count; i++)
        {
            float sqr = (target.position - targetsEnemy[i].position).magnitude;
            if (sqr < min)
            {
                min = sqr;
                trans = targetsEnemy[i];
                //Debug.LogError(" object " + targetsEnemy[i].name +" distance "+min );
            }

        }
        return trans;
    }

    }
