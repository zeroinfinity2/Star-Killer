using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    [SerializeField]
    private int _scorePerHit;

    private int _score = 0;

    private Text _scoreText;

    

    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        _scoreText.text = _score.ToString();
    }

    public void ScoreHit()
    {
        _score += _scorePerHit;
    }
}
