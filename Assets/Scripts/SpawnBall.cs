using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject prefab;

    public float destroyTime = 1f;
    private float timeCount;

    void SpawnBallFunction()
    {
        GameObject go = Instantiate(prefab, transform.position, transform.rotation);
        Destroy(go, destroyTime);
    }
}
