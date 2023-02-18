using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class A2DLimits
{
	public float xMin = -2.25f, xMax = 2.25f, yMin = -1.7f, yMax = 2.3f;

}

[System.Serializable]
public class A2DGameManager : MonoBehaviour {

	public static A2DGameManager gamemanager;


	public string NameSceneLoad;
	[HideInInspector]
	public int CoinCollect = 0;
	[HideInInspector]
	public int MaxCoinCollect = 0;

	public int NumLife = 3;
	public Sprite[] PlayerSprite;
	public int PlayerSpriteSelect = 0;
	public A2DLimits limits;
	public float SpeedPlayer = 7f; 
	public float ShotDelay = 1f;
	public float ShotDelay2 = 1f;
	public float ShotDelay3 = 1f;

	public int LimitAmmoWeapon1 = 99;
	public int AmmoWeapon1 = 20;
	public int LimitAmmoWeapon2 = 99;
	public int AmmoWeapon2 = 10;
	public int LimitAmmoWeapon3 = 5;
	public int AmmoWeapon3 = 0;
	public int WeaponActive = 1;



	public int DurationShield = 400;
	[HideInInspector]
	public bool ShieldActive = false;

	public Text TextWeapon1;
	public Text TextWeapon2;
	public Text TextWeapon3;
	public Text TextCoin;
	public Text TextLife;

	public GameObject InfoWeaponActive1;
	public GameObject InfoWeaponActive2;
	public GameObject InfoWeaponActive3;
	public GameObject InfoShield;

	public GameObject VFX_Less1Life;
	public GameObject VFX_More1Life;
	public GameObject VFX_1Coin;
	public GameObject VFX_2Coin;
	public GameObject VFX_5Coin;
	public GameObject VFX_NoneShot;
	public GameObject VFX_ExplosionEnemies;
	public GameObject VFX_ExplosionPlayer;
	public GameObject VFX_MoreWeapon1;
	public GameObject VFX_MoreWeapon2;
	public GameObject VFX_MoreWeapon3;
	public GameObject VFX_ShotWeapon1;
	public GameObject VFX_ShotWeapon2;
	public GameObject VFX_ShotWeapon3;
	public GameObject VFX_ShotBoos;
	public GameObject VFX_ShotEnemies;
	public GameObject Info_NewLevel;
	public GameObject Info_Empty;
	public GameObject Info_Start;
	public GameObject ItemCoin;
	public GameObject ItemLife;
	public GameObject ItemShield;
	public GameObject ItemWeapon1;
	public GameObject ItemWeapon2;
	public GameObject ItemWeapon3;
	public bool PauseGame = false;
	public bool Boos = false;


	// Use this for initialization
	void Start () {
		
		MaxCoinCollect = PlayerPrefs.GetInt ("Score_Player");
		PlayerPrefs.Save ();
		gamemanager = this;

	}

	public void ActivarBoos()
	{
		Boos = true;
	}

	public void DesactivarBoss()
	{

		Boos = false;
	}

	public void ChangueSpritePlayer(int data)
	{
		PlayerSpriteSelect = data;
	}

	public void StartGame()
	{
		Instantiate (A2DGameManager.gamemanager.Info_Start, new Vector3(0,0,0), transform.rotation);
		A2DGeneratorItems.GI.StartGame();
		PauseGame = false;
		UpdateTextCoin ();
		UpdateTextLife ();
		UpdateTextWeaponSelect1 ();
		UpdateTextWeaponSelect2 ();
		UpdateTextWeaponSelect3 ();
		UpdateInfoWeapon ();
	}

	public void WeaponSelect(int data)
	{
		WeaponActive = data;
		UpdateInfoWeapon ();

	}

	public void AddShield()
	{
		ShieldActive = true;
		DurationShield = 400;
	}

	void UpdateInfoWeapon()
	{
		switch (WeaponActive) {
		case 1:
			InfoWeaponActive1.SetActive (true);
			InfoWeaponActive2.SetActive (false);
			InfoWeaponActive3.SetActive (false);
			break;
		case 2:
			InfoWeaponActive1.SetActive (false);
			InfoWeaponActive2.SetActive (true);
			InfoWeaponActive3.SetActive (false);
			break;
		case 3:
			InfoWeaponActive1.SetActive (false);
			InfoWeaponActive2.SetActive (false);
			InfoWeaponActive3.SetActive (true);
			break;

		}
	}
	public void ADDWeaponSelect1( int Cant)
	{
		if (AmmoWeapon1 < LimitAmmoWeapon1) 
		{
			AmmoWeapon1 += Cant;
			UpdateTextWeaponSelect1 ();
		}

	}
	public void ADDWeaponSelect2( int Cant)
	{
		if (AmmoWeapon2 < LimitAmmoWeapon2) 
		{
			AmmoWeapon2 += Cant;
			UpdateTextWeaponSelect2 ();
		}
	}
	public void ADDWeaponSelect3( int Cant)
	{
		if (AmmoWeapon3 < LimitAmmoWeapon3)
		{
			AmmoWeapon3 += Cant;
			UpdateTextWeaponSelect3 ();
		}
	}

	public void UpdateTextWeaponSelect1()
	{
		TextWeapon1.text = AmmoWeapon1.ToString ();
	}
	public void UpdateTextWeaponSelect2()
	{
		TextWeapon2.text = AmmoWeapon2.ToString ();
	}
	public void UpdateTextWeaponSelect3()
	{
		TextWeapon3.text = AmmoWeapon3.ToString ();
	}

	void UpdateTextCoin()
	{
		TextCoin.text = CoinCollect.ToString (); ;
	}

	void UpdateTextLife()
	{
		TextLife.text = NumLife.ToString ();
	}


	public void AddLife (int notificacion)
	{
		NumLife += notificacion;
		UpdateTextLife();
	}

	public void ResLife()
	{
		A2DSoundManager.Sm.ShotEnemy();
		NumLife--;
		UpdateTextLife ();
		if (NumLife <= 0) 
		{
			EndGame ();
		}

	}

	public void AddScore (int notificacion)
	{
		CoinCollect += notificacion;
		UpdateTextCoin ();
	}

	void EndGame()
	{
		int NewCoin = PlayerPrefs.GetInt ("Score_Player") + CoinCollect;
		PlayerPrefs.SetInt ("Score_Player", NewCoin);
		PlayerPrefs.Save ();
		A2DGuiManager.Gui.GameOver();
		A2DPlayerController.PL.GameOver();
		PauseGame = true;
	}


	// Update is called once per frame
	void Update () {
	
		if (ShieldActive == true) {
			DurationShield--;
			InfoShield.SetActive (true);
			if (DurationShield <= 0) {
				ShieldActive = false;
			}
		} else {
			InfoShield.SetActive (false);
		}

	}
}
