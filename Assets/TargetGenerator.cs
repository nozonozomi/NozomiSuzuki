using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetGenerator : MonoBehaviour
{
    private float positionX;
    private float positionY;
    private float positionZ;
    private float time;
    public float TargetSpawnDistance = 6.0f;
    public GameObject[] targets;

    private void TargetGenerate() //Targetの生成
    {
        positionX = Random.Range(-8.0f, 8.0f);
        positionY = Random.Range( 0.2f, 0.5f);
        positionZ = Random.Range( 0.0f, 8.0f);
        Vector3 targetPosition = new Vector3(positionX,positionY,positionZ);

        int randomIndex = Random.Range(0, targets.Length);

        Quaternion rotation = Quaternion.Euler(0, 180, 0);
        Instantiate(targets[randomIndex], targetPosition, rotation);
    }

    void Start()
    {
        this.time = 0.0f;
        TargetGenerate();
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= TargetSpawnDistance)
        {
            time = 0.0f;
            TargetGenerate();
        }
    }
}

