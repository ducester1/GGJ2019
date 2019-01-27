using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoboSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public int characterNum;
    public GameObject player;

    public void SelectCharacter(int sellectedNum)
    {
        characterNum = sellectedNum;
        player.transform.position = new Vector3(0, 0, 0);

        SceneManager.LoadScene(1);
        GetComponent<WeaponSpawner>().UpdateCharacterChoice(characterNum);
    }

}