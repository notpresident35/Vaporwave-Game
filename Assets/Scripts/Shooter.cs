using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public float ShootDelay;
    public GameObject BulletPrefab;
    public Transform Barrel;

    float iterator;

    private void Update () {
        iterator += Time.deltaTime;
    }

    public void TryShoot () {
        if (iterator > ShootDelay) {
            Shoot ();
            iterator = 0;
        }
    }

    void Shoot () {
        Instantiate (BulletPrefab, Barrel.position, Barrel.rotation, null);
    }
}
