using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFallenMace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
          //quando o player entra em contato com o chao
         if(other.gameObject.tag=="solid_terrain"){
           Invoke("vanish", 2f);
         }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void vanish(){
      Destroy(gameObject);
    }
}
