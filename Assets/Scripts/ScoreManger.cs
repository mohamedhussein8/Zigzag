using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManger : MonoBehaviour
{
    public static ScoreManger instance;
    // that will store our score
    public int score;
    public int highScore; 

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
        score = 0;
        // da 3l4an a5zn al score fe key 3la al computer 
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void incrementScore()
    {
        score += 1;
    }
    // will repeatedly call our score
    public void startScore()
    {
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
    }
    public void StopScore()
    {
        CancelInvoke("incrementScore");
        // hna ba3d ma a5ls 3aez a7fz a5er score ly fe key 
        PlayerPrefs.SetInt("score", score);
        if (PlayerPrefs.HasKey("highScore"))
        {
            // hna polo hat al value al mt5az fe 7aga 3andk asmha highscore we akarn 
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                // law al score al gded akber mn al adem epa hwa al high score al gded we a5zno bma3na ha5do mn al score 
                // score da al current score 
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        // hwa awel mara aslan he5a4 fe al else 3l4an ma3ndo4 ay valw ba3d kda la 
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
