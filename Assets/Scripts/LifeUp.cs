using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour {

    private LivesManager theLM;

    
    void Start() {
        theLM = FindObjectOfType<LivesManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            theLM.AddLife();
            Destroy(gameObject);
        }
    }
}
