using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

    public int enemyHP;
    private int currentHP;


    void Start() {
        currentHP = enemyHP;
    }


    void Update() {
        if (currentHP <= 0) {
            Destroy(transform.parent.gameObject);
        }
    }

    public void TakeDamage(int damage) {
        currentHP -= damage;
    }


}
