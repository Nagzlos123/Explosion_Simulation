using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] itemsToSpread;
    
    public float itemXSpread;
    public float itemYSpread;
    public float itemZSpread;
    public int numberOfItems = 20;
    
    private int randomitem;
    

    private void Start()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            SpawnItems();
        }
    }



        void SpawnItems()
    {
        randomitem = Random.Range(0, itemsToSpread.Length);
        Vector3 randomPozition = new Vector3(Gaussian(0,1) + Random.Range(- itemXSpread, itemXSpread),
             Random.Range(- itemYSpread, itemYSpread), Gaussian(0, 1) + Random.Range(- itemZSpread, itemZSpread)) + transform.position;
        GameObject itemClone = Instantiate(itemsToSpread[randomitem], randomPozition, Quaternion.identity);
        itemClone.transform.parent = this.transform;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public static float Gaussian(float minValue = 0.0f, float maxValue = 1.0f)
    {
        float u, v, S;

        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);


        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);


        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }
}
