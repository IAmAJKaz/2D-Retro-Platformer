using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour {

    //public int defaultLives;
    public int livesCounter;

    public Text livesText;

    private GameManager theGM;
    
    
    void Start() {
        livesCounter = PlayerPrefs.GetInt("CurrentLives");

        theGM = FindObjectOfType<GameManager>();
    }

   
    void Update() {
        livesText.text = "x " + livesCounter;

        if (livesCounter < 1) {
            StartCoroutine("QueGameOver");
        }
    }

    public void TakeLife() {
        livesCounter--;
        PlayerPrefs.SetInt("CurrentLives", livesCounter);
    }

    public void AddLife() {
        livesCounter++;
        PlayerPrefs.SetInt("CurrentLives", livesCounter);
    }

    IEnumerator QueGameOver() {
        yield return new WaitForSeconds(1.5f);
        theGM.GameOver();
    }


}
