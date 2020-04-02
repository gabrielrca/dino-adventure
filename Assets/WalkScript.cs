/*Gabriel Rodrigues Caldas de Aquino
**01/04/2020
**Script para andar e mudar o sprite
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour
{
      //Velocidade do movimento do personagem
      public float moveSpeed = 5f;
      //Variavel para informar parametros ao animador do sprite
      private Animator anim;
      //Variavel para o sprite do personagem flipar se tiver indo ou voltando
      private SpriteRenderer mySpriteRenderer;
      //Variavel que define o tempo inicial que o sprite do pulo ocorreu
      public System.DateTime lastJumpTime;

      public bool onSolidTerrain = true;
      public bool onWaterTerrain = false;

      //Pegar o terreno que ele está colidindo e mudar algum parametro
      void OnCollisionStay2D(Collision2D other)
      {
           if(other.gameObject.tag=="water_terrain"){
             onSolidTerrain = false;
             onWaterTerrain = true;
           }

           if(other.gameObject.tag=="solid_terrain"){
             onSolidTerrain = true;
             onWaterTerrain = false;
           }


      }




    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator> (); //para a animacao do sprite
       mySpriteRenderer = GetComponent<SpriteRenderer>(); //para a flipar o sprite
    }

    // Update is called once per frame
    void Update()
    {


      //Realiza as transformacoes de velocidade para o personagem andar
      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
      if(onWaterTerrain)
      {
        //velocidade de andar reduzida
        transform.position += movement * Time.deltaTime * moveSpeed/5;
        //informa a velocidade pro sprite mudar transacao idle <-> run
        anim.SetFloat("Speed", 0);
      }
      if(onSolidTerrain)
      {
        //velocidade normal de andar
        transform.position += movement * Time.deltaTime * moveSpeed;
        //informa a velocidade pro sprite mudar transacao idle <-> run
        anim.SetFloat("Speed", 10*Mathf.Abs(Input.GetAxis("Horizontal")));
      }


        //flipa o sprite se tiver voltando
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
          mySpriteRenderer.flipX = true; //parametro de flip do sprite
        }
        //flipa o sprite se tiver indo
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
          mySpriteRenderer.flipX = false; //parametro de flip do sprite
        }

        //faz o sprite pular
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true); //variavel para informar o pulo
            lastJumpTime = System.DateTime.UtcNow; //quando o pulo ocorreu
        }

        //verificar se o tempo do pulo
        System.TimeSpan ts = System.DateTime.UtcNow - lastJumpTime;
        if(ts.Milliseconds > 200) //se maior que ... milisegundos
        {
          anim.SetBool("Jump", false); //ja acabou o pulo
        }



    }

}
