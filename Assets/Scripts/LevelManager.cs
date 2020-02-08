using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public UIManager uIManager;
    private bool hasPressed;

    public GameObject notUnlocked;
    public GameObject lock4x4;

    void Start(){
        if(PlayerPrefs.GetInt("Levels") == 1){
            if(PlayerPrefs.GetInt("Grid") == 1){
                uIManager.Gm3x3.SetActive(true);
                uIManager.Levels3x3.gameObject.SetActive(true);
            }
            else if(PlayerPrefs.GetInt("Grid") == 2){
                uIManager.Gm4x4.SetActive(true);
                uIManager.Levels4x4.gameObject.SetActive(true);
            }
        }

        if(PlayerPrefs.GetInt("LvPass") == 1){
            lock4x4.SetActive(false);
            uIManager.Hint3x3Button.SetActive(false);
        }
    }

    public void GridButton(){
        if(hasPressed == false){
            uIManager.GridPanel.gameObject.SetActive(true);
            hasPressed = true;
        }
        else if(hasPressed == true){
            uIManager.GridPanel.gameObject.SetActive(false);
            hasPressed = false;
        }
    }

    public void Grid4x4(){
        if(PlayerPrefs.GetInt("LvPass") == 1){
            lock4x4.SetActive(false);
            if(PlayerPrefs.GetInt("Grid") == 2){
                uIManager.GridPanel.gameObject.SetActive(false);
                hasPressed = false;
            }
            else if(PlayerPrefs.GetInt("Grid") != 2){
                PlayerPrefs.SetInt("Grid", 2);
                SceneManager.LoadScene("Start");
            }
        }
        else{
            StartCoroutine(beatLevel());
        }
    }

    public void Grid3x3(){
        if(PlayerPrefs.GetInt("Grid") == 1){
            uIManager.GridPanel.gameObject.SetActive(false);
            hasPressed = false;
        }
        else if(PlayerPrefs.GetInt("Grid") != 1){
            PlayerPrefs.SetInt("Grid", 1);
            SceneManager.LoadScene("Start");
        }
    }

    IEnumerator beatLevel (){
        notUnlocked.SetActive(true);
        yield return new WaitForSeconds (3);
        notUnlocked.SetActive(false);
    }
}

