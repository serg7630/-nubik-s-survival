using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private MovingPlayer movingPlayer;
    [SerializeField]private PlayerCrowd _playerCrowd;

    private void Start()
    {
        _playerCrowd=GetComponent<PlayerCrowd>();
    }
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
        else if (other.CompareTag("StopPlayer"))
        {
            Debug.LogError("stop");
            transform.root.GetComponent<PlayerMoving>().enabled = false;
            movingPlayer.enabled = false;
            _playerCrowd.AnimateIdle();
            _playerCrowd.FinishDirect();
        }

    }
}