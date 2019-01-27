using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] spawnPoints;
    ///[SerializeField] private AnimationCurve maxEnemyCurve;
    ///[SerializeField] private AnimationCurve spawnIdleCurve;

    [SerializeField] private TextMesh spawnText;

    public bool isActive = true;
    float gameActiveTime = 0.0f;

    float waveInitTime = 4.0f;
    float waveFinishTime = 4.6f;

    string[] waveInitText = { "Round1\nMonday", "Round2\nTuesday", "Round3\nWednesday", "Round4\nThursday", "Round5\nFriday" };
    string[] waveFinishText = { "Round1\nCompleted", "Round2\nCompleted", "Round3\nCompleted", "Round4\nCompleted", "Round5\nCompleted" };

    int[] maxEnemyOnScreen = { 4, 8, 12, 24, 36 };
    int[] spawnIdleTime = { 8, 6, 4, 2, 2 };

    int currentWave = 0;
    int nSpawnedEnemiesWave = 0;
    int lastSpawnPoint = 0;

    // types from left to right
    int[] enemyWave1 = { 1, 1, 1, 1 }; // round 1
    int[] enemyWave2 = { 3, 3, 2, 2 }; // round 2
    int[] enemyWave3 = { 4, 4, 4, 4 }; // round 3
    int[] enemyWave4 = { 8, 8, 8, 8 }; // round 4
    int[] enemyWave5 = { 12, 12, 12, 12 }; // round 5

    public static SpawnSystem Instance { get; private set; }
    public static List<GameObject> aliveEnemies = new List<GameObject>();

    void Start()
    {
        if (SpawnSystem.Instance == null) SpawnSystem.Instance = this;
        StartCoroutine(this.DoWave());
    }

    IEnumerator DoWave()
    {
        for (;;)
        {
            //int[] waveEnemies = this.GetEnemyWave(this.currentWave);
            //int waveTotalEnemies = this.GetWaveSize(waveEnemies);
            int[] waveEnemies = this.GetShuffleSpawnList(this.GetEnemyWave(this.currentWave));
            int waveTotalEnemies = waveEnemies.Length;

            // Do init wave
            this.spawnText.text = this.waveInitText[this.currentWave];
            this.spawnText.gameObject.SetActive(true);
            yield return new WaitForSeconds(this.waveInitTime);
            this.spawnText.gameObject.SetActive(false);

            // Do main wave
            while (this.nSpawnedEnemiesWave < waveTotalEnemies)
            {
                if(SpawnSystem.aliveEnemies.Count < this.maxEnemyOnScreen[this.currentWave])
                {
                    int spawnNumber = 0;
                    do
                    {
                        spawnNumber = Random.Range(0, spawnPoints.Length);
                    } while (this.lastSpawnPoint == spawnNumber);

                    this.Spawn(this.enemyPrefabs[waveEnemies[this.nSpawnedEnemiesWave++]], spawnPoints[spawnNumber]);

                    //this.Spawn(
                    //    this.GetRandomFromArray(enemyPrefabs),
                    //    this.GetRandomFromArray(spawnPoints));
                }
                yield return new WaitForSeconds(this.spawnIdleTime[this.currentWave]);
            }

            while(SpawnSystem.aliveEnemies.Count > 1)
            {
                yield return new WaitForSeconds(1.0f);
            }

            // Do finish wave
            this.spawnText.text = this.waveFinishText[this.currentWave];
            this.spawnText.gameObject.SetActive(true);
            yield return new WaitForSeconds(this.waveFinishTime);
            this.spawnText.gameObject.SetActive(false);

            this.nSpawnedEnemiesWave = 0;
            this.currentWave++;

            if (this.currentWave > 5) break;
        }
    }

    private void Update()
    {
        this.gameActiveTime += Time.deltaTime;
    }

    void Spawn(GameObject prefab, GameObject spawnPoint)
    {
        //Debug.Log("SPAWNING");
        Vector3 p = spawnPoint.transform.position;
        p.y = 0;
        GameObject e = Instantiate<GameObject>(prefab, p, prefab.transform.rotation);
        aliveEnemies.Add(e);
    }

    GameObject GetRandomFromArray(GameObject[] arr)
    {
        return arr[Random.Range(0, arr.Length)];
    }

    int[] GetEnemyWave(int wave)
    {
        switch (wave)
        {
            case 0: return this.enemyWave1;
            case 1: return this.enemyWave2;
            case 2: return this.enemyWave3;
            case 3: return this.enemyWave4;
            case 4: return this.enemyWave5;
        }
        return this.enemyWave1;
    }

    int GetWaveSize(int[] wave)
    {
        int total = 0;
        for (int i = 0; i < wave.Length; i++)
        {
            total += wave[i];
        }
        return total;
    }

    int[] GetShuffleSpawnList(int[] amounts)
    {
        List<int> l = new List<int>();

        for(int i = 0; i < amounts.Length; i++)
            for (int j = 0; j < amounts[i]; j++)
                l.Add(i);

        List<int> rl = new List<int>();

        int randomIndex = 0;
        while (l.Count > 0)
        {
            randomIndex = Random.Range(0, l.Count); // Choose a random object in the list
            rl.Add(l[randomIndex]); // add it to the new, random list
            l.RemoveAt(randomIndex); // remove to avoid duplicates
        }

        return rl.ToArray(); //return the new random list
    }

}
