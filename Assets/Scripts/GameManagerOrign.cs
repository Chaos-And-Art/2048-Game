using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerOrign : MonoBehaviour {
    public enum MoveDirection{
        Up, Down, Right, Left
    }
    public UIManager uIManager;

    Vector3 firstPos, gap;
    bool wait, move, stop, won;
    int i, j, k, l, savedScore;
    public int x, y, pressed;
    public GameObject[,] Grid = new GameObject[4, 4];
  
    public Transform EmptyGrid;
    public Transform PlayGrid;
    public GameObject backgroundClassic, backgroundDark;

    private int score;
    public TextMeshProUGUI ScoreOriginal;
    public TextMeshProUGUI HighScoreOriginal;

    public List<Transform> newTile = new List<Transform>();

	void Start () {
        if(PlayerPrefs.GetInt("Original") == 1){
            if(PlayerPrefs.GetInt("PlayingOrign", 0) == 1){
                CreateGrid();
                ExitLoad(0);
            }
            else{
                CreateGrid();
                SpawnTile(2);
            }
            HighScoreOriginal.SetText(PlayerPrefs.GetInt("HighScore Orign", 0).ToString());
        }
    }

    public int theScore {
        get {
            return score;
        }

        set{
            score = value;
            ScoreOriginal.text = score.ToString();

            if (score > PlayerPrefs.GetInt("HighScore Orign", 0)){
                PlayerPrefs.SetInt("HighScore Orign", score);
                HighScoreOriginal.SetText(score.ToString());
            }
        }
    }
#region UserInput
	void Update () {
        if(uIManager.HowtoP == true){
            stop = true;
        }
        else if(uIManager.HowtoP == false){
            stop = false;
        }
        if(PlayerPrefs.GetInt("Original") == 1){
            if (stop) return;
            if (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            wait = true;
            firstPos = Input.GetMouseButtonDown(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position;
        }

        if (Input.GetMouseButton(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            gap = (Input.GetMouseButton(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position) - firstPos;
            if (gap.magnitude < 100){
                return;
            }
            gap.Normalize();
            if (wait){
                wait = false;
                if (gap.y > 0 && gap.x > -0.5f && gap.x < 0.5f){
                    Move(MoveDirection.Up);
                }
                else if (gap.y < 0 && gap.x > -0.5f && gap.x < 0.5f){
                    Move(MoveDirection.Down);
                }
                else if (gap.x > 0 && gap.y > -0.5f && gap.y < 0.5f){
                    Move(MoveDirection.Right);
                }
                else if (gap.x < 0 && gap.y > -0.5f && gap.y < 0.5f){
                    Move(MoveDirection.Left);
                }
                else{
                    return;
                }

                if (move){
                    move = false;
                    SpawnTile(1);
                    k = 0;
                    l = 0;

                    for(x = 0; x <=3; x++) for (y=0; y<=3; y++)
                        {

                            if (Grid[x, y] == null) { k++; continue; }
                            if (Grid[x, y].tag == "Combine") Grid[x, y].tag = "Untagged";
                        }
                    if(k == 0)
                    {
                        for (y = 0; y <= 3; y++) for (x = 0; x <= 2; x++) if (Grid[x, y].GetComponent<Tiles>().Number == Grid[x + 1, y].GetComponent<Tiles>().Number) l++;
                        for (x = 0; x <= 3; x++) for (y = 0; y <= 2; y++) if (Grid[x, y].GetComponent<Tiles>().Number == Grid[x, y + 1].GetComponent<Tiles>().Number) l++;
                        if (l == 0) { stop = true; uIManager.PlayerLost(); return; }
                    }
                    PlayerPrefs.SetInt("PlayingOrign", 1);
                    ExitSave();
                }
            }
        }
    }
}
#endregion

#region SaveAndLoad
    public void BackButton(){
        uIManager.GameOver.SetActive(false);
        uIManager.GameWin.SetActive(false);
        stop = false;
        if(pressed == 0 || pressed == 1){   
            if(PlayerPrefs.GetInt("MovedOrign") == 1){
                LoadGame1(0);
                PlayerPrefs.SetInt("MovedOrign", 0);
            }
            else if(PlayerPrefs.GetInt("MovedOrign") == 0){
                LoadGame2(0);
                PlayerPrefs.SetInt("MovedOrign", 1);
            }
        }
        pressed++;
    }
    public void SaveGame1(){
        SavingSystem.OrignSave1(this);
    }
    public void LoadGame1(int index){
        OrignSave1 data = SavingSystem.OrignLoad1();
        string Tile = "Tiles";
        if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1){
            foreach(Transform tile in PlayGrid){
                Destroy(tile.gameObject);
            }
        }
        else if(PlayerPrefs.GetInt("Theme") == 1){
            foreach(Transform tile in PlayGrid){
                Destroy(tile.gameObject);
            }
        }
        for(i = 0; i < data.posX1.Count; i++){
            x = data.posX1[index];
            y = data.posY1[index];

            Grid[x,y] = (GameObject)Instantiate(Resources.Load(Tile), new Vector2( data.posX1[index] * 1.1f,  data.posY1[index] * 1.1f), Quaternion.identity);
            if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1){
                Grid[x, y].transform.SetParent(PlayGrid);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                Grid[x, y].transform.SetParent(PlayGrid);
            }
            Grid[x,y].GetComponent<Tiles>().Number = data.tileNumber1[index];
            index++;
        }
        theScore = data.score1;
    }

    public void SaveGame2(){
        SavingSystem.OrignSave2(this);
    }
    public void LoadGame2(int index){
        OrignSave2 data = SavingSystem.OrignLoad2();
        string Tile = "Tiles";
        if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1){
            foreach(Transform tile in PlayGrid){
                Destroy(tile.gameObject);
            }
        }
        else if(PlayerPrefs.GetInt("Theme") == 1){
            foreach(Transform tile in PlayGrid){
                Destroy(tile.gameObject);
            }
        }
        for(i = 0; i < data.posX2.Count; i++){
            x = data.posX2[index];
            y = data.posY2[index];

            Grid[x,y] = (GameObject)Instantiate(Resources.Load(Tile), new Vector2( data.posX2[index] * 1.1f,  data.posY2[index] * 1.1f), Quaternion.identity);
            if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1){
                Grid[x, y].transform.SetParent(PlayGrid);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                Grid[x, y].transform.SetParent(PlayGrid);
            }
            Grid[x,y].GetComponent<Tiles>().Number = data.tileNumber2[index];
            index++;
        }
        theScore = data.score2;
    }

    public void ExitSave(){
        SavingSystem.OrignExitData(this);
    }
    public void ExitLoad(int index){
        OrignExitData data = SavingSystem.OrignExitLoad();
        string Tile = "Tiles";
        if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1){
            foreach(Transform tile in PlayGrid){
                Destroy(tile.gameObject);
            }
        }
        else if(PlayerPrefs.GetInt("Theme") == 1){
            foreach(Transform tile in PlayGrid){
                Destroy(tile.gameObject);
            }
        }
        for(i = 0; i < data.exitX.Count; i++){
            x = data.exitX[index];
            y = data.exitY[index];

            Grid[x,y] = (GameObject)Instantiate(Resources.Load(Tile), new Vector2( data.exitX[index] * 1.1f,  data.exitY[index] * 1.1f), Quaternion.identity);
            if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1){
                Grid[x, y].transform.SetParent(PlayGrid);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                Grid[x, y].transform.SetParent(PlayGrid);
            }
            Grid[x,y].GetComponent<Tiles>().Number = data.exitTileNumber[index];
            index++;
        }
        theScore = data.exitScore;
    }
