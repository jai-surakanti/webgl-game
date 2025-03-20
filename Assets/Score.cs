using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    private int _score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        _score = 0;
        _currentScoreText.text = _score.ToString();
        _bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        UpdateHighScore();
    }

    void Update()
    {
        
    }

    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", _score);
            _bestScoreText.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }
}
