using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn_Spawn_Manager : MonoBehaviour
{
    [SerializeField] private GameObject _thornPrefab;

    void Start()
    {
        for (int i = 2; i > 0; i--)
        {
            ThornInstantiater(false);
            ThornInstantiater(true);
        }
    }

    void Update()
    {

    }

    /// <summary>
    /// If is true Instantiate right side of screen or if is false Instante left side of the screen.
    /// </summary>
    /// <param name="isRight">If is true Instantiate right side of screen or if is false Instante left side of the screen.</param>
    void ThornInstantiater(bool isRight)
    {
        float randomRangeLeftY = Random.Range(-4.3f, 4.3f);
        float randomRangeRightY = Random.Range(-4.3f, 4.3f);

        Vector2 InstantiateVectorLeft = new Vector2(_thornPrefab.transform.position.x, randomRangeLeftY);
        Vector2 InstantiateVectorRight = new Vector2(-_thornPrefab.transform.position.x, randomRangeRightY);


        if (!isRight)
            Instantiate(_thornPrefab, InstantiateVectorLeft, Quaternion.Euler(0,0,-90));
        else
            Instantiate(_thornPrefab, InstantiateVectorRight, Quaternion.Euler(0, 0, 90));
    }
}
