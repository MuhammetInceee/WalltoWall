using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Respawner : MonoBehaviour
{
    private float _randomVectorX;
    private float _randomVectorY;

    private Vector2 _randomPositionStar;

    private void Start()
    {
        StarRandomSpawner();
    }


    public void StarRandomSpawner()
    {

        _randomVectorX = Random.Range(-1, 1);
        _randomVectorY = Random.Range(-3, 3.5f);

        _randomPositionStar = new Vector2(_randomVectorX, _randomVectorY) - new Vector2(0, -1.89f);


        transform.position = _randomPositionStar;
    }
}
