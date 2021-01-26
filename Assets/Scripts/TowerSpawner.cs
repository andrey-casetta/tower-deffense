using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour {

    [SerializeField]
    Transform towerPosition;

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject tower = ObjectPoolerManager.instance.GetPooledObject(PoolObjectType.Tower) as GameObject;
            tower.transform.position = towerPosition.position;
            tower.SetActive(true);
            
        }

    }
}
