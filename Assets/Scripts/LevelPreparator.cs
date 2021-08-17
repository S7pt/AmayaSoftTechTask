using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelPreparator : MonoBehaviour
{
    [SerializeField]
    private CardBundle[] _dataSets;
    [SerializeField]
    private UnityEvent<CardData[],int,int> _onBundleAndCardChosen;
    [SerializeField] 
    private UnityEvent<CardData> _onCorrectCardSelected;
    [SerializeField] 
    private LevelSettingsUpdater _updater;
    
    private CardData[] _currentBundle;
    private HashSet<CardData> _correctCardsArchive;
    private Image[] _slots;

    private void Start()
    {
        _correctCardsArchive = new HashSet<CardData>();
        SendAllSettings();
    }
    
    //Randomly chooses one card from bundles and archives it using hashset so it won't be chosen again
    private int ChooseCorrectCard()
    {
        int numberOfCards = _currentBundle.Length;
        CardData correctCard=new CardData();
        bool isDone = false;
        int indexOfCorrectCard=0;
        while (!isDone)
        {
            indexOfCorrectCard = Random.Range(0, numberOfCards);
            correctCard = _currentBundle[indexOfCorrectCard];
            if (!_correctCardsArchive.Contains(correctCard))
            {
                _correctCardsArchive.Add(correctCard);
                isDone = true;
            }
        }
        _onCorrectCardSelected.Invoke(correctCard);
        return indexOfCorrectCard;
    }
    //Chooses random bundle to choose card from
    private void ChooseBundle()
    {
        _currentBundle = _dataSets[Random.Range(0, _dataSets.Length)].Cards;
    }
    
    //Gathers all data from above methods to send it to the next stage
    public void SendAllSettings()
    {
        ChooseBundle();
        _onBundleAndCardChosen.Invoke(_currentBundle, ChooseCorrectCard(), _updater.CheckForCurrentSlotAmount());
    }
}
