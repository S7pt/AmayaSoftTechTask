using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFinishActivator : MonoBehaviour
{
   [SerializeField] private GameObject _gameFinishCanvas;
   [SerializeField] private GameObject _levelCanvas;
   [SerializeField] private SpriteRenderer _loadingScreen;

   //Shows the game finished screen
   public void ActivateGameFinishScreen()
   {
      _levelCanvas.SetActive(false);
      _gameFinishCanvas.SetActive(true);
      Animations.FadeIn(_gameFinishCanvas.GetComponentInChildren<Image>(), 0.5f);
   }

   //Fakes the loading by darkening the screen and delaying scene reload using coroutine
   public void RestartGame()
   {
      Animations.FadeIn(_loadingScreen, 1);
      StartCoroutine(DelayedSceneReload(1));
   }

   //Exits the application
   public void ExitGame()
   {
      Application.Quit();
   }

   //Delayed scene reload
   private IEnumerator DelayedSceneReload(float seconds)
   {
      yield return new WaitForSeconds(seconds);
      SceneManager.LoadScene("AmayaSoftTask");
   }
}
