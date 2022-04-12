using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetsOrigin;
    public Transform[] spawnPoints;
    public bool waveRunning = false;
    public int targetsPerWave = 1;
    public List<GameObject> wave;

    private void Start()
    {
        wave.Clear();
    }

    void Update()
    {
        if(wave.Count == 0 && waveRunning == false)
        {
            CreateWave();
        }
        else if (wave.Count != 0 && waveRunning == false)
        {
            SpawnWave();
        }
    }

    public void RemoveMe(GameObject toRemove)
    {
        wave.Remove(toRemove);
    }

    private void CreateWave()
    {
        Debug.Log("creating wave");
        List<GameObject> spawnList = targetsOrigin;

        for (int i = 1; i <= targetsPerWave; i++)
        {
            int toAdd = Random.Range(0, spawnList.Count);
            Debug.Log(spawnList[toAdd]);
            wave.Add(spawnList[toAdd]);
            spawnList.RemoveAt(toAdd);
        }
    }

    private void SpawnWave()
    {
        Debug.Log("spawning wave");
        foreach(GameObject target in wave)
        {
            Instantiate(target);
        }
        waveRunning = true;
    }
}