#endregion

#region TileMovement
    public void Move(MoveDirection move){
        if(PlayerPrefs.GetInt("MovedOrign") == 0){
            SaveGame1();
            PlayerPrefs.SetInt("MovedOrign", 1);
        }
        else if(PlayerPrefs.GetInt("MovedOrign") == 1){
            SaveGame2();
            PlayerPrefs.SetInt("MovedOrign", 0);
        }
        pressed = 0;
        if(move == MoveDirection.Up){
            for (x = 0; x <= 3; x++){
                for (y = 0; y <= 2; y++){
                    for (i = 3; i >= y + 1; i--){
                        MoveOrCombine(x, i - 1, x, i);
                    }
                }
            }
        }
        if(move == MoveDirection.Down){
            for (x = 0; x <= 3; x++){
                for (y = 3; y >= 1; y--){
                    for (i = 0; i <= y - 1; i++){
                        MoveOrCombine(x, i + 1, x, i);
                    }
                }
            }
        }
        if(move == MoveDirection.Right){
            for (y = 0; y <= 3; y++){
                for (x = 0; x <= 2; x++){
                    for (i = 3; i >= x + 1; i--){
                        MoveOrCombine(i - 1, y, i, y);
                    }
                }
            }
        }
        if(move == MoveDirection.Left){
            for (y = 0; y <= 3; y++){
                for (x = 3; x >= 1; x--){
                    for (i = 0; i <= x - 1; i++){
                        MoveOrCombine(i + 1, y, i, y);
                    }
                }
            }
        }
    }

    void MoveOrCombine(int x1, int y1, int x2, int y2)
    {
        string tile = "Tiles";
        if (Grid[x2, y2] == null && Grid[x1, y1] != null)
        {
            move = true;
            Grid[x1, y1].GetComponent<Tiles>().Move(x2, y2, false);
            Grid[x2, y2] = Grid[x1, y1];
            Grid[x1, y1] = null;
        }

        if (Grid[x1, y1] !=null && Grid[x2, y2] != null && Grid[x1, y1].GetComponent<Tiles>().Number == Grid[x2, y2].GetComponent<Tiles>().Number && Grid[x1, y1].tag != "Combine" && Grid[x2, y2].tag != "Combine")
        {
            move = true;
            int combineValue = Grid[x1, y1].GetComponent<Tiles>().Number * 2;
            theScore += combineValue;
            Grid[x1, y1].GetComponent<Tiles>().Move(x2, y2, true);
            Destroy(Grid[x2, y2]);
            Grid[x1, y1] = null;
            Grid[x2, y2] = (GameObject)Instantiate(Resources.Load(tile), new Vector3(1.1f * x2, 1.1f * y2, 0), Quaternion.identity);
            Grid[x2, y2].GetComponent<Tiles>().Number = combineValue;
            if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1){
                Grid[x2, y2].transform.SetParent(PlayGrid);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                Grid[x2, y2].transform.SetParent(PlayGrid);
            }
            
            Grid[x2, y2].tag = "Combine";
            Grid[x2, y2].GetComponent<Animator>().SetTrigger("Combine 4x4");

            if(combineValue == 2048 && won == false){
                uIManager.PlayerWon();
                won = true;
            }
        }
    }
