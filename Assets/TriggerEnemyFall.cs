//Este script e concebido para derrubar uma mace que esta estatica flutuando em um chao
//para isso ocorrer deve se relacionar a mace com o chao
//cada chao deve ser declarado como "Floor_mace_XX" onde XX e o id do chao
//a mace acima de cada chao deve ser declarada como "Mace_Fall_XX" XX e o id da Mace
//deve se declarar o msm XX para o floor e pra mace pra ficar mais facil
//e essa declaracao deve ser feita no nome de cada objeto
//esse scrpit relaciona as maces e o chao por nomes e deve ser usado cada mace com nome diferente
//se botar o mesmo nome em varias maces e em varios chaos .. nao vai dar erro de compilacao
//mas vai ser mais dificil de debugar


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyFall : MonoBehaviour
{

    //declarando cada mace com o numero XX do id no final seguindo "MaceToFallXX"
    public GameObject MaceToFall1;
    public GameObject MaceToFall2;

    void Start()
    {
        //encontrando cada mace com o numero XX do id no final seguindo "Mace_Fall_XX"
        MaceToFall1 = GameObject.Find("Mace_Fall_1");
        MaceToFall2 = GameObject.Find("Mace_Fall_2");
    }
    void OnCollisionEnter2D(Collision2D other)
    {
          //quando o player entra em contato com o chao
         if(other.gameObject.tag=="Player"){
           //verifica qual eh o chao pelo if abaixo
           if(gameObject.name =="Floor_mace_1"){
             //muda o tipo da mace espeficia... 
             //lembrando sempre de trocar o id XX se copiar e colar
             //senao pode dar problema de cair 2 maces em lugares diferentes
              MaceToFall1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            //verifica qual eh o chao pelo if abaixo
            if(gameObject.name =="Floor_mace_2"){
              //muda o tipo da mace espeficia...
              //lembrando sempre de trocar o id XX se copiar e colar
              //senao pode dar problema de cair 2 maces em lugares diferentes
               MaceToFall2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
             }

         }



    }
    // Update is called once per frame
    void Update()
    {

    }
}
