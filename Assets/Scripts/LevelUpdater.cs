using UnityEngine;
using UnityEngine.UI;

public class LevelUpdater : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private Text _taskText;

    private Image[] _slots;
    
    //Updates slots and task text to match the generated data
    public void UpdateLevel(CardData[] bundle, int correctCardIndex, int slotCount, CardData[] cards)
    {
        _taskText.text = "Find " + bundle[correctCardIndex].Identifier;
        Animations.FadeIn(_taskText,1);
        ClickCheck[] slots = GetComponentsInChildren<ClickCheck>();
        foreach (var slot in slots)
        {
            Destroy(slot.gameObject);
        }

        for (int i = 0; i < slotCount; i++)
        {
            GameObject slot = Instantiate(_slotPrefab,transform.parent);
            slot.gameObject.transform.SetParent(transform);
            slot.gameObject.transform.localScale=Vector3.one;
            CardManager card = slot.GetComponentInChildren<CardManager>();
            card.RelatedCard = cards[i];
            card.ChangeSlotData();
            Animations.BounceAsASlot(slot.transform,0.65f,0.1f);
        }
    }

}
