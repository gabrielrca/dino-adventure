using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYForwardBack : MonoBehaviour
{

    private float MoveSpeed = 1f;
    private float Distance = 20f;

    private Vector2 originalPosition;

    private Vector2 finalPos;
  //private float deltaX;

    private bool isGoing;
    private bool pegouFinal;

    private void Start()
    {
        originalPosition = transform.position;
        isGoing = true;
        pegouFinal = true;
    }

    private void Update()
    {

       if(Vector2.Distance(originalPosition, transform.position) < Distance  && isGoing){
         Vector3 movement = new Vector3(0f, -1f, 0f);
         transform.position += movement * Time.deltaTime * MoveSpeed;



       }else{
         isGoing=false;
         if(pegouFinal){
            finalPos=transform.position;
            pegouFinal = false;
         }

         Vector3 movement = new Vector3(0f, 1f, 0f);
         transform.position += movement * Time.deltaTime * MoveSpeed;

       }

       if(Vector2.Distance(finalPos, transform.position) > Distance){
         isGoing=true;
         pegouFinal=true;
       }

    }



}