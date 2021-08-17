using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameObserver : MonoBehaviour
{
    [SerializeField] private UnityEvent _onPlayerGuessedCorrectly;
    private string _correctAnswer;
    
    //Sets the generated correct answer to validate later
    public void SetCorrectAnswer(CardData card)
    {
        _correctAnswer = card.Identifier;
    }
    
    //Compares the clicked on answer with stored correct answer and triggers corresponding scenarios
    public void ValidateAnswer(CardManager answer)
    {
        if (answer.RelatedCard.Identifier != _correctAnswer)
        {
            Animations.EaseInBounceInCell(answer.gameObject.transform);
        }
        else
        {
            StartCoroutine(CorrectAnswerAction(answer));
        }
    }
    
    //Plays correct choise animations and triggers winning event, thus recalculating the level again
    public IEnumerator CorrectAnswerAction(CardManager answer)
    {
        answer.Stars.Play();
        Animations.BounceAsASprite(answer.gameObject.transform,0.3f,0.5f);
        yield return new WaitForSeconds(0.7f);
        _onPlayerGuessedCorrectly.Invoke();
    }
}
