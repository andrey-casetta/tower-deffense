using UnityEngine;
using System.Collections;
using System;

public class TowerTrigger : MonoBehaviour {

    public Tower twr;
    public bool lockE;
    public GameObject curTarget;
    GameObject closestEnemy;
    float closestDistance = 100f;
    public float shootingRange = 5f;

    void Update() {

        if (curTarget) {

            float distance = Vector3.Distance(transform.position, curTarget.transform.position);
          
            if (distance > shootingRange || curTarget.CompareTag("Dead")) // get it from EnemyHealth
            {
                lockE = false;
                twr.target = null;
                GetTarget();
            }
        } else {
            GetTarget();
        }

        if (!curTarget) {
            lockE = false;
        }
    }

    private void GetTarget() {
        Collider[] enemies = Physics.OverlapSphere(transform.position, shootingRange, 1 << 8);

        for (int i = 0; i < enemies.Length; i++) {
            float distance = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (distance < closestDistance) {
                closestEnemy = enemies[i].gameObject;
            }
        }

        if (closestEnemy) {
            Transform target = closestEnemy.transform.GetChild(0);

            twr.target = target;
            curTarget = target.gameObject;

        }
    }
}
