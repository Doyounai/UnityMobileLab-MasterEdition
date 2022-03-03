using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawnEnemy : MonoBehaviour
{
    public GameObject _prefabAI;
    public Transform[] listPosition;
    public float DelaySpawn = 2.0f;
    private float countSpawn = 0;

    // Update is called once per frame
    void Update()
    {
        countSpawn += Time.deltaTime;
        if (countSpawn > DelaySpawn)
        {
            countSpawn = 0;
            GameObject ai = Instantiate(_prefabAI);
            int side = Random.Range(0, 2);
            ai.transform.position = listPosition[side].position;
            ai.GetComponent<SimpleAI>().Direction = ai.transform.position.normalized.x * -1;

        }
    }
}