using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private float vida;
    private float coins;
    public GameObject lifeText;
    public GameObject lifePotion;
    public GameObject lifeGaugeForegound;
    public GameObject lifeGaugeBackground;

    //public Text textbox;
    private Animator anim;

    public bool hasKey1 = false;


    void Start()
    {
      vida = 200;
      coins = 0;
      //textbox = GetComponent<Text>();
      lifeText = GameObject.Find("LifeText");
      lifeGaugeForegound = GameObject.Find("Life_bar_fg");
      lifePotion = GameObject.FindWithTag("life_potion");
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
         if(other.gameObject.tag=="point_coin"){
              coins += 1;
            //  Physics2D.IgnoreCollision(coinObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
              //Debug.Log(vida);
              //Destroy(gameObject);
         }
         if(other.gameObject.name=="key_1"){
              hasKey1 = true;
            //  Physics2D.IgnoreCollision(coinObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
              //Debug.Log(vida);
              //Destroy(gameObject);
         }


    }



    // Update is called once per frame
    void Update()
    {
     lifeText.GetComponent<Text>().text = " " + coins * 1500 + " ";
     lifeGaugeForegound.GetComponent<RectTransform>().sizeDelta = new Vector2(vida, 37.8f);
    // lifeGaugeForegound.anchoredPosition = new Vector2(m_XAxis, m_YAxis);

     if(vida >= 200){
       vida = 200;
       Physics2D.IgnoreCollision(GetComponent<Collider2D>(), lifePotion.GetComponent<Collider2D>());
     }

     if(vida <= 0){
       vida=0;
      anim.SetFloat("Vida", vida);
      Invoke("Reload_Level", 2.0f);

     }


    }

    void Reload_Level(){
     SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

}
