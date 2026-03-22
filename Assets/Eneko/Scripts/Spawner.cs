using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject projectil;
    public List<GameObject> pool = new List<GameObject>();
    public float spawnDistance = 50;
    public float destinationOffsetRange = 2;

    private int poolSize = 5;
    private float cooldown = 0;
    private float nextSpawnTime;

    void Start()
    {
        AddProyectil(poolSize);
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

    void AddProyectil(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject p = Instantiate(projectil);
            p.SetActive(false);
            pool.Add(p);
        }
    }

    void ShootProyectil(Vector3 origin)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeSelf)
            {
                pool[i].transform.position = origin;
                pool[i].SetActive(true);
                pool[i].GetComponent<Proyectil>().Launch(destinationOffsetRange);
                return;
            }
        }
        AddProyectil(1);
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