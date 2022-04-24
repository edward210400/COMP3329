using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject level_select = null;

    public void LoadScene(string level)
    { 
        SceneManager.LoadScene("Level1");
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("New Scene");
    }

    public void LoadLevel1(){
        // Load Level One
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2(){
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3(){
        SceneManager.LoadScene("Level3");
    }

    public void LoadLevelSelect(){
        level_select.SetActive(true);
    }

    public void BackButton1(){
        level_select.SetActive(false);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
