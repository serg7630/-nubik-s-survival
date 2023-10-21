using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("(other.CompareTag(\"Modifier\")");
        if (other.CompareTag("Modifier"))
        {
            
            
            ModifierCrowd modifierCrowd=other.GetComponent<ModifierCrowd>();
            if (modifierCrowd)
            {
                modifierCrowd.Modify(this);
            }
        }
    }
}