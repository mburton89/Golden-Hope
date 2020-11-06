using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : Collectable
{
    public override void Collect()
    {
        if (CharacterStats.armor >= CharacterStats.maxArmor)
        {
            CharacterStats.armor = CharacterStats.maxArmor;
        }
        else
        {
            CharacterStats.armor++;
        }
    }
}
