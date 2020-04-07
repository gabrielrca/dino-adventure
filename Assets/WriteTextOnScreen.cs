using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteTextOnScreen : MonoBehaviour
{
    private GameObject dialogText;
    private GameObject dialogBG;
    private GameObject dialogInfo;

    // Start is called before the first frame update
    void Start()
    {
      dialogText = GameObject.Find("Dialog_Text");
      dialogBG = GameObject.Find("Dialog_bg");
      dialogInfo = GameObject.Find("Dialog_Text_info");
      dialogBG.SetActive(false);
      dialogText.SetActive(false);
      dialogInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


      if(Input.GetKeyDown(KeyCode.Space))
      {
        dialogBG.SetActive(false);
        dialogText.SetActive(false);
        dialogInfo.SetActive(false);
        Time.timeScale = 1.0f;
      }

    }



    void OnCollisionEnter2D(Collision2D other)
    {
      if(other.gameObject.name=="first_tile")
      {
        WriteOnScreen("Oh! Estou tão no alto!");
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

/*  dialogText.GetComponent<Text>().text = "Oh! Estou tão no alto!";
  while(!Input.GetKeyDown(KeyCode.Space)){
    //yield return null;
  }
  dialogText.GetComponent<Text>().text = "Para onde devo ir?";
  while(!Input.GetKeyDown(KeyCode.Space)){
    //yield return null;
  }
  turnOnDialog = false;
*/
