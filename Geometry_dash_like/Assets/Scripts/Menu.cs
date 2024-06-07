using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject scoreBoard;
    private int _baseLevelIndex = 1;
    private ScrollAnimation _scrollAnimation;


    public void Start()
    {
        _scrollAnimation = GetComponent<ScrollAnimation>();
    }

    public void PlayGame(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ScrollLevelsToTheRight()
    {
        if (_baseLevelIndex == 2 || _scrollAnimation.IsAnimating) return;
        _scrollAnimation.ScrollTheRight();
        _baseLevelIndex++;
    }

    public void ScrollLevelsToTheLeft()
    {
        if (_baseLevelIndex == 1 || _scrollAnimation.IsAnimating) return;
        _scrollAnimation.ScrollToTheLeft();
        _baseLevelIndex--;
    }

    public void DisplayScoreBoard()
    {
        scoreBoard.SetActive(true);
    }

    public void CloseScoreBoard()
    {
        scoreBoard.SetActive(false);
    }
}