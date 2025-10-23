using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _MenuPanel;
    [SerializeField] private GameObject _Doodle;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private float _currentScore = 0f;
    private float _highScore = 0f;

    // ⚡ Variable statique pour savoir si c'est un restart ou un vrai lancement
    public static bool IsRestart = false;

    private void Start()
    {
        // Si c'est un restart après mort → ne pas montrer le menu
        if (IsRestart)
        {
            _MenuPanel.SetActive(false);
            _Doodle.SetActive(true);
        }
        else
        {
            _MenuPanel.SetActive(true);
            _Doodle.SetActive(false);
        }

        _currentScore = 0f;
        _scoreText.text = "0";

        _highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        _highScoreText.text = _highScore.ToString("F0");
    }

    private void Update()
    {
        if (_Doodle.activeSelf)
        {
            if (_Doodle.transform.position.y > _currentScore)
            {
                _currentScore = _Doodle.transform.position.y;
                _scoreText.text = _currentScore.ToString("F0");

                if (_currentScore > _highScore)
                {
                    _highScore = _currentScore;
                    _highScoreText.text = _highScore.ToString("F0");

                    PlayerPrefs.SetFloat("HighScore", _highScore);
                    PlayerPrefs.Save();
                }
            }
        }
    }

    public void LaunchGame()
    {
        Debug.Log("LaunchGame called");
        IsRestart = true; // On indique qu'on a lancé une partie
        _MenuPanel.SetActive(false);
        _Doodle.SetActive(true);

        _currentScore = 0f;
        _scoreText.text = "0";
    }
}
