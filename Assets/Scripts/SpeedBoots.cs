using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoots : MonoBehaviour {

    private PlayerController thePlayer;
    public float duration;

    void Start() {
        thePlayer = FindObjectOfType<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            StartCoroutine("SpeedBoost");
        }
    }

    IEnumerator SpeedBoost() {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        thePlayer.speed *= 2;
        yield return new WaitForSeconds(duration);
        thePlayer.speed = thePlayer.dfltSpeed;
        Destroy(gameObject);
    }
}
