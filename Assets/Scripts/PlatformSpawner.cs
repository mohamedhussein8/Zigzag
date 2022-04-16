using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // so this is a platform that we want to spawn
    public GameObject platform;
    // so this is a diamonds that we want to spawn
    public GameObject diamonds; 
    //the last postion where our platform was  we leh m7tago 3l4an agep al new position
    Vector3 lastPos;
    // so this will be the siz of our platform
    float size;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        // hna hagep al position 
        lastPos = platform.transform.position;
        // hna ba3rf al size 
        size = platform.transform.localScale.x;
        for (int i=0; i<20; i++)
        {
            SpawnPlatforms();
        }
        

    }
    public void StartSpawningPlatforms()
    {
        // can any func repeatedly after a specific amount of time 
        // htstna 0.1 sec 3l4an t4ta8l we kol 0.2 sec htnade mara 
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        // hna al shart da hepa true lma al game ta5ls ea3ne game over we fe al fun al gwa script gamemanager htpa true 
        if (GameManager.instance.gameOver==true )
        {
            CancelInvoke("SpawnPlatforms");
        }
    }
    // de hna 3l4an ttla3 platform 34way random
    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if(rand <3)
        {
            SpawnX();
        }
        else if (rand >= 3)
        {
            SpawnZ();
        }

    }
    // hna etl3 fe atgah x
    void SpawnX()
    {
        Vector3 pos = lastPos;
        // hna ekam 3la al adem we ea3ml platform gdeda 
        pos.x += size;
        // 3l4an al postion al gded hepa hwa al adem ly al pa3do we kda 
        lastPos = pos; 
        // m3na a5er 7aga m4 3aezen rotation a7na pas 3aez al new postion 
        // pos hna het7at ba3d ma at7sb fe al satr al fo da 
        Instantiate(platform, pos, Quaternion.identity);
        // hna 3l4an enazel diamonnds 3la al platform
        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamonds, new Vector3 (pos.x, pos.y+1, pos.z), diamonds.transform.rotation);
        }
    }
    // hna etl3 fe atgah z 
    void SpawnZ()
    {
        Vector3 pos = lastPos;
        // hna ekam 3la al adem we ea3ml platform gdeda 
        pos.z += size;
        // 3l4an al postion al gded hepa hwa al adem ly al pa3do we kda 
        lastPos = pos;
        // m3na a5er 7aga m4 3aezen rotation a7na pas 3aez al new postion 
        // pos hna het7at ba3d ma at7sb fe al satr al fo da 
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
        }
    }
}
