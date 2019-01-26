using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public static int playerNum;

    public void SelectCharacter(int sellectedNum)
    {
        playerNum = sellectedNum;
    }

}