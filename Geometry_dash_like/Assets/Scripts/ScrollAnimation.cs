using System.Collections;
using UnityEngine;

public class ScrollAnimation : MonoBehaviour
{
    private const float LeftMove = 800f;
    private const float RightMove = -800f;

    [SerializeField] private Transform levelMenu;
    private RectTransform _rectTransform;
    public bool IsAnimating { get; private set; }

    private void Start()
    {
        _rectTransform = levelMenu.GetComponent<RectTransform>();
    }

    public void ScrollTheRight()
    {
        StartCoroutine(AnimateScroll(new Vector2(RightMove, 0), 0.5f));
    }

    public void ScrollToTheLeft()
    {
        StartCoroutine(AnimateScroll(new Vector2(LeftMove, 0), 0.5f));
    }

    private IEnumerator AnimateScroll(Vector2 moveVector, float duration)
    {
        IsAnimating = true;
        var startPosition = _rectTransform.anchoredPosition;
        var endPosition = startPosition + moveVector;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            var times = elapsedTime / duration;
            times = EaseOutSine(times);
            _rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, times);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _rectTransform.anchoredPosition = endPosition;
        IsAnimating = false;
    }

    private static float EaseOutSine(float times)
    {
        return times * (2 - times);
    }
}