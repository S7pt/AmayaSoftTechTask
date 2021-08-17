using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomCardsSelector : MonoBehaviour
{
    [SerializeField] private UnityEvent<CardData[], int, int, CardData[]> _onCardSetCreated;
    private CardBundle _currentDataSet;
    private HashSet<int> _alreadyUsedCards;

    //Randomly chooses cards from given bundle to generate set
    private CardData[] GetNewCardSet(CardData[] bundleToSelectFrom,int indexOfTheCorrectCard, int slotCount = 3)
    {
        if (indexOfTheCorrectCard >= bundleToSelectFrom.Length)
        {
            indexOfTheCorrectCard = bundleToSelectFrom.Length-1;
        }
        _alreadyUsedCards=new HashSet<int>();
        CardData[] cardSet = new CardData[slotCount];
        cardSet[Random.Range(0, slotCount - 1)] = bundleToSelectFrom[indexOfTheCorrectCard];
        _alreadyUsedCards.Add(indexOfTheCorrectCard);
        int i = 0;
        while(i < slotCount)
        {
            if (cardSet[i] != null)
            {
                i++;
            }
            else
            {
                int index = Random.Range(0, bundleToSelectFrom.Length);
                if (!_alreadyUsedCards.Contains(index))
                {
                    cardSet[i] = bundleToSelectFrom[index];
                    _alreadyUsedCards.Add(index);
                    i++;
                }
            }
        }
        
        return cardSet;
    }
    
    //Collects above generated set of cards from given bundle to pass it further
    public void CollectSetData(CardData[] bundleToSelectFrom,int indexOfTheCorrectCard, int slotCount = 3)
    {
        CardData[] currentSet = GetNewCardSet(bundleToSelectFrom, indexOfTheCorrectCard, slotCount);
        _onCardSetCreated.Invoke(bundleToSelectFrom, indexOfTheCorrectCard, slotCount, currentSet);
    }
    
}
