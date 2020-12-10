using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Collectable
{
    public override void Collect(CharacterControl player)
    {
        if (CharacterStats.health >= CharacterStats.maxHealth)
        {
            CharacterStats.health = CharacterStats.maxHealth;
        }
        else
        {
            CharacterStats.health++;
        }
    }
}
