using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    //private Grid grid;



    private GameController gameController;



    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }

    public void SetSpace()
    {

        if (gameController.moveCount < 6)
        {
            buttonText.text = gameController.GetPlayerSide();
            //button.interactable = false;


            gameController.EndTurn();
        }
        else
        {
            gameController.ChangeState();

            if (button.colors.normalColor.a == 0.4f)
            {
                Debug.Log("yellow");
                //gameController.ChangeSides();
                button = GetComponent<Button>();
                gameController.theColor = GetComponent<Button>().colors;
                gameController.theColor.selectedColor = Color.black;
                button.colors = gameController.theColor;
                //gameController.ChangeSides();
                gameController.EndTurn();
                gameController.ShiftButtonText();
                GetText();
                gameController.RevertColor1();
                gameController.Win();
                //gameController.Call();

                RevertColor();
                gameController.myList.Clear();

            }

            else
            {
                //gameController.GetPlayer();
                gameController.RevertColor1();
                button = GetComponent<Button>();
                gameController.theColor = GetComponent<Button>().colors;
                gameController.theColor.selectedColor = Color.black;
                button.colors = gameController.theColor;
                gameController.EndTurn();
                //gameController.Constraint();
                //gameController.AdjustBoardInteractibility();

                RevertColor();


            }
            //gameController.RevertColor1();

        }
    }

    public void RevertColor()
    {
        button = GetComponent<Button>();
        gameController.theColor = GetComponent<Button>().colors;
        gameController.theColor.selectedColor = new Color(245, 245, 245, 0);
        button.colors = gameController.theColor;

    }

    public void GetText()
    {
        for (int i = 0; i < gameController.buttonList.Length; i++)
        {
            if (gameController.buttonList[i].text == buttonText.text)
            {
                gameController.buttonList[i].GetComponentInParent<Button>().interactable = false;
                Color textColor = gameController.buttonList[i].color;
                textColor.a = 0.3f;
                gameController.buttonList[i].color = textColor;

            }
            else
            {
                gameController.buttonList[i].GetComponentInParent<Button>().interactable = true;
                Color textColor = gameController.buttonList[i].color;
                textColor.a = 1f;
                gameController.buttonList[i].color = textColor;

            }
        }

    }




}
