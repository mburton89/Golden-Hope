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

    public Text healthText;
    public Text armorText;
    public Text moneyText;

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
        ChangeText();
    }

    public void ChangeText()
    {
        Debug.Log("Changing Text");
        healthText.text = health.ToString();
        armorText.text = armor.ToString();
        moneyText.text = money.ToString();
    }
}
