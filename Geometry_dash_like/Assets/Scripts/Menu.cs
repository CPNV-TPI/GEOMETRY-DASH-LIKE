using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int _levelIndex = 1;
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
        if (_levelIndex == 2 || _scrollAnimation.IsAnimating) return;
        _scrollAnimation.ScrollTheRight();
        _levelIndex++;
    }

    public void ScrollToTheLeft()
    {
        if (_levelIndex == 1 || _scrollAnimation.IsAnimating) return;
        _scrollAnimation.ScrollLevelsToTheLeft();
        _levelIndex--;
    }
}