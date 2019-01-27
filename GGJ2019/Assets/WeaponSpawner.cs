using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSpawner : MonoBehaviour
{
    private static int CharacterNum;
    private bool CanSpawnBottle;
    public GameObject spawnPoint;
    public GameObject beers;

    List<GameObject> beerBottles;
    int maxBeerBottles;
    // Start is called before the first frame update
    void Start()
    {
        CanSpawnBottle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "City Scene")
        {
            switch (CharacterNum)
            {
                case 0:
                    if (CanSpawnBottle)
                    {
                        CanSpawnBottle = false;
                        Instantiate(beers, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    }
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
