using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject projectil;
    public GameObject bombProjectil; 
    public float bombProbability = 0.3f;
    public List<GameObject> pool = new List<GameObject>();
    public List<GameObject> bombPool = new List<GameObject>();

    public float spawnDistance = 50;
    public float destinationOffsetRange = 2;

    private int poolSize = 5;
    private float cooldown = 0;
    private float nextSpawnTime;

    void Start()
    {
        AddProyectil(poolSize, projectil, pool);
        AddProyectil(poolSize, bombProjectil, bombPool);
        nextSpawnTime = Random.Range(2f, 3f);
    }

    void Update()
    {
        cooldown += Time.deltaTime;

        if (cooldown >= nextSpawnTime)
        {
            ShootProyectil(OriginPoint());
            cooldown = 0f;
            nextSpawnTime = Random.Range(2f, 3f);
        }
    }

    void AddProyectil(int amount, GameObject prefab, List<GameObject> targetPool)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject p = Instantiate(prefab);
            p.SetActive(false);
            targetPool.Add(p);
        }
    }

    void ShootProyectil(Vector3 origin)
    {
        bool isBomb = Random.value < bombProbability;
        List<GameObject> targetPool = isBomb ? bombPool : pool;
        GameObject prefabToUse = isBomb ? bombProjectil : projectil;

        for (int i = 0; i < targetPool.Count; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].transform.position = origin;
                targetPool[i].SetActive(true);
                targetPool[i].GetComponent<Proyectil>().Launch(destinationOffsetRange);
                return;
            }
        }

        AddProyectil(1, prefabToUse, targetPool);
        ShootProyectil(origin);
    }

    Vector3 OriginPoint()
    {
        Transform cam = Camera.main.transform;
        Vector3 spawnPos = cam.position + cam.forward * spawnDistance;
        spawnPos.y = 1.5f;
        return spawnPos;
    }
}