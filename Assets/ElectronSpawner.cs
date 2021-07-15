using System;
using System.Collections.Generic;
using UnityEngine;

public class ElectronSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject electron;

    public float spawnTimeInterval;
    private float currentTime;
    public int count;
    public float waitTime;
    private Vector3 spawnLocation;

    private void Start()
    {
        spawnLocation = transform.position;
    }

    private void Update()
    {
        if (count <= 0) return;
        if(waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            return;
        }

        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            Instantiate(electron, spawnLocation, Quaternion.identity);
            count--;
            currentTime = spawnTimeInterval;
        }
    }
}
