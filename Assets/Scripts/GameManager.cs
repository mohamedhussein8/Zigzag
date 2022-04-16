using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void StartGame()
    {
        // hna bnade 3la fun al gwa scipt uimanager
        UiManager.instance.GameStart();
        // hna bnade 3la fun al gwa scipt ScoreManager
        ScoreManger.instance.startScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms(); 
    }
   public  void GameOver()
    {
        // hna bnade 3la fun al gwa scipt uimanager
        UiManager.instance.GameOver();
        // hna bnade 3la fun al gwa scipt ScoreManager
        ScoreManger.instance.StopScore();
        gameOver = true;
    }
}
