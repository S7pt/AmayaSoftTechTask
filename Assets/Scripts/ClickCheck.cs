using UnityEngine;

public class ClickCheck : MonoBehaviour
{
    private GameObserver _observer;
    private CardManager _relatedCard;

    private void Start()
    {
        _observer = FindObjectOfType<GameObserver>();
    }

    public CardManager Symbol
    {
        set => _relatedCard = value;
    }

    private void OnMouseDown()
    {
        _observer.ValidateAnswer(_relatedCard);
    }
}
