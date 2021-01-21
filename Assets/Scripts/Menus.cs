using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour{
    
    public void Replay() {
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitGame() {
        Application.Quit();
    }

    
}
