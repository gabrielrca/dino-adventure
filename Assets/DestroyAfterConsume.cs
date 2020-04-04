using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterConsume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionStay2D(Collision2D other)
    {
         if(other.gameObject.tag=="Player"){
           //Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
              Destroy(gameObject);
              //Debug.Log(vida);
              //Destroy(gameObject);
         }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
