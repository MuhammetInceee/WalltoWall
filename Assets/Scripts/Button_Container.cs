using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Container : MonoBehaviour
{

    [SerializeField] private GameObject _ball;

    public void RestartButton()
    {
        _ball.transform.position = new Vector2(0, -1.89f);
        _ball.GetComponent<Ball_Manager>()._ballRb2D.velocity = new Vector2(0, 0);
        _ball.GetComponent<Ball_Manager>().score = 0;
        _ball.GetComponent<Ball_Manager>()._ballGoRight = true;
        _ball.GetComponent<Ball_Manager>().FirstTouch();
        Thorn_Spawn_Manager.Instance.AllThornsDeactivated();
    }
}
