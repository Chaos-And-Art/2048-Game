using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ThemeManager : MonoBehaviour
{
    [System.Serializable]
    public class TileStyleClassic{
        public Color TextColor;
        public Color ThemeColor;
        public Color ButtonColor;
        public Color ScoreColor;
    }

    public TileStyleClassic[] tileStyleClassic;
    public TileStyleClassic[] tileStyleDark;

    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI ScoreValue;
    public TextMeshProUGUI HighScoreValue;
    [Space(20)]

    public Image ThemeBackGround;
    public Image Button1BackGround;
    public Image Button2BackGround;
    public Image Button3BackGround;
    public Image Button4BackGround;
    [Space(20)]

    public Image Score1BackGround;
    public Image Score2BackGround;
    public GameObject Classic3x3;
    public GameObject Dark3x3;

    void ApplyStyleClassic(int index){
        TitleText.color = tileStyleClassic[index].TextColor;
        ScoreText.color = tileStyleClassic[index].TextColor;
        HighScoreText.color = tileStyleClassic[index].TextColor;
        ScoreValue.color = tileStyleClassic[index].TextColor;
        HighScoreValue.color = tileStyleClassic[index].TextColor;
        ThemeBackGround.color = tileStyleClassic[index].ThemeColor;

        if(PlayerPrefs.GetInt("Original") == 1){
            Button1BackGround.color = tileStyleClassic[index].ButtonColor;
            Button2BackGround.color = tileStyleClassic[index].ButtonColor;
            Button3BackGround.color = tileStyleClassic[index].ButtonColor;
        }
        else{
            Button1BackGround.color = tileStyleClassic[index].ButtonColor;
            Button2BackGround.color = tileStyleClassic[index].ButtonColor;
            Button3BackGround.color = tileStyleClassic[index].ButtonColor;
            Button4BackGround.color = tileStyleClassic[index].ButtonColor;
        }
        Score1BackGround.color = tileStyleClassic[index].ScoreColor;
        Score2BackGround.color = tileStyleClassic[index].ScoreColor;
        if(PlayerPrefs.GetInt("Grid") == 1){
            Classic3x3.SetActive(true);
        }
    }

    void ApplyStyleDark(int index){
        TitleText.color = tileStyleDark[index].TextColor;
        ScoreText.color = tileStyleDark[index].TextColor;
        HighScoreText.color = tileStyleDark[index].TextColor;
        ScoreValue.color = tileStyleDark[index].TextColor;
        HighScoreValue.color = tileStyleDark[index].TextColor;
        ThemeBackGround.color = tileStyleDark[index].ThemeColor;

        if(PlayerPrefs.GetInt("Original") == 1){
            Button1BackGround.color = tileStyleDark[index].ButtonColor;
            Button2BackGround.color = tileStyleDark[index].ButtonColor;
            Button3BackGround.color = tileStyleDark[index].ButtonColor;
        }
        else{
            Button1BackGround.color = tileStyleDark[index].ButtonColor;
            Button2BackGround.color = tileStyleDark[index].ButtonColor;
            Button3BackGround.color = tileStyleDark[index].ButtonColor;
            Button4BackGround.color = tileStyleDark[index].ButtonColor;
        }
        Score1BackGround.color = tileStyleDark[index].ScoreColor;
        Score2BackGround.color = tileStyleDark[index].ScoreColor;
        if(PlayerPrefs.GetInt("Grid") == 1){
            Dark3x3.SetActive(true);
        }
    }

    public void SetStyle(){
        if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeL") == 1){
            ApplyStyleClassic(0);
        }
        else if(PlayerPrefs.GetInt("Theme") == 1){
            ApplyStyleDark(0);
        }
    }
}
