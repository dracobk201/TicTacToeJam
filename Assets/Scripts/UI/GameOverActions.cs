using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverActions : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField]
    private StringReference SceneToChange;
    [SerializeField]
    private GameEvent ChangeSceneEvent;
    [SerializeField]
    private StringReference PlayerOneSentence;
    [SerializeField]
    private StringReference PlayerTwoSentence;
    [SerializeField]
    private StringReference TieSentence;
    [SerializeField]
    private IntReference PlayerOneTotalWins;
    [SerializeField]
    private IntReference PlayerTwoTotalWins;

    [Header("Component Variables")]
    [SerializeField]
    private Text gameOverMesage;
    [SerializeField]
    private GameObject playerOneArrow;
    [SerializeField]
    private GameObject playerTwoArrow;

    public void RestartButtonPressed()
    {
        SceneToChange.Value = Global.FirstLevelScene;
        ChangeSceneEvent.Raise();
    }

    public void QuitButtonPressed()
    {
        SceneToChange.Value = Global.MainMenuScene;
        ChangeSceneEvent.Raise();
    }

    public void PlayerOneWin()
    {
        playerOneArrow.SetActive(true);
        playerTwoArrow.SetActive(false);
        gameOverMesage.text = PlayerOneSentence.Value;
    }

    public void PlayerTwoWin()
    {
        playerOneArrow.SetActive(false);
        playerTwoArrow.SetActive(true);
        gameOverMesage.text = PlayerTwoSentence.Value;
    }
    public void TieGame()
    {
        playerOneArrow.SetActive(false);
        playerTwoArrow.SetActive(false);
        gameOverMesage.text = TieSentence.Value;
    }
}
