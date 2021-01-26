using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    public Transform[] startPoints;
    public Transform[] endPoints;


    void Start() {
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn() {
        yield return new WaitForSeconds(2);
        int i = Random.Range(0, 3);
        GameObject enemy = null;

        switch (i) {
            case 0:
                enemy = ObjectPoolerManager.instance.GetPooledObject(PoolObjectType.EnemyBlue) as GameObject;
                break;
            case 1:
                enemy = ObjectPoolerManager.instance.GetPooledObject(PoolObjectType.EnemyGoblin) as GameObject;
                break;
            case 2:
                enemy = ObjectPoolerManager.instance.GetPooledObject(PoolObjectType.EnemyRed) as GameObject;
                break;
        }

        enemy.transform.position = startPoints[Random.Range(0, startPoints.Length)].position;
        enemy.transform.rotation = Quaternion.identity;

        enemy.GetComponent<Enemy>().waypoints[0] = endPoints[Random.Range(0, endPoints.Length)];

        enemy.SetActive(true);
        StartCoroutine(StartSpawn());
    }
}
