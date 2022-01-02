using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collision_Controller : MonoBehaviour
{
    [SerializeField] private Ball_Manager _ball;

    private void Start()
    {
        _ball = FindObjectOfType<Ball_Manager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (_ball._ballGoRight)
            {
                _ball._ballGoRight = false;
            }
            else
            {
                _ball._ballGoRight = true;
            }
        }

        else if(collision.gameObject.tag == "Thorn")
        {
            //Game End States

            //Test
            Time.timeScale = 0f;
            //Test End
        }
    }
}
