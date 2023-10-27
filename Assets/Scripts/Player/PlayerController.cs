using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Modifier"))
        {

            print(other.gameObject.name);
            ModifierShootableYear modifierCrowd =other.GetComponent<ModifierShootableYear>();
            if (modifierCrowd)
            {
                modifierCrowd.Modify(this, modifierCrowd.indexModify);
            }
        }
    }
}