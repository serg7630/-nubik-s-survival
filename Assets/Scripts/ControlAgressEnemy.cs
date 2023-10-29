using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAgressEnemy : MonoBehaviour
{
    public static ControlAgressEnemy S;
     public  List<Transform> targetsEnemy = new List<Transform>();
    [SerializeField] Transform _playerCrouwd;
    
    void Start()
    {
        if (S == null) S = this;
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject go=other.gameObject;
        //Debug.LogError(go.name);
        if (go.CompareTag("enemyZomb"))
        {
            
            ZombiControl ZC = go.GetComponent<ZombiControl>();
            //print(ZC);
            if (ZC)go.GetComponent<ZombiControl>().SetTarget(_playerCrouwd);
            //Debug.LogError(go.name);
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
        if (RearEnemy.CompareTag("enemyZomb") )
        {
            ZombiControl ZC=RearEnemy.GetComponent<ZombiControl>();
            if (ZC)
            {
                ZC.SetIdle();
                ZC.Dead = true;
                ZC.DestroyThis();
            }
        }
        //Debug.LogError("ermove");
    }
    public Transform FindNearEnemy(Transform target)
    {
        if (targetsEnemy.Count == 1)return targetsEnemy[0];
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
        //if (trans.GetComponent<ZombiControl>())
        //{
        //    if (trans.GetComponent<ZombiControl>().Dead) return null;
        //}

        return trans;
    }

    

    }
