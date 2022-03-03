using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManagement : MonoBehaviour
{
    public GameObject[] _prefabAnimalList;
    public float countDown = 0;
    public float DelayCoutDown = 1;
    [Header("Force Direction Scale")]
    public float upForce = 1f;
    public float sideForcce = 0.1f;
    public int _score = 0;
    public static GameManagement singleton;

    [Header("Pooling")]
    public int LinkCount = 0;
    public int LimitSpwan = 100;


    // Start is called before the first frame update
    void Start()
    {
        countDown = DelayCoutDown;
        singleton = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnAnimal();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Lean.Pool.LeanPool.DespawnAll();
        }

    }
    public void FixedUpdate()
    {
        countDown -= Time.deltaTime;

        if (countDown < 0 && LinkCount < LimitSpwan)
            SpawnAnimal();
    }
    void SpawnAnimal()
    {
        countDown = DelayCoutDown;
        int indexAnimal = Random.Range(0, _prefabAnimalList.Length);
        //GameObject Obj = Instantiate(_prefabAnimalList[indexAnimal]);
        GameObject poolObj = Lean.Pool.LeanPool.Spawn(_prefabAnimalList[indexAnimal], this.transform.position, Quaternion.identity);
        float xForce = Random.Range(-sideForcce, sideForcce);
        float yForce = Random.Range(upForce / 2f, upForce);
        poolObj.GetComponent<Rigidbody2D>().AddForce(
                  new Vector2(xForce, yForce), ForceMode2D.Impulse);
        LinkCount = Lean.Pool.LeanPool.Links.Count;

    }
    public void PlusScore()
    {
        _score++;
    }
}

