using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoboSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public static int playerNum;
    public GameObject player;

    public void SelectCharacter(int sellectedNum)
    {
        Debug.Log("Clicked");
        playerNum = sellectedNum;
        player.transform.position = new Vector3(0, 0, 0);

        SceneManager.LoadScene(1);
    }

}