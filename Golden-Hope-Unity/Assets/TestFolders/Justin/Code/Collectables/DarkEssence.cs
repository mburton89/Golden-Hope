﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEssence : Collectable
{
    public override void Collect()
    {
        CharacterStats.money++;
    }
}
