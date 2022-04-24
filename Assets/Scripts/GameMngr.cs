using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMngr : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Character = null;
    public CharacterManager _characterScript;

    public GameObject LevelCompleted;

    public GameObject GameOverBoard;

    void Start()
    {
        _characterScript = Character.GetComponent<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_characterScript.life == 0)
        {
            GameOverBoard.SetActive(true);
            Time.timeScale = 0;
        }
        if (_characterScript.Finished == true){
            LevelCompleted.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
