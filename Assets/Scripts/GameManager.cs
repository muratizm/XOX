using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator anim;
    private GameObject gameTable;
    char[] board = new char[9];
    int[] magicSquare = new int[] { 4, 9, 2, 3, 5, 7, 8, 1, 6 };
    GameBoxes[] gameBoxes;
    private PauseMenu pauseMenu;

    private void Start()
    {
        
        pauseMenu = FindObjectOfType<PauseMenu>();
        gameTable = GameObject.FindGameObjectWithTag("GameTable");
        gameBoxes = FindObjectsOfType<GameBoxes>();
        anim = FindObjectOfType<Animator>();
        BoardPattern();
        //ticTacToe.board = new char[]{' ', ' ', 'x',
        //                             'o', 'x', 'o',
        //                             'x', ' ', 'o'};
    }

    private void Update()
    {
        //BoardPattern();
        //checkWinner();

        
        if ((gameBoxes[0].gameObject.GetComponent<Rigidbody>().angularVelocity.z == 0) &&
            (gameBoxes[1].gameObject.GetComponent<Rigidbody>().angularVelocity.z == 0) &&
            (gameBoxes[2].gameObject.GetComponent<Rigidbody>().angularVelocity.z == 0) &&
            (gameBoxes[3].gameObject.GetComponent<Rigidbody>().angularVelocity.z == 0) && 
            (gameBoxes[4].gameObject.GetComponent<Rigidbody>().angularVelocity.z == 0) && 
            (gameBoxes[5].gameObject.GetComponent<Rigidbody>().angularVelocity.z == 0) && 
            (gameBoxes[6].gameObject.GetComponent<Rigidbody>().angularVelocity.z == 0) && 
            (gameBoxes[7].gameObject.GetComponent<Rigidbody>().angularVelocity.z == 0) &&
            (gameBoxes[8].gameObject.GetComponent<Rigidbody>().angularVelocity.z == 0))
        {
            checkWinner();
        }
    }

    public void checkWinner()
    {
       
        if (hasWon('X'))
        {
            NewScene();
            FinishLevel(true);
        }
        else if (hasWon('O'))
        {
            NewScene();
            FinishLevel(true); 
        }
        
    }

    bool hasWon(char player)
    {
        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 9; j++)
                for (int k = 0; k < 9; k++)
                    if (i != j && i != k && j != k)
                        if (board[i] == player && board[j] == player && board[k] == player)
                            if (magicSquare[i] + magicSquare[j] + magicSquare[k] == 15)
                                return true;
        return false;
    }
    public void BoardPattern()
    {
        for (int i = 0; i < gameTable.transform.childCount; i++)
        {
            if ((int)Vector3.Cross(Vector3.up, gameTable.transform.GetChild(i).transform.right).magnitude == 0) //vektörler paralelse x yönü için 
            {
                if (Vector3.Dot(Vector3.up, gameTable.transform.GetChild(i).transform.right) > 0)
                {
                    
                    //board[i] = g.transform.GetChild(i).GetChild(0).transform.GetComponent<TMP_Text>().text[0];
                }
                else
                {
                    //board[i] = faceRepresent[OppositeDirectionValues.x];
                }
            }
            else if ((int)Vector3.Cross(Vector3.up, gameTable.transform.GetChild(i).transform.up).magnitude == 0) //vektörler paralelse y yönü için 
            {
                if (Vector3.Dot(Vector3.up, gameTable.transform.GetChild(i).transform.up) > 0)
                {
                    
                    board[i] = gameTable.transform.GetChild(i).GetChild(0).transform.GetComponent<TMP_Text>().text[0];
                }
                else
                {
                    
                    board[i] = gameTable.transform.GetChild(i).GetChild(1).transform.GetComponent<TMP_Text>().text[0];
                }
            }
            else if ((int)Vector3.Cross(Vector3.up, gameTable.transform.GetChild(i).transform.forward).magnitude == 0) //z yönünde yazýmýz yok
            {
                if (Vector3.Dot(Vector3.up, gameTable.transform.GetChild(i).transform.forward) > 0)
                {
                    
                    board[i] = gameTable.transform.GetChild(i).GetChild(2).transform.GetComponent<TMP_Text>().text[0];
                }
                else
                {
                    
                    board[i] = gameTable.transform.GetChild(i).GetChild(3).transform.GetComponent<TMP_Text>().text[0];
                }
            }

        }

    }

    public void FinishLevel(bool levelWon)
    {
        //gameObject.SetActive(false);
        PauseMenu.levelDone = true;
        PauseMenu.levelWon = levelWon;
        Invoke("FinishLevel2", 1f);
    }

    public void FinishLevel2()
    {
        pauseMenu.Pause();
    }
    private void NewScene()
    {

        PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex + 1);
    }
}
