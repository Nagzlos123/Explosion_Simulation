using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsSpawer : MonoBehaviour
{
    [SerializeField] private GameObject[] bombSpawnerPoints = null;
    [SerializeField] private GameObject bomb;
    public int numberOfBombs;
    private int randomitem;
    private float bombSpawnerPointLength;
    public float minRange = -10000f;
    public float maxRange = 10000f;
    public void SpawnBomb()
    {

        for (int i = 0; i < numberOfBombs; i++)
        {
            randomitem = Random.Range(0, bombSpawnerPoints.Length);
            
            
           

            Vector3 randomSpawnPosition = new Vector3( Random.Range(minRange, maxRange), 15, Random.Range(minRange, maxRange));

            //GameObject itemClone = Instantiate(bomb, randomSpawnPosition, Quaternion.identity);
            GameObject itemClone = Instantiate(bomb, bombSpawnerPoints[randomitem].transform.position, Quaternion.identity);
        }

    }


}
