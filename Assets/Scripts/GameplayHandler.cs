using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHandler : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField]
    private Slot[] slots;
    [SerializeField]
    private GameObject[] boards;
    [SerializeField]
    private Transform boardParent;
    [SerializeField]
    private IntReference ActivePlayer;
    [SerializeField]
    private IntReference PlayerOneTotalWins;
    [SerializeField]
    private IntReference PlayerTwoTotalWins;
    [SerializeField]
    private IntReference TotalTies;
    [SerializeField]
    private GameEvent PlayerOneWin;
    [SerializeField]
    private GameEvent PlayerTwoWin;
    [SerializeField]
    private GameEvent TieGame;
    [SerializeField]
    private FloatReference TimeOfTheGame;

    private bool[,] boardXSituation;
    private bool[,] boardOSituation;
    private bool[,] boardTieSituation;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        InitializeBoardSituations();
        InstantiateBoard();
        RestartSlots();
        ActivePlayer.Value = 1;
    }

    private void RestartSlots()
    {
        foreach (Slot item in slots)
        {
            item.state = SlotState.Null;
        }
    }

    private void InstantiateBoard()
    {
        GameObject board = GameObject.FindGameObjectWithTag(Global.BoardTag);
        if (!board.Equals(null))
            Destroy(board);

        int index = UnityEngine.Random.Range(0, boards.Length - 1);
        board = Instantiate(boards[index], boardParent);
    }

    private void InitializeBoardSituations()
    {
        boardXSituation = new bool[3, 3] { { false, false, false}, { false, false, false }, { false, false, false } };
        boardOSituation = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };
        boardTieSituation = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };
    } 

    public void CheckBoard()
    {
        
        foreach (Slot item in slots)
        {
            if (!item.state.Equals(SlotState.Null))
            {
                if (item.state.Equals(SlotState.X))
                    boardXSituation[item.XPosition.Value, item.YPosition.Value] = true;
                else
                    boardOSituation[item.XPosition.Value, item.YPosition.Value] = true;
                boardTieSituation[item.XPosition.Value, item.YPosition.Value] = true;
            }
        }
        if (CheckSolutions(boardXSituation))
        {
            ActivePlayer.Value = 0;
            PlayerOneTotalWins.Value++;
            PlayerOneWin.Raise();
            return;
        }
        else if (CheckSolutions(boardOSituation))
        {
            ActivePlayer.Value = 0;
            PlayerTwoTotalWins.Value++;
            PlayerTwoWin.Raise();
            return;
        }
        else
        {
            bool isTieGame = false;
            foreach (bool i in boardTieSituation)
            {
                if (i)
                    isTieGame = true;
                else
                {
                    isTieGame = false;
                    break;
                }
            }

            if (isTieGame)
            {
                ActivePlayer.Value = 0;
                TotalTies.Value++;
                TieGame.Raise();
                return;
            }
        }
    }

    private bool CheckSolutions(bool[,] array)
    {
        bool value = false;
        if (array[0, 0] && array[1, 0] && array[2, 0])
            value = true;
        else if (array[0, 0] && array[0, 1] && array[0, 2])
            value = true;
        else if (array[0, 0] && array[1, 1] && array[2, 2])
            value = true;
        else if (array[1, 0] && array[1, 1] && array[1, 2])
            value = true;
        else if (array[2, 0] && array[1, 1] && array[0, 2])
            value = true;
        else if (array[0, 1] && array[1, 1] && array[2, 1])
            value = true;
        else if (array[0, 2] && array[1, 2] && array[2, 2])
            value = true;
        else if (array[2, 0] && array[2, 1] && array[2, 2])
            value = true;
        return value;
    }
}
