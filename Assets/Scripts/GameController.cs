using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{

    public Text[] buttonList;
    private string playerSide;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public int moveCount;
    public GameObject restartButton;
    public ColorBlock theColor;
    public ColorBlock theColor1;
    private string playerSide1;
    public int a = 10;
    public int b = 10;
    public int flag = 0;
    public List<int> myList = new List<int>();







    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        for (int i = 0; i < buttonList.Length; i++)
        {
            theColor = buttonList[i].GetComponentInParent<Button>().colors;
            theColor1 = buttonList[i].GetComponentInParent<Button>().colors;

        }
        playerSide = "X";
        playerSide1 = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
        restartButton.SetActive(true);
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {

        return playerSide;

        // else{
        //     return playerSide1;
        // }
        // return playerSide;
    }

    public string GetPlayerSide1()
    {
        return playerSide1;
    }




    public void EndTurn()
    {
        //Debug.Log(playerSide);
        // if(moveCount==0){
        // for(int i = 0; i < buttonList.Length; i++){
        //     theColor1.normalColor = new Color(0,204,204);
        //     theColor1.highlightedColor = new Color(128,255,255);
        //     theColor1.selectedColor = new Color(51,102,102);
        //     theColor1.disabledColor = new Color(55,66,77);
        //     buttonList[i].GetComponentInParent<Button>().colors = theColor1;
        //     }

        // }
        Win();

        moveCount++;
        if (moveCount <= 6)
        {
            if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
            {
                GameOver(playerSide);
            }
            for (int i = 0; i < buttonList.Length; i++)
            {
                if (buttonList[i].text != "")
                {
                    buttonList[i].GetComponentInParent<Button>().interactable = false;
                }
            }

            // if(moveCount==9){
            //     restartButton.SetActive(true);
            // }

            ChangeSides();
        }

        if (moveCount >= 6)
        {
            //Debug.Log("Draw!");
            if (moveCount == 6)
            {
                Win();
                if (flag == 1)
                {
                    SetBoardInteractable(false);
                }
                else
                {
                    for (int i = 0; i < buttonList.Length; i++)
                    {
                        if (buttonList[i].text != "O")
                        {
                            buttonList[i].GetComponentInParent<Button>().interactable = true;
                        }
                        else
                        {
                            Color textColor = buttonList[i].color;
                            textColor.a = 0.3f;
                            buttonList[i].color = textColor;
                        }
                    }
                }

            }

            for (int i = 0; i < buttonList.Length; i++)
            {

                if (buttonList[i].text == "")
                {
                    buttonList[i].text = " ";
                    //buttonList[i].color="white";
                    // theColor.disabledColor = Color.white;
                    // buttonList[0].GetComponentInParent<Button>().colors = theColor;
                    print("Cliked");
                    //     if(i==0){
                    //     //  buttonList[i].GetComponentInParent<Button>().interactable = true;
                    //     //  SameSides();
                    //     // }
                    //     // else{
                    //     //  buttonList[i].GetComponentInParent<Button>().interactable = false;
                    //     // }

                }
                // if(buttonList[i].GetComponentInParent<Button>().colors.normalColor==new Color(255,0,0)){
                //     b=a;
                //     a=i;
                //     Debug.Log("b:"+b+",a:"+a);
                // }    

                if (buttonList[i].GetComponentInParent<Button>().colors.selectedColor == Color.black)
                {
                    Debug.Log(i);
                    b = a;
                    a = i;
                    Debug.Log("b:" + b + ",a:" + a);
                    if (buttonList[i].text != " ")
                    {
                        if (i == 0)
                        {
                            if (buttonList[1].text != " " && buttonList[3].text != " " && buttonList[4].text != " ")
                            {
                                Debug.Log("Filled");
                            }
                            if (buttonList[1].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[1].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[1].GetComponentInParent<Button>().colors = theColor1;
                                //buttonList[1].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[3].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[3].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[3].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[4].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                            }
                        }
                        if (i == 1)
                        {
                            if (buttonList[0].text != " " && buttonList[2].text != " " && buttonList[4].text != " ")
                            {
                                Debug.Log("Filled");
                            }
                            if (buttonList[0].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[0].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[0].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[2].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[2].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[2].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[4].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                            }
                        }
                        if (i == 2)
                        {
                            if (buttonList[1].text != " " && buttonList[5].text != " " && buttonList[4].text != " ")
                            {
                                Debug.Log("Filled");
                            }
                            if (buttonList[1].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[1].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[1].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[5].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[5].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[5].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[4].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                            }
                        }
                        if (i == 3)
                        {
                            if (buttonList[0].text != " " && buttonList[6].text != " " && buttonList[4].text != " ")
                            {
                                Debug.Log("Filled");
                            }
                            if (buttonList[0].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[0].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[0].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[6].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[6].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[6].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[4].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                            }
                        }
                        if (i == 4)
                        {
                            if (buttonList[1].text != " " && buttonList[3].text != " " && buttonList[5].text != " " && buttonList[7].text != " ")
                            {
                                Debug.Log("Filled");
                            }
                            if (buttonList[1].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[1].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[1].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[3].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[3].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[3].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[5].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[5].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[5].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[7].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[7].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[7].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[0].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[0].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[0].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[2].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[2].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[2].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[6].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[6].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[6].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[8].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[8].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[8].GetComponentInParent<Button>().colors = theColor1;
                            }




                        }
                        if (i == 5)
                        {
                            if (buttonList[2].text != " " && buttonList[8].text != " " && buttonList[4].text != " ")
                            {
                                Debug.Log("Filled");
                            }
                            if (buttonList[2].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[2].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[2].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[8].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[8].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[8].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[4].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                            }
                        }
                        if (i == 6)
                        {
                            if (buttonList[3].text != " " && buttonList[7].text != " " && buttonList[4].text != " ")
                            {
                                Debug.Log("Filled");
                            }
                            if (buttonList[3].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[3].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[3].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[7].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[7].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[7].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[4].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                            }
                        }
                        if (i == 7)
                        {
                            if (buttonList[6].text != " " && buttonList[8].text != " " && buttonList[4].text != " ")
                            {
                                Debug.Log("Filled");
                            }
                            if (buttonList[6].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[6].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[6].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[8].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[8].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[8].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[4].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                            }
                        }
                        if (i == 8)
                        {
                            if (buttonList[5].text != " " && buttonList[7].text != " " && buttonList[4].text != " ")
                            {
                                Debug.Log("Filled");
                            }
                            if (buttonList[5].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[5].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[5].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[7].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[7].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[7].GetComponentInParent<Button>().colors = theColor1;
                            }
                            if (buttonList[4].text == " ")
                            {
                                theColor1.normalColor = new Color(255, 0, 0);
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                                Color normalColor = theColor1.normalColor;
                                normalColor.a = 0.4f;
                                theColor1.normalColor = normalColor;
                                buttonList[4].GetComponentInParent<Button>().colors = theColor1;
                            }
                        }
                    }
                }
            }
            if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
            {
                GameOver(playerSide);
            }
            if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
            {
                GameOver(playerSide);
            }
            //     for(int i = 0; i < buttonList.Length; i++){
            //         if(buttonList[i].text != " "){
            //             buttonList[i].GetComponentInParent<Button>().interactable = true;
            //     }
            // }

            //AdjustBoardInteractibility();
            //SameSides();
            Debug.Log(playerSide);
            Debug.Log(moveCount);
        }


        //Debug.Log(playerSide);

    }


    public void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    //void SameSides()
    /* {
         for (int i = 0; i < buttonList.Length; i++)
         {
             if (buttonList[i].text == "X")
             {
                 playerSide1 = "X";
                 //Debug.Log("X:"+i);
             }
             if (buttonList[i].text == "O")
             {
                 playerSide1 = "O";
                 //Debug.Log("O:"+i);
             }
         }

     }*/

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);
        if (winningPlayer == "Draw!")
        {
            SetGameOverText("It's a Draw!");
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }
        restartButton.SetActive(true);
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        flag = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(true);
        SetBoardInteractable(true);

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
            Color textColor = buttonList[i].color;
            textColor.a = 1f;
            buttonList[i].color = textColor;
        }

    }



    public void AdjustBoardInteractibility()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            Debug.Log(buttonList[i].text + "   " + playerSide);
            if (buttonList[i].text == "X")
            {
                buttonList[i].GetComponentInParent<Button>().interactable = true;
            }
            if (buttonList[i].text == " ")
            {
                buttonList[i].GetComponentInParent<Button>().interactable = true;
            }
            else
            {
                buttonList[i].GetComponentInParent<Button>().interactable = false;
            }
        }

    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
    public void RevertColor1()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            if (buttonList[i].GetComponentInParent<Button>().colors.normalColor.a == 0.4f)
            {
                theColor1.normalColor = new Color(255, 0, 0);
                buttonList[i].GetComponentInParent<Button>().colors = theColor1;
                Color normalColor = theColor1.normalColor;
                normalColor.a = 0f;
                theColor1.normalColor = normalColor;
                buttonList[i].GetComponentInParent<Button>().colors = theColor1;
            }
            if (buttonList[i].GetComponentInParent<Button>().colors.normalColor == new Color(0, 191, 191, 0))
            {
                theColor1.normalColor = new Color(0, 204, 204, 0);
                buttonList[i].GetComponentInParent<Button>().colors = theColor1;
                Color normalColor = theColor1.normalColor;
                normalColor.a = 0f;
                theColor1.normalColor = normalColor;
                buttonList[i].GetComponentInParent<Button>().colors = theColor1;
            }


        }
    }

    public void ChangeState()
    {
        Debug.Log(buttonList[0].GetComponentInParent<Button>().colors.normalColor);
        Debug.Log(buttonList[0].GetComponentInParent<Button>().colors.highlightedColor);
        Debug.Log(buttonList[0].GetComponentInParent<Button>().colors.pressedColor);
        Debug.Log(buttonList[0].GetComponentInParent<Button>().colors.selectedColor);
        Debug.Log(buttonList[0].GetComponentInParent<Button>().colors.disabledColor);
    }
    public void ShiftButtonText()
    {
        buttonList[a].text = buttonList[b].text;
        buttonList[b].text = " ";
        //ChangeSides();
        Debug.Log(buttonList[a].text);
        // for(int i = 0; i < buttonList.Length; i++){
        //         if(buttonList[i].text == buttonList[a].text){
        //             buttonList[i].GetComponentInParent<Button>().interactable = false;
        //         }
        // }
        //Constraint();

    }

    public void Constraint()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            if (buttonList[i].text != buttonList[a].text && buttonList[i].text != " ")
            {
                buttonList[i].GetComponentInParent<Button>().interactable = false;
            }
        }
    }

    public void Call()
    {
        if (b <= 8)
        {
            Debug.Log(a + ", " + b);
            if (buttonList[b].text == " " && buttonList[a].text != " ")
            {
                ChangeSides();
            }
            GetPlayer();
            // for(int i=0;i<3;i++){

            //     Debug.Log(myList[i]);
            // }

        }
    }

    public void GetPlayer()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            if (buttonList[i].text != playerSide && buttonList[i].text != " ")
            {
                buttonList[i].GetComponentInParent<Button>().interactable = false;
                // myList.Add(i);
            }
        }


    }
    public void Win()
    {
        if (buttonList[0].text == "X" && buttonList[1].text == "X" && buttonList[2].text == "X")
        {
            GameOver("X");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[3].text == "X" && buttonList[4].text == "X" && buttonList[5].text == "X")
        {
            GameOver("X");
            SetBoardInteractable(false);
            flag = 1;

        }
        if (buttonList[6].text == "X" && buttonList[7].text == "X" && buttonList[8].text == "X")
        {
            GameOver("X");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[0].text == "X" && buttonList[3].text == "X" && buttonList[6].text == "X")
        {
            GameOver("X");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[1].text == "X" && buttonList[4].text == "X" && buttonList[7].text == "X")
        {
            GameOver("X");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[2].text == "X" && buttonList[5].text == "X" && buttonList[8].text == "X")
        {
            GameOver("X");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[0].text == "X" && buttonList[4].text == "X" && buttonList[8].text == "X")
        {
            GameOver("X");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[2].text == "X" && buttonList[4].text == "X" && buttonList[6].text == "X")
        {
            GameOver("X");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[0].text == "O" && buttonList[1].text == "O" && buttonList[2].text == "O")
        {
            GameOver("O");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[3].text == "O" && buttonList[4].text == "O" && buttonList[5].text == "O")
        {
            GameOver("O");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[6].text == "O" && buttonList[7].text == "O" && buttonList[8].text == "O")
        {
            GameOver("O");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[0].text == "O" && buttonList[3].text == "O" && buttonList[6].text == "O")
        {
            GameOver("O");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[1].text == "O" && buttonList[4].text == "O" && buttonList[7].text == "O")
        {
            GameOver("O");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[2].text == "O" && buttonList[5].text == "O" && buttonList[8].text == "O")
        {
            GameOver("O");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[0].text == "O" && buttonList[4].text == "O" && buttonList[8].text == "O")
        {
            GameOver("O");
            SetBoardInteractable(false);
            flag = 1;
        }
        if (buttonList[2].text == "O" && buttonList[4].text == "O" && buttonList[6].text == "O")
        {
            GameOver("O");
            SetBoardInteractable(false);
            flag = 1;
        }


    }
}







