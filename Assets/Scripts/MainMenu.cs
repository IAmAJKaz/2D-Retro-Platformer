using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string lvToLoad;
    
    
    public void PlayGame() {
        SceneManager.LoadScene(lvToLoad);
    }
    
    
    public void QuitGame() {
        Application.Quit();
    }


}
