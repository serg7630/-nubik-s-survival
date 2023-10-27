using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierLog : ModifierBase
{
    public override void Modify(PlayerController playerController, int index)
    {
        Debug.LogError("Modifier Player");

    }
}
