using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{

    private int score;
    [SerializeField] private int scorePerHit = 100;

    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void Scorehit()
    {
        score = score + scorePerHit;
    }
}
