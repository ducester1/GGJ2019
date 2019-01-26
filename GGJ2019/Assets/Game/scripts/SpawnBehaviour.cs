using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    private void OnDestroy()
    {
        SpawnSystem.aliveEnemies.Remove(this.gameObject);
    }
}