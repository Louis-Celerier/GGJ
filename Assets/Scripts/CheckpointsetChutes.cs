using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsetChutes : MonoBehaviour
{

    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = this.transform.position;
    }

   void OnTriggerEnter (Collider other) 
   {
        if (other.gameObject.tag == "Checkpoint") 
        {
            lastPos = this.transform.position;
        }

        if (other.gameObject.tag == "Mort") 
        {
            transform.position = lastPos;
        }
   }
   
}
