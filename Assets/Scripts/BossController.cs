using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public Transform firePoint;
    public GameObject shotPrefab;
    public float shotForce;

    public float timeBetweenShots;

    [SerializeField]
    private float shotTimer;

    void Start() {
        shotTimer = timeBetweenShots;
    }


    void Update() {
        shotTimer -= Time.deltaTime;
        if(shotTimer <= 0) {
            shotTimer = timeBetweenShots;
            Shoot();
        }
    }

    void Shoot() {
        GameObject laser = Instantiate(shotPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2d = laser.GetComponent<Rigidbody2D>();
        rb2d.AddForce(firePoint.up * shotForce, ForceMode2D.Impulse);
    }
}
