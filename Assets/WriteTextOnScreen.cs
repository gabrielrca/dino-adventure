/*
Esse codigo eh para mostrar mensagens.

Cada mensagem deve ter a sua logica feita dentro do update e controlada por um booleano displayMessage_XX
onde xx eh o numero da mensagem

Se por acaso quiser saber se ja mostrou mensagem deve usar uma variavel booleana jaMostrouMessage_XX
onde xx eh o numero da mensagem

Mexer com cuidado!
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteTextOnScreen : MonoBehaviour
{
    //Pego aqui os objetos do jogo relativos ao display da messagem
    private GameObject dialogText; //texto da mensagem
    private GameObject dialogBG; //fundo da caixa de mensagem
    private GameObject dialogInfo; //informacao da tecla para ser pressionada

    //iterador de quantas mensagens de um dialogo foram faladas
    private int message_iterator;
    //diz quantas mensagens tem em um dialogo
    private int message_quantity;

    private bool displayingMessage; //se o personagem ainda esta mostrando mensagem

    //----------------------------------------------------
    //---------VARIAVEIS DE MENSAGEM AQUI ABAIXO---------
    //----------------------------------------------------

    //----Variaveis relativas a mensagem 1 ---
    private bool displayMessage_1; //se eh pra mostrar mensagem 1
    private bool jaMostrouMessage_1; //se ja mostrou mensagem 1
    //---FIM das Variaveis relativas a mensagem 1

    // Start is called before the first frame update
    void Start()
    {
      //pego os objetos do jogo relativos ao display da mensagem
      dialogText = GameObject.Find("Dialog_Text");
      dialogBG = GameObject.Find("Dialog_bg");
      dialogInfo = GameObject.Find("Dialog_Text_info");
      //apago a caixa de dialogo da mensagem
      dialogBG.SetActive(false);
      dialogText.SetActive(false);
      dialogInfo.SetActive(false);
      //comeco os iteradores e a quantidade de mensagem em zero
      message_iterator=0;
      message_quantity=0;
      //informo que nao ta mostrando mensagem
      displayingMessage = false;

      //----------------------------------------------------
      //---------VARIAVEIS DE MENSAGEM AQUI ABAIXO---------
      //----------------------------------------------------

      //---Variaveis relativas a mensagem 1
      //digo  que ainda nao mostrou e que nao é pra mostrar mensagem 1
      displayMessage_1 = false;
      jaMostrouMessage_1 = false;
      //---FIM das Variaveis relativas a mensagem 1


    }

    // Update is called once per frame
    void Update()
    {

      //----------------------------------------------------
      //---------CODIGO DA MENSAGEM 1---------
      //----------------------------------------------------

      //se for prar mostrar mensagem 1
      if(displayMessage_1){// verifica se esta mostrando mensagem 1

        displayingMessage =true;//diz que esta mostrando mensagem

        //fala a quantidade de mensagem (lembrando que começa em zero)
        message_quantity = 1; // entao esse valor eh sempre quantidade - 1

        if(message_iterator == 0){ //se for a mensagem zero
          WriteOnScreen("Oh! Estou tão no alto! 0.o  \n Será que estou no céu?! "); //fala mensagem zero
        }
        if(message_iterator == 1){ //se for mensagem 1
          WriteOnScreen("Preciso voltar para a terra e descobrir o que aconteceu!!"); //fala mensagem 1
        }

          //verifica aqui se o iterador de mensagens diz que ja mostrou todas as mensagems
          if (message_quantity < message_iterator){ //se ja mostrou todas as mensagens
            displayingMessage = false; //diz que nao ta mostrando nenhuma mensagem
            message_iterator =0; // bota o iterador de mensagem pra zero


            //----------------------------------------------------
            //---------VARIAVEIS DE MENSAGEM AQUI ABAIXO---------
            //----------------------------------------------------

            displayMessage_1 = false; //diz que nao ta mostrando mais mensagem 1
            jaMostrouMessage_1 = true; //diz que ja mostrou mensagem 1

          }

      }
      //----------------------------------------------------
      //---------FIM DO CODIGO DA MENSAGEM 1---------
      //----------------------------------------------------


      //Logica para apagar a mensagem apos mostrar
      if(Input.GetKeyDown(KeyCode.X))
      {

        //verifico se esta mostrando alguma mensagem
        if(displayingMessage){ // se tiver mostrando mensagem
          message_iterator +=1; //incrementa o contador de mensagem
        }else{ // se nao tiver mostrando mensagem
          message_iterator = 0; //deixa o iterador sempre em zero
        }

        //depois apaga o background, o texto e a informacao
        dialogBG.SetActive(false);
        dialogText.SetActive(false);
        dialogInfo.SetActive(false);

        //tira o jogo do pause
        Time.timeScale = 1.0f;
      }



    }



    void OnCollisionEnter2D(Collision2D other)
    {
      //se ele bater no bloco que e o primeiro do jogo e ainda nao mostrou mensagem
      if(other.gameObject.name=="first_tile" && !jaMostrouMessage_1)
      {
        displayMessage_1 = true; //diz que eh pra mostrar a mensagem

      }


    }

    void WriteOnScreen(string s)
    {
        dialogBG.SetActive(true);
        dialogText.SetActive(true);
        dialogInfo.SetActive(true);
        dialogText.GetComponent<Text>().text = s;
        Time.timeScale = 0.0f;


    }




}
