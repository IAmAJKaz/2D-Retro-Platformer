using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

    public int enemyHP;
    private int currentHP;

    private Animator theAnim;
    private bool isDead;

    private Collider2D parentCol;
    private Collider2D hurtboxCol;

    void Start() {
        currentHP = enemyHP;

        theAnim = transform.parent.GetComponent<Animator>();

        parentCol = transform.parent.GetComponent<Collider2D>();
        hurtboxCol = GetComponent<Collider2D>();
    }


    void Update() {
        if (currentHP <= 0) {
            isDead = true;
            theAnim.SetBool("Dead", isDead);
            parentCol.enabled = false;
            hurtboxCol.enabled = false;
            StartCoroutine("KillSwitch");
            //Destroy(transform.parent.gameObject);
        }
    }

    public void TakeDamage(int damage) {
        currentHP -= damage;
    }

    IEnumerator KillSwitch() {
        yield return new WaitForSeconds(2f);
        Destroy(transform.parent.gameObject);
    }
}
