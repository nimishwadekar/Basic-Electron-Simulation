using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronForce : MonoBehaviour
{
    public float initialX, finalX;
    public float time;

    [HideInInspector]
    public float currentTime;
    private Vector3 initialPos, finalPos;

    private void Start()
    {
        currentTime = 0;
        initialPos = transform.position;
        finalPos = initialPos;
        finalPos.x += 20;
    }

    private void Update()
    {
        if(currentTime == 0)
        {
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        while(currentTime < time)
        {
            transform.position = Vector3.Lerp(initialPos, finalPos, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }
        currentTime = 0;
        transform.position = initialPos;
    }
}
