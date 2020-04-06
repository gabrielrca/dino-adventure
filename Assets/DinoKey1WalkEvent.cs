using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoKey1WalkEvent : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator anim;
    private SpriteRenderer mySpriteRenderer;
    private bool move = false;

    public GameObject player;
    private LifeDamage ld;
    private Collider2D collider2d;
    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator> (); //para a animacao do sprite
      mySpriteRenderer = GetComponent<SpriteRenderer>();
      player =  GameObject.FindWithTag("Player");
      ld = player.GetComponent<LifeDamage>();
      collider2d = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
      if(other.gameObject.name=="Grass_dino_key_1_stop"){
        moveSpeed= 0f;
        collider2d.enabled= false;
      }
      if(other.gameObject.name=="Grass_dino_key_1_vanish"){
        Destroy(gameObject);
      }
      if(other.gameObject.tag=="Player" && ld.hasKey1){
        move=true;
      }
    }

    // Update is called once per frame
    void Update()
    {
      if(move){
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        mySpriteRenderer.flipX = false;
        Vector3 movement = new Vector3(1f, 0f, 0f);

        //velocidade normal de andar
        transform.position += movement * Time.deltaTime * moveSpeed;
        //informa a velocidade pro sprite mudar transacao idle <-> run
        anim.SetFloat("Speed", moveSpeed);
        Invoke("vanish", 2.0f);
      }


    }
    void vanish(){
      Destroy(gameObject);
    }
}
