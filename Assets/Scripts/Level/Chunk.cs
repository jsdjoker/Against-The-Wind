using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fenceprefarb;
    [SerializeField] GameObject appleprefarb;
    [SerializeField] GameObject Coinprefarb;
    [SerializeField] float coinSeperationLength = 2f;
    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };
    List<int> availableLines = new List<int> { 0, 1, 2 };

    LevelGenerator levelGenerator;
    ScoreManager scoreManager;

    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float CoinSpawnChance = .5f;

    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoin();
    }

    public void Init(LevelGenerator levelGenerator, ScoreManager scoreManager)
    {
        this.levelGenerator = levelGenerator;
        this.scoreManager = scoreManager;
    }

    void SpawnFences()
    {
       
        int fencestoSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencestoSpawn; i++)
        {
            if (availableLines.Count <= 0) break;
            int selectedLane = SelectLine();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fenceprefarb, spawnPosition, Quaternion.identity, this.transform);
        }


    }

    int SelectLine()
    {
        int randomLaneIndex = Random.Range(0, availableLines.Count);
        int selectedLane = availableLines[randomLaneIndex];
        availableLines.RemoveAt(randomLaneIndex);
        return selectedLane;
    }

    void SpawnApple()
    {
        if (Random.value > appleSpawnChance || availableLines.Count <= 0) return;

  
        int selectedLane = SelectLine();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Apple newApple = Instantiate(appleprefarb, spawnPosition, Quaternion.identity, this.transform).GetComponent<Apple>();
        newApple.Init(levelGenerator);
    }

    void SpawnCoin()
    {
        if (Random.value > CoinSpawnChance || availableLines.Count <= 0) return;

        int maxCoinstospawn = 6;
        int coinstospawn = Random.Range(1, maxCoinstospawn);

        float topofchunkzpos = transform.position.z + (coinSeperationLength * 2f);


        int selectedLane = SelectLine();

        for (int i = 0; i < coinstospawn; i++)
        {
            float spawnpositionZ = topofchunkzpos - (i * coinSeperationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Coin newCoin = Instantiate(Coinprefarb, spawnPosition, Quaternion.identity, this.transform).GetComponent<Coin>();
            newCoin.Init(scoreManager);
        }


    }
}
