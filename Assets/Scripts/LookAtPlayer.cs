using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {
    private Transform player;

    [SerializeField]
    private float rotSpeed = 5f;


    void Start() {
        player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }

    void Update() {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
    }
}
