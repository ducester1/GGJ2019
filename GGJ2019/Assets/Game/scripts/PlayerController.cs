using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if(PlayerController.Instance)
        {
            Debug.LogError("Multiple players in the scene");
        }
        PlayerController.Instance = this;
    }
}
