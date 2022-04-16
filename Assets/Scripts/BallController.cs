using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject particle; 
    //speed by which the ball move 
    [SerializeField]
    float speed;
    // our game has started or not law ah edelo al sr3a 8er kda la 
    bool started;
    // da 3l4an a3rf mno en hwa mat mslan law hwa pe true epa 5asr 5las 
    bool gameOver;
    Rigidbody rb;
    // with fuc i can access to the  Rigidbody 
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // so now by using rb we contained any properties of this  Rigidbody
    }
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false; 
    }

    // Update is called once per frame
    void Update()
    {
        // hna 3l4an m4 awel ma ados play e4ta8l polo law hwa m4 48al astna l7ad ma edos click 
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                // leh 3mlt kda 3l4an awaf al code al fol 3l4an ader a8er al atgah bra7te lkan 8er kda kan hefdel ma4y fol pas 
                started = true;
                // hna bnade 3la fun al gwa scipt GameManager
                GameManager.instance.StartGame();
            }
        }
        // da 3l4an al kora ta3 bsr3a 
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        //  raycast simply return true or false when this is colliding with any other game object it return true lakn law not colliding htrg3 false 
       if(! Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            //da hna 3l4an lma e5rog bra al msa7a al kora ta3 ta7t 
            rb.velocity = new Vector3(0, -25f, 0);
            // mn 5lal da ana ader aswel ly al script bta3 al camera  we 3mlha be true 3l4ab mkml4 follow fe al scipt al tane 
            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            // hna bnade 3la fun al gwa scipt GameManager
            GameManager.instance.GameOver();

        }
        // m3na al 0 ea3ne das click 4mal aw sahm  we kman an game over m4 pe true ekaml 3l4an law pe true kda 5sr 
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }
    //de 3l4an a7dd al direction
    void SwitchDirection()
    {
        //so now if the if the ball has velocity in the same direction then we are switching the direction
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
    // so this OnTriggerEnter fun gets called whenever our ball enters into any trigger 
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            // hna 3aezo pa3d ma edamr etl3 effect kda we hna polo fe mkan al collider  we a5er gomla de 3l4an m4 3aez rotition
            // so that means we are instantiating  the particle and storing it as a gameobject in our gameobject part 
            GameObject part= Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f);
        }
    }
}
