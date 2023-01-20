using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLIne : MonoBehaviour
{
    [SerializeField]
    private int _horseCount = 3;

    private string[] _rank;
    private int _counting = 0;

    void Start()
    {
        _rank = new string[_horseCount];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < _rank.Length; i++)
        {
            if (_rank[i] == null)
            {
                _rank[i] = collision.gameObject.name;
                _counting++;
                break;
            }
        }

        if (_counting == _horseCount)
        {
            foreach (var rank in _rank)
            {
                Debug.Log(rank.ToString());
            }
        }
    }
}
