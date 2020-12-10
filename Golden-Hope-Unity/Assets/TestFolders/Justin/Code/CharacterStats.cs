using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public CharacterStats Instance;
    public static int money = 0;
    public static int maxHealth = 5;
    public static int health = 4;
    public static int maxArmor = 5;
    public static int armor = 0;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
