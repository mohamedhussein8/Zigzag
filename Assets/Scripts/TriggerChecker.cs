using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // this fuc does is this fuc gets automatically called by unity whenever an object goes out or exit from the trigger 
    void OnTriggerExit(Collider col)
    {
        // hna bsal hwa 3da wla la 
        if(col.gameObject.tag == "Ball")
        {
            // this invoke helps us to call a func after a few sec of time or any time we want  hadeha asm al fun we al wat 
            Invoke("FallDown", 0.5f);
            FallDown();
        }
    }
    // 3mlna al fuc de leh 3l4an check gravity bst5dam gravity option bta3t platform so that the platform falls down automatically
    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        // hna 3l4an lma ta3 tmot 5als mtfdal4 ta5d wat 
        Destroy(transform.parent.gameObject, 0.2f);
    }
}
