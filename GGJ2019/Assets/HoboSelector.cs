using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoboSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public static int playerNum;

    public void SelectCharacter(int sellectedNum)
    {
        playerNum = sellectedNum;
        SceneManager.LoadScene(1);
    }

}