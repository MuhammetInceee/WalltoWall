using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Manager : MonoBehaviour
{
    [SerializeField] private Ball_Settings _ballController;


    public bool _ballGoRight = true;


    private Rigidbody2D _ballRb2D;
    private float _ballBoundary = 5.4f;


    void Start()
    {
        _ballRb2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        BallControl();
        BallBoundries();
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
            //Falls message on the end screen

            //Just Try
            Time.timeScale = 0f;
            //Try End
        }
        else if (this.gameObject.transform.position.y > _ballBoundary)
        {
            //Game End Blocks
            //Topside goes message on end screen

            //Just Try
            Time.timeScale = 0f;
            //Try End
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            if (_ballGoRight)
            {
                _ballGoRight = false;
            }
            else
            {
                _ballGoRight = true;
            }
        }
    }

}
