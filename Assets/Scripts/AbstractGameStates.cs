using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGameStates
{
    public enum GameState
    {
        PlayTime,
        GameOver,
        GamePaused
    };

    static GameState currentState;


    public static void SetGameState(GameState newState, Rigidbody2D rb2D)
    {
        if (currentState == newState)
            return;

        currentState = newState;

        switch (currentState)
        {
            case GameState.PlayTime:
                rb2D.constraints = RigidbodyConstraints2D.None;
                rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                break;

            case GameState.GamePaused:
                rb2D.constraints = RigidbodyConstraints2D.FreezePosition;
                break;

            case GameState.GameOver:
                rb2D.constraints = RigidbodyConstraints2D.FreezePosition;
                break;
        }
    }
}
