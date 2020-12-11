using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorManager : MonoBehaviour
{
    public static FloorManager Instance;
    public static List<string> floors = new List<string>();

    public static int currentFloor;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        currentFloor = 0;

        floors.Add("JustinTestScene 3");
        floors.Add("NewFloor");
    }

    public static void NextFloor()
    {
        //currentFloor++;
        SceneManager.LoadScene(floors[currentFloor]);
        
    }

}
