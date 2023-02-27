using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BrennanHatton.UnityTools
{

	public class RestartGame : MonoBehaviour
	{
		public void ReloadLevel(){
			SceneManager.LoadScene(0);
		}
	 
		public void LoadLevel(int id){
			//	SceneManager.LoadScene(id);
			StartCoroutine(WaitLoadLevel(id));
		}
		
		IEnumerator WaitLoadLevel(int x)
		{
			yield return new WaitForSeconds(2);
			SceneManager.LoadScene(x);
		}
		
		
		public void LoadLevelByName(string id){
			//	SceneManager.LoadScene(id);
			StartCoroutine(WaitLoadLevelByName(id));
		}
		
		IEnumerator WaitLoadLevelByName(string x)
		{
			yield return new WaitForSeconds(2);
			SceneManager.LoadScene(x);
		}
	}

}