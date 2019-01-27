using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSpawner : MonoBehaviour
{
    private static int CharacterNum;
    private bool CanSpawn;
    public GameObject spawnPoint;
    public GameObject beers;
    public GameObject guitar;

    List<GameObject> beerBottles;
    int maxBeerBottles;
    // Start is called before the first frame update
    void Start()
    {
        CanSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "City Scene" && CanSpawn)
        {
            CanSpawn = false;
            switch (CharacterNum)
            {
                case 0:
                    Instantiate(beers, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    break;
                case 1:
                    Instantiate(guitar, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    break;
                default: break;
            }
        }
    }

    public void UpdateCharacterChoice(int charNum)
    {
        CharacterNum = charNum;
    }
}
