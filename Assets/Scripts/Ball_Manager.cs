using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Manager : MonoBehaviour
{
    [SerializeField] private Ball_Settings _ballController;


    public Rigidbody2D _ballRb2D;

    public bool _ballGoRight = true;
    public bool _isBoing = false;


    void Start()
    {
        _ballRb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        BallControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            if (_ballGoRight)
            {
                _ballGoRight = false;
                _isBoing = false;
            }
            else
            {
                _ballGoRight = true;
                _isBoing = false;
            }
        }
    }


    private void BallControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if (!_isBoing)
            //{
                if (_ballGoRight)
                {
                    Jump(Vector2.right);
                    _isBoing = true;
                }
                else
                {
                    Jump(Vector2.left);
                    _isBoing = true;
                }
           //}
        }
    }

    // Ball's jump direction
    private void Jump(Vector2 direction)
    {
        _ballRb2D.AddForce(Vector2.up * _ballController._jumpPowerVertical * Time.deltaTime);
        _ballRb2D.AddForce(direction * _ballController._jumpPowerHorizontal * Time.deltaTime);
    }

}