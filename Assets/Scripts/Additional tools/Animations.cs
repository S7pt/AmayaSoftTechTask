using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Animations
{
    private static void Bounce(Transform _object, float startingValue, float maximumValue, float endValue,float growDuration,
        float shrinkDuration)
    {
        Sequence _bounceSequence = DOTween.Sequence();
        _bounceSequence.Append(_object.DOScale(startingValue, 0f));
        _bounceSequence.Append(_object.DOScale(maximumValue, growDuration));
        _bounceSequence.Append(_object.DOScale(endValue, shrinkDuration));
    }

    public static void EaseInBounceInCell(Transform _object)
    {
        Sequence _easeInBounceSequence = DOTween.Sequence();
        _easeInBounceSequence.Append(_object.DOLocalMoveY(4, 0.1f));
        _easeInBounceSequence.Append(_object.DOLocalMoveY(-4, 0.1f));
        _easeInBounceSequence.Append(_object.DOLocalMoveY(9, 0.1f));
        _easeInBounceSequence.Append(_object.DOLocalMoveY(-9, 0.1f));
        _easeInBounceSequence.Append(_object.DOLocalMoveY(13, 0.1f));
        _easeInBounceSequence.Append(_object.DOLocalMoveY(0, 0.1f));
    }

    public static void BounceAsASlot(Transform _object, float growDuration, float shrinkDuration)
    {
        Bounce(_object, 0, 1.2f, 1, growDuration, shrinkDuration);
    }

    public static void BounceAsASprite(Transform _object, float growDuration, float shrinkDuration)
    {
        Bounce(_object, 1,1.2f,1, growDuration, shrinkDuration);
    }

    //I couldn't find the way to avoid code reusage, so that was the only way
    public static void FadeIn(Image image, float duration)
    {
        Sequence fadeInSequence = DOTween.Sequence();
        fadeInSequence.Append(image.DOFade(0, 0));
        fadeInSequence.Append(image.DOFade(1, duration));
    }
    public static void FadeIn(Text text, float duration)
    {
        Sequence fadeInSequence = DOTween.Sequence();
        fadeInSequence.Append(text.DOFade(0, 0));
        fadeInSequence.Append(text.DOFade(1, duration));
    }
    public static void FadeIn(SpriteRenderer sprite, float duration)
    {
        Sequence fadeInSequence = DOTween.Sequence();
        fadeInSequence.Append(sprite.DOFade(0, 0));
        fadeInSequence.Append(sprite.DOFade(1, duration));
    }
}