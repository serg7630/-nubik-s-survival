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
            
            ModifierBase modifier = other.GetComponent<ModifierBase>();
            if (modifier)
            {
                modifier.Modify(this);
            }
        }
    }
}