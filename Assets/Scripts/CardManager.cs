using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField]private ParticleSystem _stars;
    
    private CardData _relatedCard;
    private ClickCheck _slot;

    public CardData RelatedCard
    {
        set => _relatedCard = value;
        get => _relatedCard;
    }

    public ParticleSystem Stars => _stars;
    

    private void Awake()
    {
        _slot = GetComponentInParent<ClickCheck>();
        _stars.Stop();
    }
    
    //Changes parent slot card data and updates card sprite
    public void ChangeSlotData()
    {
        _slot.Symbol = this;
        GetComponent<Image>().sprite = _relatedCard.DataSprite;
    }
    
}
