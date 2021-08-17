using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Animations
{
    private static void Bounce(Transform _object, float startingValue, float maximumValue, float endValue,float growDuration,
        float shrinkDuration)
    {
        Sequence bounceSequence = DOTween.Sequence();
        bounceSequence.Append(_object.DOScale(startingValue, 0f));
        bounceSequence.Append(_object.DOScale(maximumValue, growDuration));
        bounceSequence.Append(_object.DOScale(endValue, shrinkDuration));
    }

    public static void EaseInBounceInCell(Transform _object)
    {
        Sequence easeInBounceSequence = DOTween.Sequence();
        easeInBounceSequence.Append(_object.DOLocalMoveY(4, 0.1f));
        easeInBounceSequence.Append(_object.DOLocalMoveY(-4, 0.1f));
        easeInBounceSequence.Append(_object.DOLocalMoveY(9, 0.1f));
        easeInBounceSequence.Append(_object.DOLocalMoveY(-9, 0.1f));
        easeInBounceSequence.Append(_object.DOLocalMoveY(13, 0.1f));
        easeInBounceSequence.Append(_object.DOLocalMoveY(0, 0.1f));
    }

    public static void BounceAsASlot(Transform slot, float growDuration, float shrinkDuration)
    {
        Bounce(slot, 0, 1.2f, 1, growDuration, shrinkDuration);
    }

    public static void BounceAsASprite(Transform cell, float growDuration, float shrinkDuration)
    {
        Bounce(cell, 1,1.2f,1, growDuration, shrinkDuration);
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