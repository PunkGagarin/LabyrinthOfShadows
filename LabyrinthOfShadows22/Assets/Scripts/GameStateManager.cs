using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnPaused;

    private bool isGamePaused = false;

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f;
            OnGameUnPaused?.Invoke(this, EventArgs.Empty);
        }
    }
}