using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowTo : MonoBehaviour
{
    public GameObject HowToPlay;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;

    int next;
    bool hasPressed;


    public void Play(){
        HowToPlay.SetActive(true);
        p1.SetActive(true);
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
        p5.SetActive(false);
        p6.SetActive(false);
    }

    public void nextSlide(){
        if(next == 0 && hasPressed == false){
            p1.SetActive(false);
            p2.SetActive(true);
            hasPressed = true;
            next++; 
        }
        else if(next == 1 && hasPressed == true){
            p2.SetActive(false);
            p3.SetActive(true);
            hasPressed = false;
            next++;
        }
        else if(next == 2 && hasPressed == false){
            p3.SetActive(false);
            p4.SetActive(true);
            hasPressed = true;
            next++;
        }

        else if(next == 3 && hasPressed == true){
            p4.SetActive(false);
            p5.SetActive(true);
            hasPressed = false;
            next++;
        }
        else if(next == 4 && hasPressed == false){
            p5.SetActive(false);
            p6.SetActive(true);
            hasPressed = true;
            next++;
        }
    }

    public void prevslide(){
        if(next == 1 && hasPressed == true){
            p1.SetActive(true);
            p2.SetActive(false);
            hasPressed = false;
            next--; 
        }
        else if(next == 2 && hasPressed == false){
            p2.SetActive(true);
            p3.SetActive(false);
            hasPressed = true;
            next--;
        }
        else if(next == 3 && hasPressed == true){
            p3.SetActive(true);
            p4.SetActive(false);
            hasPressed = false;
            next--;
        }

        else if(next == 4 && hasPressed == false){
            p4.SetActive(true);
            p5.SetActive(false);
            hasPressed = true;
            next--;
        }
        else if(next == 5 && hasPressed == true){
            p5.SetActive(true);
            p6.SetActive(false);
            hasPressed = false;
            next--;
        }
    }

    public void close(){
        HowToPlay.SetActive(false);
        hasPressed = false;
        next = 0;
    }
}
