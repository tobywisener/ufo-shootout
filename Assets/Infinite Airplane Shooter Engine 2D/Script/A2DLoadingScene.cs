using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class A2DLoadingScene : MonoBehaviour {


	public string nameScene;

	void Awake()
	{
		StartCoroutine (AsynchronousLoad(nameScene));
	}



	IEnumerator AsynchronousLoad (string GamePlanes)
	{
		yield return null;

		AsyncOperation ao = SceneManager.LoadSceneAsync (GamePlanes);

		while (!ao.isDone) 
		{
			// [0, 0.9] > [0,1]
			float progress = Mathf.Clamp01(ao.progress/0.9f);
			Debug.Log("Loading Progress: " + (progress*100)+"%");

			//Loading Complete
			if(ao.progress == 0.9f)
			{
				Debug.Log ("Prees SPACEBAR to start");
				if (Input.GetButton ("Jump")) 
					ao.allowSceneActivation = true;
				yield return null;	
			}

		}
			
	}


		
}
