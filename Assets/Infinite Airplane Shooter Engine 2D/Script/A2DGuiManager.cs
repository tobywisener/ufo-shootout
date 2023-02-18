using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class A2DGuiManager : MonoBehaviour {

	public GameObject Game;
	public GameObject GameGUI;
	public GameObject PauseGUI;
	public GameObject GameOverGUI;
	public GameObject MainMenu;
	public GameObject ShopGui;
	public Text MainTextScore;
	public Text GameOverMAXScore;
	public Text GameOverScore;
	private string NameSceneLoad;
	public GameObject LoadingGui;
	public Scrollbar ScrollLoad;
	public static A2DGuiManager Gui;
	// Use this for initialization
	void Start () {
		Gui = this;
		Game.SetActive(false);
		GameGUI.SetActive(false);
		PauseGUI.SetActive(false);
		GameOverGUI.SetActive(false);
		MainMenu.SetActive(true);
		ShopGui.SetActive(false);
		LoadingGui.SetActive(false);
		NameSceneLoad = A2DGameManager.gamemanager.NameSceneLoad;
		MainTextScore.text = PlayerPrefs.GetInt ("Score_Player").ToString ();
	}

	public void PlayGame()
	{
		A2DSoundManager.Sm.SoundButton();
		A2DGameManager.gamemanager.StartGame ();
		Game.SetActive (true);
		GameGUI.SetActive (true);
		GameOverGUI.SetActive (false);
		PauseGUI.SetActive (false);
		MainMenu.SetActive (false);
		ShopGui.SetActive (false);
	}

	public void GameOver()
	{
		GameOverMAXScore.text = PlayerPrefs.GetInt ("Score_Player").ToString ();
		GameOverScore.text = A2DGameManager.gamemanager.CoinCollect.ToString ();
		GameGUI.SetActive (false);
		GameOverGUI.SetActive (true);
		PauseGUI.SetActive (false);
		MainMenu.SetActive (false);
		ShopGui.SetActive (false);
	}

	public void AddActivateArm1()
	{
		A2DSoundManager.Sm.SoundButton();
		A2DGameManager.gamemanager.WeaponSelect(1);
		
	}

	public void AddActivateArm2()
	{
		A2DSoundManager.Sm.SoundButton();
		A2DGameManager.gamemanager.WeaponSelect(2);
	}

	public void AddActivateArm3()
	{
		A2DSoundManager.Sm.SoundButton();
		A2DGameManager.gamemanager.WeaponSelect(3);
	}
	public void PauseGame()
	{
		A2DSoundManager.Sm.SoundButton();
		A2DGameManager.gamemanager.PauseGame = true;
		GameGUI.SetActive (true);
		GameOverGUI.SetActive (false);
		PauseGUI.SetActive (true);
		MainMenu.SetActive (false);
		ShopGui.SetActive (false);
	}

	public void ContinueGame()
	{
		A2DSoundManager.Sm.SoundButton();
		A2DGameManager.gamemanager.PauseGame = false;
		GameGUI.SetActive (true);
		GameOverGUI.SetActive (false);
		PauseGUI.SetActive (false);
		MainMenu.SetActive (false);
		ShopGui.SetActive (false);

	}

	public void ShopManager()
	{
		A2DSoundManager.Sm.SoundButton();
		GameGUI.SetActive (false);
		GameOverGUI.SetActive (false);
		PauseGUI.SetActive (false);
		ShopGui.SetActive (true);
		MainMenu.SetActive (true);
	}

	public void CloseShopManager()
	{
		A2DSoundManager.Sm.SoundButton();
		GameGUI.SetActive (false);
		GameOverGUI.SetActive (false);
		PauseGUI.SetActive (false);
		ShopGui.SetActive (false);
		MainMenu.SetActive (true);
	}

	public void RetryGame()
	{
		LoadingGui.SetActive (true);
		A2DSoundManager.Sm.SoundButton();
		A2DGameManager.gamemanager.PauseGame = true;
		StartCoroutine (AsynchronousLoad(NameSceneLoad));
	}

	IEnumerator AsynchronousLoad (string GamePlanes)
	{
		yield return null;

		AsyncOperation ao = SceneManager.LoadSceneAsync (GamePlanes);

		while (!ao.isDone) 
		{
			// [0, 0.9] > [0,1]
			float progress = Mathf.Clamp01(ao.progress/0.9f);
			ScrollLoad.size = (progress * 100);
			Debug.Log("Loading Progress: " + (progress*100)+"%");

			//Loading Complete
			if (ao.progress == 0.9f) {
				if (Input.GetButton ("Jump")) 
					ao.allowSceneActivation = true;
					yield return null;	
				
			}

		}

	}


}

