using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tiles : MonoBehaviour
{
    [System.Serializable]
    public class TileStyleClassic{
        public int Number;
        public Color TextColor;
        public Color TileColor;
    }

    public TileStyleClassic[] tileStyleClassic;
    public TileStyleClassic[] tileStyleDark;
    [Space(20)]

    public TextMeshProUGUI TileText;
    public Image TileImage;

    bool move, _combine;
    int _x2, _y2;

    public int number;
    public int Number{
        get{
            return number;
        }
        set{
            number = value;
            GetStyle(number);
        }
    }

    void Awake(){
        TileText = GetComponentInChildren<TextMeshProUGUI>();
        TileImage = transform.Find("TileImage").GetComponent<Image>();

        Animator animate = GetComponent<Animator>();    
        if(PlayerPrefs.GetInt("Grid") == 2 || PlayerPrefs.GetInt("Original") == 1){
            animate.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Tiles 4x4");
        }
        else if(PlayerPrefs.GetInt("Grid") == 1){
            animate.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Tiles 3x3");
        }
    }

    void Update() {
        if (move) Move(_x2, _y2, _combine);
    }

    public void Move(int x2, int y2, bool combine)
    {
        move = true; _x2 = x2; _y2 = y2; _combine = combine;
        if(PlayerPrefs.GetInt("Grid") == 2 || PlayerPrefs.GetInt("Original") == 1){
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.1f * x2, 1.1f * y2, 0), 0.4f);
            if (transform.position == new Vector3(1.1f * x2, 1.1f * y2, 0))
            {
                move = false;
                if (combine) { _combine = false; Destroy(gameObject); }
            }
        }
        else if(PlayerPrefs.GetInt("Grid") == 1){
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(.18f + (1.48f * x2),.18f + (1.48f * y2), 0), 0.4f);
            if (transform.position == new Vector3(.18f + (1.48f * x2),.18f + (1.48f * y2), 0))
            {
                move = false;
                if (combine) { _combine = false; Destroy(gameObject); }
            }
        }
    }

    #region Tile Style
    void ApplyStyleClassic(int index){
        TileText.text = tileStyleClassic[index].Number.ToString();
        TileText.color = tileStyleClassic[index].TextColor;
        TileImage.color = tileStyleClassic[index].TileColor;
    }

    void ApplyStyleDark(int index){
        TileText.text = tileStyleDark[index].Number.ToString();
        TileText.color = tileStyleDark[index].TextColor;
        TileImage.color = tileStyleDark[index].TileColor;
    }

    void GetStyle(int number){
        switch (number){
            case 0:
            if(PlayerPrefs.GetInt("Theme") == 0  || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(0);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(0);
            }
            break;

            case 2:
            if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(1);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(1);
            }
            break;

            case 4:
                if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(2);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(2);
            }
            break;

            case 8:
                if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(3);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(3);
            }
            break;

            case 16:
                if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(4);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(4);
            }
            break;

            case 32:
                if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(5);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(5);
            }
            break;

            case 64:
                if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(6);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(6);
            }
            break;

            case 128:
                if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(7);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(7);
            }
            break;

            case 256:
                if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(8);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(8);
            }
            break;

            case 512:
                if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(9);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(9);
            }
            break;

            case 1024:
                if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(10);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(10);
            }
            break;

            case 2048:
                if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1 || PlayerPrefs.GetInt("FirstTimeL") == 1 || PlayerPrefs.GetInt("FirstTimeT") == 1){
                ApplyStyleClassic(11);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                ApplyStyleDark(11);
            }
            break;
            
            default:
            Debug.LogError("Check Numbers to Pass Through for Style");
            break;

        }
    }
#endregion
}