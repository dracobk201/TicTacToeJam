﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActions : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField] private BoolReference GamePaused;
    [SerializeField] private StringReference SceneToChange;
    [SerializeField] private GameEvent ChangeSceneEvent;

    private bool lastTimeGamePaused;

    private void Start()
    {
        TriggerPause(false);
    }

    private void Update()
    {
        if (GamePaused.Value == lastTimeGamePaused)
            return;

        lastTimeGamePaused = GamePaused.Value;
    }

    public void TriggerPause()
    {
        GamePaused.Value = !GamePaused.Value;
        Time.timeScale = (GamePaused.Value) ? 0 : 1;
    }

    public void TriggerPause(bool isPaused)
    {
        GamePaused.Value = isPaused;
        Time.timeScale = (GamePaused.Value) ? 0 : 1;
    }

    public void ResumeButtonPressed()
    {
        TriggerPause();
    }

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
}
