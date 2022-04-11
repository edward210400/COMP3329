using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(string level)
    { 
        SceneManager.LoadScene("Level1");
    }
}
