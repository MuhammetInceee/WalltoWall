using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Manager : MonoBehaviour
{
    [SerializeField] private Ball_Settings _ballController;
    [SerializeField] private Text _scoreText;


    public bool _ballGoRight = true;
    public int score;

    public GameObject _tapToStart;
    public Rigidbody2D _ballRb2D;

    private float _ballBoundary = 5.4f;
    private bool _isStart = false;


    void Start()
    {
        _ballRb2D = this.gameObject.GetComponent<Rigidbody2D>();

        FirstTouch();
    }

    void Update()
    {
        if (_isStart)
        {
            BallControl();
            BallBoundries();
        }

        TapToStart();

        _scoreText.text = "" + score;
    }



    private void BallControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_ballGoRight)
            {
                Jump(Vector2.right);
            }
            else
            {
                Jump(Vector2.left);
            }
        }
    }

    // Ball's jump direction
    private void Jump(Vector2 direction)
    {
        _ballRb2D.velocity = new Vector2(0, 1) * _ballController._jumpPowerVertical * Time.deltaTime;
        _ballRb2D.AddForce(direction * _ballController._jumpPowerHorizontal * Time.deltaTime);
    }

    void BallBoundries()
    {
        if (this.gameObject.transform.position.y < -_ballBoundary)
        {
            //Game End Blocks
            AbstractGameStates.SetGameState(AbstractGameStates.GameState.GameOver, _ballRb2D);
            //Falls message on the end screen
        }
        else if (this.gameObject.transform.position.y > _ballBoundary)
        {
            //Game End Blocks
            AbstractGameStates.SetGameState(AbstractGameStates.GameState.GameOver, _ballRb2D);
            //Topside goes message on end screen
        }
    }

    public void FirstTouch()
    {
        Thorn_Spawn_Manager.Instance.ThornSpawnRightSide();
    }


    private void TapToStart()
    {

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        var tempColor = spriteRenderer.color;

        if (_tapToStart.activeInHierarchy)
        {
            Time.timeScale = 0;
            tempColor.a = 0f;

            if (Input.GetMouseButtonDown(0))
            {
                tempColor.a = 1f;
                _tapToStart.SetActive(false);
                gameObject.SetActive(true);
                Time.timeScale = 1;
                _isStart = true;
            }

            spriteRenderer.color = tempColor;
        }
    }
}
