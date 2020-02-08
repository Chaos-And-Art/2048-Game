using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class UIManager : MonoBehaviour
{
    public Transform theCamera;
    public static UIManager uIManager;
    public HowTo howTo;
    public GameManagerOrign gameManagerOrign;
    public GameObject levelManager;
    public GameManager4x4 gameManager4x4;
    public GameManager3x3 gameManager3x3;
    public GameObject GmOrigin;
    public GameObject Gm4x4;
    public GameObject Gm3x3;
    [Space(20)]

    public GameObject GameWin;
    public GameObject GameOver;
    public GameObject RestartConfirm;
    public GameObject MainMenu;
    public GameObject ButtonsInfo;
    public GameObject Hint3x3Button;
    public GameObject DisplayHint3x3;
    public GameObject Display2ndHint;
    [Space(20)]

    public GameObject arrow;
    public TextMeshProUGUI firstText;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    public TextMeshProUGUI infoText;
    [Space(20)]

    public GameObject OriginalPanel;
    public GameObject LevelsPanel;
    public GameObject TimedPanel;
    [Space(20)]

    public Transform ThemePanel, GridPanel;
    public GameObject Levels3x3, Levels4x4;

    public TextMeshProUGUI GameWinScore;
    public TextMeshProUGUI GameOverScore;

    private bool hasPressed;
    public bool HowtoP;
    private int restartCount, next;
    private float count;

    void Awake(){
        uIManager = this;
        Gm3x3.SetActive(false);
        Gm4x4.SetActive(false);
        levelManager.SetActive(false);
        Levels4x4.SetActive(false);
        Levels3x3.SetActive(false);
        OriginalPanel.SetActive(false);
        LevelsPanel.SetActive(false);
        TimedPanel.SetActive(false);
        GmOrigin.SetActive(false);
        restartCount = PlayerPrefs.GetInt("RestartC");

        //PlayerPrefs.DeleteAll();

        if(PlayerPrefs.GetInt("LastMode") == 1){
            Original();
        }
        else if(PlayerPrefs.GetInt("LastMode") == 2){
            Levels();
        }
        else if(PlayerPrefs.GetInt("LastMode") == 3){
            Timed();
        }
        else{
           MainMenu.SetActive(true);
        }
        if(PlayerPrefs.GetInt("RestartC") >=15){
            Hint3x3Button.SetActive(true);
        }
    }

    void Update(){
        if(PlayerPrefs.GetInt("BoolO") == 0){
            arrow.SetActive(true);
            firstText.gameObject.SetActive(true);
            count += Time.deltaTime;
            Vector3 startScale = arrow.transform.position;
            arrow.transform.position = startScale + new Vector3(0, (1 * .009f ) * Mathf.Sin(count * 3), 0.0f);
        }
    }
    
    public void Original(){
        MainMenu.SetActive(false);
        theCamera.transform.position = new Vector3(1.65f, 1.65f, -10);
        OriginalPanel.SetActive(true);
        PlayerPrefs.SetInt("Original", 1);
        PlayerPrefs.SetInt("Levels", 0);
        PlayerPrefs.SetInt("Timed", 0);
        PlayerPrefs.SetInt("LastMode", 1);

        if(PlayerPrefs.GetInt("BoolO", 0) == 0){ 
            PlayerPrefs.SetInt("FirstTimeO", 1);
            ButtonControls();
            PlayerPrefs.SetInt("BoolO", 1);
        }   
        GmOrigin.SetActive(true);
        OriginalPanel.GetComponent<ThemeManager>().SetStyle();
    }

    public void Levels(){
        MainMenu.SetActive(false);
        LevelsPanel.SetActive(true);
        PlayerPrefs.SetInt("Original", 0);
        PlayerPrefs.SetInt("Levels", 1);
        PlayerPrefs.SetInt("Timed", 0);
        PlayerPrefs.SetInt("LastMode", 2);

        if(PlayerPrefs.GetInt("BoolL", 0) == 0){ 
            PlayerPrefs.SetInt("FirstTimeL", 1);
            PlayerPrefs.SetInt("Grid", 1);
            ButtonControls();
            PlayerPrefs.SetInt("BoolL", 1);
        }
        levelManager.SetActive(true);
        LevelsPanel.GetComponent<ThemeManager>().SetStyle();
    }

    public void Timed(){
        MainMenu.SetActive(false);
        TimedPanel.SetActive(true);
        PlayerPrefs.SetInt("Original", 0);
        PlayerPrefs.SetInt("Levels", 0);
        PlayerPrefs.SetInt("Timed", 1);
        PlayerPrefs.SetInt("LastMode", 3);

        if(PlayerPrefs.GetInt("BoolT", 0) == 0){ 
            PlayerPrefs.SetInt("FirstTimeT", 1);
            PlayerPrefs.SetInt("Grid", 0);
            ButtonControls();
            PlayerPrefs.SetInt("BoolT", 1);
        }
        
        TimedPanel.GetComponent<ThemeManager>().SetStyle();
    }

    public void MainMenuButton(){
        MainMenu.SetActive(true);
        PlayerPrefs.SetInt("LastMode", 0);
        SceneManager.LoadScene("Start");
    }

    public void HowToPlayButton(){
        howTo.Play();
        HowtoP = true;

    }

    public void ButtonControls(){
        ButtonsInfo.SetActive(true);
        if(PlayerPrefs.GetInt("Original") == 1){
            infoText.SetText("This button allows you to change the theme of the board");
            b1.SetActive(true);
            b2.SetActive(false);
            b3.SetActive(false);
            b4.SetActive(false);
            b5.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("Levels") == 1 || PlayerPrefs.GetInt("Timed") == 1){
            infoText.SetText("This button allows you to change the theme of the board");
            b1.SetActive(true);
            b2.SetActive(false);
            b3.SetActive(false);
            b4.SetActive(false);
            b5.SetActive(false);
        }
    }

    public void nextSlide(){
        if(next == 0 && hasPressed == false){
            if(PlayerPrefs.GetInt("Original") == 1){
                b1.SetActive(false);
                hasPressed = true;
                next++;
                nextSlide();
            }
            else if(PlayerPrefs.GetInt("Levels") == 1 || PlayerPrefs.GetInt("Timed") == 1){
                infoText.SetText("This button allows you to change the grid size");
                b1.SetActive(false);
                b2.SetActive(true);
                hasPressed = true;
                next++;
            }
        }
        else if(next == 1 && hasPressed == true){
            infoText.SetText("This button allows you to go back 2 previous moves you made");
            b2.SetActive(false);
            b3.SetActive(true);
            hasPressed = false;
            next++;
        }
        else if(next == 2 && hasPressed == false){
            infoText.SetText("This button allows you to restart your current game");
            b3.SetActive(false);
            b4.SetActive(true);
            hasPressed = true;
            next++;
        }

        else if(next == 3 && hasPressed == true){
            infoText.SetText("This button is to understand how the game works");
            b4.SetActive(false);
            b5.SetActive(true);
            hasPressed = false;
            next++;
        }
        else if(next == 4 && hasPressed == false){
            infoText.SetText("Have fun, and thanks for Playing! :D");
            b5.SetActive(false);
            hasPressed = true;
            next++;
        }
        else if(next == 5 && hasPressed == true){
            ButtonsInfo.SetActive(false);
        }
    }

    public void closePanel(){
        howTo.close();
        HowtoP = false;
        DisplayHint3x3.SetActive(false);
        Display2ndHint.SetActive(false);
    }

#region Buttons
    public void PlayerWon(){
        GameWin.SetActive(true);
        if(PlayerPrefs.GetInt("Original") == 1){
            GameWinScore.SetText(gameManagerOrign.theScore.ToString());
        }
        else if(PlayerPrefs.GetInt("Grid") == 0){
            GameWinScore.SetText(gameManager4x4.theScore.ToString());
        }
        else if(PlayerPrefs.GetInt("Grid") == 1){
            GameWinScore.SetText(gameManager3x3.theScore.ToString());
        }
    }

    public void PlayerLost(){
        GameOver.SetActive(true);
        if(PlayerPrefs.GetInt("Original") == 1){
            GameOverScore.SetText(gameManagerOrign.theScore.ToString());
        }
        else if(PlayerPrefs.GetInt("Grid") == 0){
            GameOverScore.SetText(gameManager4x4.theScore.ToString());
        }
        else if(PlayerPrefs.GetInt("Grid") == 1){
            GameOverScore.SetText(gameManager3x3.theScore.ToString());
        }
        restartCount++;
        PlayerPrefs.SetInt("RestartC", restartCount);
        if(PlayerPrefs.GetInt("RestartC") >=15){
            Hint3x3Button.SetActive(true);
        }
    }

    public void ContinuePlaying(){
        GameWin.SetActive(false);
    }

    public void PlayAgain(){
        if(PlayerPrefs.GetInt("Original") == 1){
            PlayerPrefs.SetInt("PlayingOrign", 0);
        }
        else if(PlayerPrefs.GetInt("Grid") == 0){
            PlayerPrefs.SetInt("Playing4x4", 0);
        }
        else if(PlayerPrefs.GetInt("Grid") == 1){
            PlayerPrefs.SetInt("Playing3x3", 0);
        }
        SceneManager.LoadScene("Start");
    }

    public void Hint(){
        if(hasPressed == false){
            if(PlayerPrefs.GetInt("RestartC") >=15 && PlayerPrefs.GetInt("RestartC") < 30){
                DisplayHint3x3.SetActive(true);
            }
            else if(PlayerPrefs.GetInt("RestartC") >=30){
                Display2ndHint.SetActive(true);
            }
        }
        else if(hasPressed == true){
            DisplayHint3x3.SetActive(false);
        }
    }

    public void Restart(){
        RestartConfirm.SetActive(true);
    }
    public void RestartYes(){
        if(PlayerPrefs.GetInt("Original") == 1){
            PlayerPrefs.SetInt("PlayingOrign", 0);
        }
        if(PlayerPrefs.GetInt("Levels") == 1){
            if(PlayerPrefs.GetInt("Grid") == 2){
                PlayerPrefs.SetInt("Playing4x4", 0);
            }
            
            if(PlayerPrefs.GetInt("Grid") == 1){
                PlayerPrefs.SetInt("Playing3x3", 0);
                restartCount++;
                PlayerPrefs.SetInt("RestartC", restartCount);
                if(PlayerPrefs.GetInt("RestartC") >= 15){
                    Hint3x3Button.SetActive(true);
                }
            }
        }
        SceneManager.LoadScene("Start");
    }
    public void RestartNo(){
        RestartConfirm.SetActive(false);
    }

    public void ClassicTheme(){
        if(PlayerPrefs.GetInt("Theme") == 0){
            ThemePanel.gameObject.SetActive(false);
            hasPressed = false;
        }
        else if(PlayerPrefs.GetInt("Theme") != 0){
            PlayerPrefs.SetInt("Theme", 1);
            PlayerPrefs.SetInt("Theme", 0);
            OriginalPanel.GetComponent<ThemeManager>().SetStyle();
            ThemePanel.gameObject.SetActive(false);
            SceneManager.LoadScene("Start");
        }
    }

    public void DarkTheme(){
        if(PlayerPrefs.GetInt("Theme") == 1){
            ThemePanel.gameObject.SetActive(false);
            hasPressed = false;
        }
        else if(PlayerPrefs.GetInt("Theme") != 1){
            PlayerPrefs.SetInt("Theme", 0);
            PlayerPrefs.SetInt("Theme", 1);
            PlayerPrefs.SetInt("FirstTimeO", 0);
            PlayerPrefs.SetInt("FirstTimeL", 0);
            PlayerPrefs.SetInt("FirstTimeT", 0);
            OriginalPanel.GetComponent<ThemeManager>().SetStyle();
            ThemePanel.gameObject.SetActive(false);
            SceneManager.LoadScene("Start");
        }
    }

    public void ThemeButton(){
        if(hasPressed == false){
            ThemePanel.gameObject.SetActive(true);
            hasPressed = true;
        }
        else if(hasPressed == true){
            ThemePanel.gameObject.SetActive(false);
            hasPressed = false;
        }
    }
}
#endregion