#endregion
    
#region GridAndSpawn
    void SpawnTile(int amount){
        for(int i = 0; i < amount; i++){
            while (true){ 
                x = Random.Range(0, 4);
                y = Random.Range(0, 4); 
                if (Grid[x, y] == null){
                    break;
                }
            }

            Vector2 newTileLocation = new Vector3(1.1f * x, 1.1f * y);
            string tile = "Tiles";

            Grid[x,y] = (GameObject)Instantiate(Resources.Load(tile), newTileLocation, Quaternion.identity);
            int RandomTile = Random.Range(0,2);
            if(RandomTile == 0){
                Grid[x,y].GetComponent<Tiles>().Number = 2;
            }
            else{
                Grid[x,y].GetComponent<Tiles>().Number = 4;
            }
            if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1){
                Grid[x,y].transform.SetParent(PlayGrid);
            }
            else if(PlayerPrefs.GetInt("Theme") == 1){
                Grid[x,y].transform.SetParent(PlayGrid);
            }
            Grid[x, y].GetComponent<Animator>().SetTrigger("Spawn 4x4");
        }
    }

    void CreateGrid(){
        if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1){
            GameObject Back = Instantiate(backgroundClassic, new Vector3(1.65f, 1.65f, 90), Quaternion.identity);
            Back.transform.SetParent(EmptyGrid);
        }
        else if(PlayerPrefs.GetInt("Theme") == 1){
            GameObject Back = Instantiate(backgroundDark, new Vector3(1.65f, 1.65f, 90), Quaternion.identity);
            Back.transform.SetParent(EmptyGrid);
        }

        string Tile = "Tiles";
        for(int x = 0; x < 4; x++){
            for(int y = 0; y < 4; y++){
                Vector2 position = new Vector2(1.1f * x, 1.1f * y);
                GameObject eTile = (GameObject)Instantiate(Resources.Load(Tile), position, Quaternion.identity);
                eTile.GetComponent<Tiles>().Number = 0;
                if(PlayerPrefs.GetInt("Theme") == 0 || PlayerPrefs.GetInt("FirstTimeO") == 1){
                    eTile.transform.SetParent(EmptyGrid);
                }
                else if(PlayerPrefs.GetInt("Theme") == 1){
                    eTile.transform.SetParent(EmptyGrid);
                }    
            }
        }
    }
}
#endregion

//new Vector3(1.5f *(1.1f), 1.5f *(1.1f)
//new Vector3(.18f + (1.48f * x),.18f + (1.48f * y)