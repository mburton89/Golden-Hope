using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Combat : MonoBehaviour
{
    //Instantiate Variables
    public int Max_Health;
    public int Current_Health;
    public int Dark_Essence;
    public int Max_Armor;
    public int Current_Armor;
    


    //Instantiate UI Elements
    public Canvas Combat_UI;
    public Toggle Armor_1;
    public Toggle Armor_2;
    public Toggle Armor_3;
    public Slider HP_Bar;
    public TMP_Text DarkEssence;


    // Start is called before the first frame update
    public void Start()
    {
        Max_Health = 15;
        Current_Health = Max_Health;
        Max_Armor = 3;
        Current_Armor = Max_Armor;

        HP_Bar.maxValue = Max_Health;
        HP_Bar.value = Current_Health;

        Armor_1.isOn = true;
        Armor_2.isOn = true;
        Armor_3.isOn = true;

        Dark_Essence = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateArmor();
        DarkEssence.text = Dark_Essence.ToString();
    }

    public void UpdateHealth()
    {
        if(Current_Health != HP_Bar.value)
        {
            HP_Bar.value = Current_Health;
        }

        else if(Current_Health == 0)
        {
            //Death UI
        }
    }

    public void UpdateArmor()
    {
        if(Current_Armor < Max_Armor)
        {
            if(Current_Armor == 2)
            {
                Armor_1.isOn = true;
                Armor_2.isOn = true;
                Armor_3.isOn = false;
            }

            else if(Current_Armor == 1)
            {
                Armor_1.isOn = true;
                Armor_2.isOn = false;
                Armor_3.isOn = false;
            }

            else if (Current_Armor == 0)
            {
                Armor_1.isOn = false;
                Armor_2.isOn = false;
                Armor_3.isOn = false;
            }
        }
        else if(Current_Armor == Max_Armor)
        {
            Armor_1.isOn = true;
            Armor_2.isOn = true;
            Armor_3.isOn = true;
        }
    }
}
