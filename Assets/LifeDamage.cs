using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private float vida;
    public GameObject lifeText;
    //public Text textbox;
    private Animator anim;


    void Start()
    {
      vida = 100;
      //textbox = GetComponent<Text>();
      lifeText = GameObject.Find("LifeText");
      anim = GetComponent<Animator> ();

    }

    //void OnCollisionEnter2D(Collider other)
    void OnCollisionStay2D(Collision2D other)
    {
         if(other.gameObject.tag=="enemy_mace"){
              vida += -1;
              //Debug.Log(vida);
              //Destroy(gameObject);
         }
         if(other.gameObject.tag=="life_potion"){
              vida += 10;
              //Debug.Log(vida);
              //Destroy(gameObject);
         }

    }


    // Update is called once per frame
    void Update()
    {
     lifeText.GetComponent<Text>().text = "Vida:" + vida +"%";

     if(vida < 0){
      anim.SetFloat("Vida", vida);
      Invoke("Reload_Level", 1.0f);

     }


    }

    void Reload_Level(){
      Application.LoadLevel(Application.loadedLevel);
    }

}
