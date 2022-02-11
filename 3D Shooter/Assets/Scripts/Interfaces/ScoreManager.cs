using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private int scoreCount;
    [SerializeField] private Text scoreCountText;

    private void Start()
    {
        UpdateScoreCountUI();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public void AddScore()
    {
        scoreCount++;
        UpdateScoreCountUI();
    }


    private void UpdateScoreCountUI()
    {
        scoreCountText.text = "Score: " + scoreCount;
    }
}
