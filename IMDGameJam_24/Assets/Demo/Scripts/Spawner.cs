using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;

    public void SpawnPrefab( )
    {
        Instantiate(Prefab, transform.position, transform.rotation);
    }
}
