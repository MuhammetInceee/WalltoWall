using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn_Spawn_Manager : MonoBehaviour
{
    public static Thorn_Spawn_Manager Instance;


    //public int thornCount = Random.Range(1, 7);
    public int thornCount;

    [SerializeField] private List<GameObject> _rightSideThorn = new List<GameObject>();
    [SerializeField] private List<GameObject> _leftSideThorn = new List<GameObject>();
    [SerializeField] private Ball_Manager _ballManager;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        _ballManager = FindObjectOfType<Ball_Manager>();
    }

    /// <summary>
    /// If is True right side thorns activated or if is false left side thorns activated
    /// </summary>
    /// <param name="isRightSide"></param>
    public void ThornInstantiater(bool isRightSide)
    {
        if (isRightSide)
        {
            int i = Random.Range(0, _rightSideThorn.Count);

            if (_rightSideThorn[i].activeInHierarchy)
                ThornInstantiater(true);
            else
                _rightSideThorn[i].SetActive(true);
        }
        else
        {
            int i = Random.Range(0, _leftSideThorn.Count);

            if (_leftSideThorn[i].activeInHierarchy)
                ThornInstantiater(false);
            else
                _leftSideThorn[i].SetActive(true);
        }
    }

    public void ThornSpawnRightSide()
    {
        RandomThornCountAlgorithm();

        for (; thornCount > 0; thornCount--)
        {
            ThornInstantiater(true);
        }

        foreach(GameObject elements in _leftSideThorn)
        {
            if (elements.activeInHierarchy)
            {
                elements.SetActive(false);
            }
        }
    }

    public void ThornSpawnLeftSide()
    {
        RandomThornCountAlgorithm();

        for (; thornCount > 0; thornCount--)
        {
            ThornInstantiater(false);
        }

        foreach (GameObject elements in _rightSideThorn)
        {
            if (elements.activeInHierarchy)
            {
                elements.SetActive(false);
            }
        }
    }

    private void RandomThornCountAlgorithm()
    {
        if (_ballManager.score < 5)
            thornCount = Random.Range(1, 3);

        else if (_ballManager.score >= 5 && _ballManager.score < 25)
            thornCount = Random.Range(2, 5);

        else if (_ballManager.score >= 25 && _ballManager.score < 50)
            thornCount = Random.Range(3, 6);

        else if (_ballManager.score >= 50 && _ballManager.score < 100)
            thornCount = Random.Range(4, 7);

        else if (_ballManager.score >= 100)
            thornCount = Random.Range(5, 9);

    }

    public void AllThornsDeactivated()
    {
        foreach(GameObject elements in _leftSideThorn)
        {
            if (elements.activeInHierarchy)
                elements.SetActive(false);
        }

        foreach (GameObject elements in _rightSideThorn)
        {
            if (elements.activeInHierarchy)
                elements.SetActive(false);
        }
    }
}
