using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {  get; private set; }

    private int Lives=3;
    private int score;

    private void Awake()
    {
        Instance = this;
    }

    

    public void AddScore(int score)
    {
        this.score += score;
    }

    public int GetScore()
    {
        return score;
    }
    
}
