using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    private int _player1Score = 0;
    private int _player2Score = 0;
    private int _gameWinScore = 10;
    private GameObject _ball;
    [SerializeField]
    private Text _p1Score, _p2Score;
    [SerializeField]
    private Text _gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        _ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            _player1Score++;
            _p1Score.text = _player1Score.ToString();
        }
        else
        {
            _player2Score++;
            _p2Score.text = _player2Score.ToString();
        }
        if (_player1Score < _gameWinScore && _player2Score < _gameWinScore)
        {
            _ball.gameObject.GetComponent<BallBehaviour>(
            ).Restart();
        }
        else
        {
            GameOver();
        }
    }
    public void RestartGame()
    {
        _player1Score = 0;
        _player2Score = 0;
        _p1Score.text = _player1Score.ToString();
        _p2Score.text = _player2Score.ToString();
        _ball.GetComponent<BallBehaviour>().Restart();
        _gameOverText.gameObject.SetActive(false);
    }
    public void GameOver()
    {
        if (_player1Score == _gameWinScore)
        {
            _gameOverText.text = "COMPUTER WINS";
        }
        else if (_player2Score == _gameWinScore)
        {
            _gameOverText.text = "PLAYER WINS";
        }
        _gameOverText.gameObject.SetActive(true);
        _ball.GetComponent<BallBehaviour>().ResetBall();
    }
}
