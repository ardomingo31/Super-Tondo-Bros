using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject[] locations;

    void Start()
    {
        foreach (GameObject location in locations)
        {
            GameObject enemy = Instantiate(EnemyPrefab);
            enemy.transform.SetParent(location.transform, false);
        }
    }


}
