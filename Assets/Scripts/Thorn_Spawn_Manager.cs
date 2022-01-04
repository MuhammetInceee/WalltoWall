using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn_Spawn_Manager : MonoBehaviour
{
    public static Thorn_Spawn_Manager Instance;



    [SerializeField] private List<GameObject> _rightSideThorn = new List<GameObject>();
    [SerializeField] private List<GameObject> _leftSideThorn = new List<GameObject>();


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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
        int thornCount = Random.Range(1, 6);

        for(; thornCount > 0; thornCount--)
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
        int thornCount = Random.Range(1, 6);

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
}
