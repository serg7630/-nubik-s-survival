
using System.Collections.Generic;

using UnityEngine;

public class VisualControl : MonoBehaviour
{
    public static VisualControl S;
    public Animator animator;
    public List<Animator> AnimatorPlauers = new List<Animator>();
    public List<GameObject> Players;
    void Start()
    {
        if (S == null) S = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAniRun(bool TrueOrFalse)
    {
        //animator.SetBool("Run", TrueOrFalse);
        
    }
   
}
