using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActivation : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    private Collider2D CheckEnemies;

    public void Awake()
    {
        
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemies.Add(collision.gameObject);
        }
          
    }





}
