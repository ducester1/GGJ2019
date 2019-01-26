using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] characters;
    public Transform playerSpawnPoint;
    void Start()
    {
        Instantiate(characters[HoboSelector.playerNum], playerSpawnPoint);
        
    }

    // Update is called once per frame
  
}
