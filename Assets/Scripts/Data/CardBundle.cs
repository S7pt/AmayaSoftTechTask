using UnityEngine;

[CreateAssetMenu(fileName = "New CardBundle", menuName = "Card Bundle", order = 100)]
public class CardBundle : ScriptableObject
{
    [SerializeField] 
    private CardData[] _cards;

    public CardData[] Cards => _cards;
}
