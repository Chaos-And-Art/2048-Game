using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{

}

#region GameManagerOrign
[System.Serializable]
public class OrignSave1{
    public int xS, yS;
    public int score1;
    public List<int> tileNumber1 = new List<int>();
    public List<int> posX1 = new List<int>();
    public List<int> posY1 = new List<int>();

    public OrignSave1(GameManagerOrign gameManagerOrign){
    xS = gameManagerOrign.x;
    yS = gameManagerOrign.y;

        for(xS = 0; xS <=3; xS++){
            for (yS=0; yS<=3; yS++){
                if (gameManagerOrign.Grid[xS, yS] != null){
                    tileNumber1.Add(gameManagerOrign.Grid[xS,yS].GetComponent<Tiles>().Number);
                    posX1.Add(xS);
                    posY1.Add(yS);
                }
            }
        }
        score1 = gameManagerOrign.theScore;
    }
}

[System.Serializable]
public class OrignSave2{
    public int xS, yS;
    public int score2;
    public List<int> tileNumber2 = new List<int>();
    public List<int> posX2 = new List<int>();
    public List<int> posY2 = new List<int>();

    public OrignSave2(GameManagerOrign gameManagerOrign){
    xS = gameManagerOrign.x;
    yS = gameManagerOrign.y;

        for(xS = 0; xS <=3; xS++){
            for (yS=0; yS<=3; yS++){
                if (gameManagerOrign.Grid[xS, yS] != null){
                    tileNumber2.Add(gameManagerOrign.Grid[xS,yS].GetComponent<Tiles>().Number);
                    posX2.Add(xS);
                    posY2.Add(yS);
                }
            }
        }
        score2 = gameManagerOrign.theScore;
    }
}

[System.Serializable]
public class OrignExitData{
    public int xS, yS;
    public int exitScore;
    public List<int> exitTileNumber = new List<int>();
    public List<int> exitX = new List<int>();
    public List<int> exitY = new List<int>();

    public OrignExitData(GameManagerOrign gameManagerOrign){
    xS = gameManagerOrign.x;
    yS = gameManagerOrign.y;

        for(xS = 0; xS <=3; xS++){
            for (yS=0; yS<=3; yS++){
                if (gameManagerOrign.Grid[xS, yS] != null){
                    exitTileNumber.Add(gameManagerOrign.Grid[xS,yS].GetComponent<Tiles>().Number);
                    exitX.Add(xS);
                    exitY.Add(yS);
                }
            }
        }
        exitScore = gameManagerOrign.theScore;
    }
}
#endregion

#region GameManager4x4
[System.Serializable]
public class SavedData1{
    public int xS, yS;
    public int score1;
    public List<int> tileNumber1 = new List<int>();
    public List<int> posX1 = new List<int>();
    public List<int> posY1 = new List<int>();

    public SavedData1(GameManager4x4 gameManager4x4){
    xS = gameManager4x4.x;
    yS = gameManager4x4.y;

        for(xS = 0; xS <=3; xS++){
            for (yS=0; yS<=3; yS++){
                if (gameManager4x4.Grid[xS, yS] != null){
                    tileNumber1.Add(gameManager4x4.Grid[xS,yS].GetComponent<Tiles>().Number);
                    posX1.Add(xS);
                    posY1.Add(yS);
                }
            }
        }
        score1 = gameManager4x4.theScore;
    }
}

[System.Serializable]
public class SavedData2{
    public int xS, yS;
    public int score2;
    public List<int> tileNumber2 = new List<int>();
    public List<int> posX2 = new List<int>();
    public List<int> posY2 = new List<int>();

    public SavedData2(GameManager4x4 gameManager4x4){
    xS = gameManager4x4.x;
    yS = gameManager4x4.y;

        for(xS = 0; xS <=3; xS++){
            for (yS=0; yS<=3; yS++){
                if (gameManager4x4.Grid[xS, yS] != null){
                    tileNumber2.Add(gameManager4x4.Grid[xS,yS].GetComponent<Tiles>().Number);
                    posX2.Add(xS);
                    posY2.Add(yS);
                }
            }
        }
        score2 = gameManager4x4.theScore;
    }
}

[System.Serializable]
public class ExitData{
    public int xS, yS;
    public int exitScore;
    public List<int> exitTileNumber = new List<int>();
    public List<int> exitX = new List<int>();
    public List<int> exitY = new List<int>();

    public ExitData(GameManager4x4 gameManager4x4){
    xS = gameManager4x4.x;
    yS = gameManager4x4.y;

        for(xS = 0; xS <=3; xS++){
            for (yS=0; yS<=3; yS++){
                if (gameManager4x4.Grid[xS, yS] != null){
                    exitTileNumber.Add(gameManager4x4.Grid[xS,yS].GetComponent<Tiles>().Number);
                    exitX.Add(xS);
                    exitY.Add(yS);
                }
            }
        }
        exitScore = gameManager4x4.theScore;
    }
}
#endregion

#region GameManager3x3
[System.Serializable]
public class Saved3x3Data1{
    public int xS, yS;
    public int score1;
    public List<int> tileNumber1 = new List<int>();
    public List<int> posX1 = new List<int>();
    public List<int> posY1 = new List<int>();

    public Saved3x3Data1(GameManager3x3 gameManager3x3){
    xS = gameManager3x3.x;
    yS = gameManager3x3.y;

        for(xS = 0; xS <=2; xS++){
            for (yS=0; yS<=2; yS++){
                if (gameManager3x3.Grid[xS, yS] != null){
                    tileNumber1.Add(gameManager3x3.Grid[xS,yS].GetComponent<Tiles>().Number);
                    posX1.Add(xS);
                    posY1.Add(yS);
                }
            }
        }
        score1 = gameManager3x3.theScore;
    }
}

[System.Serializable]
public class Saved3x3Data2{
    public int xS, yS;
    public int score2;
    public List<int> tileNumber2 = new List<int>();
    public List<int> posX2 = new List<int>();
    public List<int> posY2 = new List<int>();

    public Saved3x3Data2(GameManager3x3 gameManager3x3){
    xS = gameManager3x3.x;
    yS = gameManager3x3.y;

        for(xS = 0; xS <=2; xS++){
            for (yS=0; yS<=2; yS++){
                if (gameManager3x3.Grid[xS, yS] != null){
                    tileNumber2.Add(gameManager3x3.Grid[xS,yS].GetComponent<Tiles>().Number);
                    posX2.Add(xS);
                    posY2.Add(yS);
                }
            }
        }
        score2 = gameManager3x3.theScore;
    }
}

[System.Serializable]
public class ExitData3x3{
    public int xS, yS;
    public int exitScore;
    public List<int> exitTileNumber = new List<int>();
    public List<int> exitX = new List<int>();
    public List<int> exitY = new List<int>();

    public ExitData3x3(GameManager3x3 gameManager3x3){
    xS = gameManager3x3.x;
    yS = gameManager3x3.y;

        for(xS = 0; xS <=2; xS++){
            for (yS=0; yS<=2; yS++){
                if (gameManager3x3.Grid[xS, yS] != null){
                    exitTileNumber.Add(gameManager3x3.Grid[xS,yS].GetComponent<Tiles>().Number);
                    exitX.Add(xS);
                    exitY.Add(yS);
                }
            }
        }
        exitScore = gameManager3x3.theScore;
    }
}
#endregion