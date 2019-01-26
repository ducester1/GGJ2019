using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] spawnPoints;

    [SerializeField] private AnimationCurve maxEnemyCurve;
    [SerializeField] private AnimationCurve spawnIdleCurve;

    public bool isActive = true;

    float gameActiveTime = 0.0f;

    public static SpawnSystem Instance
    {
        get; private set;
    }

    public static List<GameObject> aliveEnemies = new List<GameObject>();

    private void Awake()
    {
        if(SpawnSystem.Instance == null)
        {
            SpawnSystem.Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.isActive = true;
        StartCoroutine(this.onSpawn());
    }

    private void Update()
    {
        this.gameActiveTime += Time.deltaTime;
    }

    IEnumerator onSpawn()
    {
        for(;;)
        {
            if (this.isActive)
            {
                if (aliveEnemies.Count < this.getMaxEnemies())
                {
                    this.Spawn(
                        this.GetRandomFromArray(enemyPrefabs),
                        this.GetRandomFromArray(spawnPoints));
                }
            }

            yield return new WaitForSeconds(this.getIdleTime());
        }
    }

    void Spawn(GameObject prefab, GameObject spawnPoint)
    {
        Debug.Log("SPAWNING");
        Vector3 p = spawnPoint.transform.position;
        p.y = 0;
        GameObject e = Instantiate<GameObject>(prefab, p, prefab.transform.rotation);
        aliveEnemies.Add(e);
    }

    GameObject GetRandomFromArray(GameObject[] arr)
    {
        return arr[Random.Range(0, arr.Length)];
    }

    float getMaxEnemies()
    {
        // Update this with a GameController variable!
        // Configured from 0 - 30
        return this.maxEnemyCurve.Evaluate(this.gameActiveTime);
    }

    float getIdleTime()
    {
        // Update this with a GameController variable!
        return 4.0f * this.spawnIdleCurve.Evaluate(this.gameActiveTime);
    }

}
