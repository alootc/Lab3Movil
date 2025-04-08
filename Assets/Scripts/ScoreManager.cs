using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score Data", menuName = "ScriptableObjects/Score Data", order = 3)]
public class ScoreManager : ScriptableObject
{
    public int score;

    public List<int> scores;

    public int GetScore()
    {
        int last_score = score;
        scores.Add(score);
        score = 0;
        return last_score;
    }
}
