using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadLevel : MonoBehaviour
{
   private string _baseLevelSceneName = "BaseLevelScene";
   [SerializeField] private string _levelSceneName;
   [SerializeField] private Image _fader;

	private bool _isFaded = false;

	private static string _currentlyLoadedScene;

   public void Load(bool loadBaseScene=true){
	   //_fader.DOFade(1f, 1.5f).OnComplete(CompletedFade);
	   //Load scenes async
	   //when finished loading, unload this scene
	   _currentlyLoadedScene = _levelSceneName;
	   //StartCoroutine(LoadScene(loadBaseScene));
	   SceneManager.LoadScene(_currentlyLoadedScene, LoadSceneMode.Single);
	   if(loadBaseScene){
		   SceneManager.LoadScene(_baseLevelSceneName, LoadSceneMode.Additive);
	   }
	   
   }

	private IEnumerator LoadScene(bool loadBaseScene){
		AsyncOperation baseLoadOp = null;
		if(loadBaseScene){
			baseLoadOp = SceneManager.LoadSceneAsync(_baseLevelSceneName, LoadSceneMode.Additive);
		}
		AsyncOperation levelLoadOp = SceneManager.LoadSceneAsync(_currentlyLoadedScene, LoadSceneMode.Single);

		/*if(loadBaseScene){
			baseLoadOp = SceneManager.LoadSceneAsync(_baseLevelSceneName, LoadSceneMode.Single);
		}
		AsyncOperation levelLoadOp = SceneManager.LoadSceneAsync(_currentlyLoadedScene, loadBaseScene ? LoadSceneMode.Additive : LoadSceneMode.Single);*/
		

		while(!levelLoadOp.isDone && (baseLoadOp != null ? !baseLoadOp.isDone : false)){
			yield return null;

			/*if(_isFaded){
				print("Faded");
				SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
			}*/
		}
   }

   public void Reload(){
	   //StartCoroutine(LoadScene(true));
	   SceneManager.LoadScene(_currentlyLoadedScene, LoadSceneMode.Single);
		SceneManager.LoadScene(_baseLevelSceneName, LoadSceneMode.Additive);

   }

   private void CompletedFade(){
	   _isFaded = true;
   }
}
