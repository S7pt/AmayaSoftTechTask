using System;
using UnityEngine;

[Serializable]
public class CardData
{
    [SerializeField]
    private string _identifier;
    [SerializeField]
    private Sprite _dataSprite;

    public string Identifier => _identifier;
    public Sprite DataSprite => _dataSprite;
    
}
