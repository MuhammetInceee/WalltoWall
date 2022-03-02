using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHolder : MonoBehaviour
{
    [SerializeField] private HighScoreHolderSettings _highScoreHolderSettings;
    [SerializeField] private Ball_Manager _ball_Manager;

    private void Update()
    {
        if(_ball_Manager.score >= _highScoreHolderSettings.HIGHSCORE && AbstractGameStates.isOver)
        {
            _highScoreHolderSettings.HIGHSCORE = _ball_Manager.score;
        }
    }
}
