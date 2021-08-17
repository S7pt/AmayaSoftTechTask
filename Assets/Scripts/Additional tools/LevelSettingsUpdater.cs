using UnityEngine;
using UnityEngine.Events;

public class LevelSettingsUpdater : MonoBehaviour
{
    [SerializeField] private int _easyLevels;
    [SerializeField] private int _mediumLevels;
    [SerializeField] private int _hardLevels;
    [SerializeField] private int _slotAmountPerLevel;
    [SerializeField] private UnityEvent _onGameFinished;
    
    private int _currentLevelCount = 1;
    private int _levelsCount;
    private int _hardLevelThreshold;
    private int _currentDifficulty;

    private void Awake()
    {
        _levelsCount = _easyLevels + _mediumLevels + _hardLevels;
        _hardLevelThreshold = _mediumLevels + _easyLevels;
    }
    
    //Returns the amount of slots for this level, which is depending on current difficulty
    public int CheckForCurrentSlotAmount()
    {
        if (_currentLevelCount > _easyLevels && _currentLevelCount <= _hardLevelThreshold)
        {
            _currentDifficulty = (int)Difficulty.Medium * _slotAmountPerLevel;
        }
        else if (_currentLevelCount > _hardLevelThreshold)
        {
            _currentDifficulty = (int)Difficulty.Hard * _slotAmountPerLevel;
        }
        else
        {
            _currentDifficulty = (int)Difficulty.Easy * _slotAmountPerLevel;
        }
        if (_currentLevelCount >= _levelsCount)
        {
            _onGameFinished.Invoke();
        }
        else
        {
            _currentLevelCount++;
        }

        return _currentDifficulty;
    }
}

