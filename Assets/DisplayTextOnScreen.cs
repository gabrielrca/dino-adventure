using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTextOnScreen : MonoBehaviour
{
    private GameObject dialogBG;
    public string textToWrite;
    public bool hasAnythingToDisplay;
    // Start is called before the first frame update
    void Start()
    {
      dialogBG = GameObject.Find("Dialog_bg");
      dialogBG.SetActive(false);
      gameObject.SetActive(false);
      hasAnythingToDisplay = false;

    }

    // Update is called once per frame
    void Update()
    {
      if(hasAnythingToDisplay){
        displayText(textToWrite);
      }

    }

    void displayText(string s){
      dialogBG.SetActive(true);
      gameObject.SetActive(true);
      //gameObject.GetComponent<Text>().text = s;

    }
}
