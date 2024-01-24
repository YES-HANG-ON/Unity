using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DessertSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] desserts;

    [SerializeField]
    private GameObject boss;

    [SerializeField]
    private float spawnInterval = 2.0f;

    private float[] arrPosX = { -2.1f, -0.7f, 0.7f, 2.1f };

    void SpawnDessert(float posX, int index)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        int dessertW = Random.Range(0, 7);
        if (dessertW == 0)
        {
            index += 2;
        }
        else if (dessertW < 3)
        {
            index += 1;
        }
        if (index >= desserts.Length)
        {
            index = desserts.Length - 1;
        }
        Instantiate(desserts[index], spawnPos, Quaternion.identity);
    }

    void spawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }

    IEnumerator DessertRoutine()
    {
        yield return new WaitForSeconds(spawnInterval);

        int dessertIndex = 0;
        int spawnCount = 0;
        while (true)
        {
            int noSpawn = Random.Range(0, 6);
            for (int i = 0; i < 4; i++)
            {
                if (i != noSpawn)
                SpawnDessert(arrPosX[i], dessertIndex);
            }

            spawnCount++;
            if (spawnCount % 5 == 0)
            {
                dessertIndex++;
            }
            if (spawnCount % 15 == 0)
            {
                spawnBoss();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void StartDessertRoutine()
    {
        StartCoroutine("DessertRoutine");
    }

    public void StopDessertRoutine()
    {
        StopCoroutine("DessertRoutine");
    }

    void Start()
    {
        StartDessertRoutine();
    }

}
