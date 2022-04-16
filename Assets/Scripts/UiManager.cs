using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// da 3l4an ader at3amel m3 7agat ui
using UnityEngine.UI;
// da 3l4an ader 2r2 scene fe 7alt reset 
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    // da ader mn 5lalo agep ay 7aga public hna fe ay script tany 
    public static UiManager instance;
    // we will need a refernce to all UI object that we want to active or deactive  3l4an kda 3mlna al varibals dol wa7d ly kol 7aga 
    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    // THIS is a reference to our score that we can change any time 
    public Text score;
    public Text highScore1;
    public Text highScore2;
    // ha3mel Awake fun de ht4ta8l abl start 
    void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // de htzrah fe al awel we . 
        highScore1.text = "High Score:" + PlayerPrefs.GetInt("highScore")   ;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    // so this fun will be called when the game start and it will just do everything when it need do 
    public void GameStart()
    {
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("panelUP");
    }
    // will simply reload the game from the beginning
    public void Reset()
    {
        // 0 3l4an a7na m3ndna4 8er wa7d pas 
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        // ba5d la value al fe key al asmo score we a7th fe al varibal al 3ande 3l4an a3rdo tostring 3l4an a7wel mn int ly string 
        score.text = PlayerPrefs.GetInt("score").ToString();
        // da al hezhar lma al game ta5ser lkan rakm 1 hezhr fe al aawel tostring 3l4an a7wel mn int ly string 
        highScore2.text= PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }
}
