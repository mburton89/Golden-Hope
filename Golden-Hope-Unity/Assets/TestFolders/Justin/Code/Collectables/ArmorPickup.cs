using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : Collectable
{
    public override void Collect(CharacterControl player)
    {
        if (player.armor >= player.maxArmor)
        {
            CharacterStats.armor = player.maxArmor;
        }
        else
        {
            CharacterStats.armor++;
        }
    }
}
