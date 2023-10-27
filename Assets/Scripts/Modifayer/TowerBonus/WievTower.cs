using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WievTower : MonoBehaviour
{
    public TextMeshProUGUI Count;
    [SerializeField] GameObject Particle;
    [SerializeField] Transform _transformPers;
    [SerializeField] 
    void Start()
    {
        
    }

    public void WievCountOnTower( float ValueCount)
    {
        Count.text = ValueCount.ToString();
    }
    public void destroyTower()
    {
       GameObject ParticleObj= Instantiate(Particle,transform.position,transform.rotation);
        Destroy(this.gameObject);
        Destroy(ParticleObj, .5f);
    }
    void Update()
    {
        
    }
}
