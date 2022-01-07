using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collision_Controller : MonoBehaviour
{
    [SerializeField] private Ball_Manager _ball;
    [SerializeField] private Star_Respawner _star;

    [SerializeField] private ParticleSystem _executeEffect;



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
                Thorn_Spawn_Manager.Instance.ThornSpawnLeftSide();
            }
            else
            {
                _ball._ballGoRight = true;
                Thorn_Spawn_Manager.Instance.ThornSpawnRightSide();
            }

            if (!_star.gameObject.activeInHierarchy)
            {
                _star.StarRandomSpawner();
                _star.gameObject.SetActive(true);
            }
        }

        else if(collision.gameObject.tag == "Thorn")
        {
            //Game End States
            AbstractGameStates.SetGameState(AbstractGameStates.GameState.GameOver, _ball._ballRb2D);
            gameObject.SetActive(false);
            _executeEffect.transform.position = gameObject.transform.position;
            _executeEffect.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Star")
        {
            _ball.score++;
            _star.gameObject.SetActive(false);
        }
    }
}
