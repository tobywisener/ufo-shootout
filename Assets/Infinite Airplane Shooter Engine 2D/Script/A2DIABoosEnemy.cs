using UnityEngine;

[System.Serializable]
public class A2DLimit
{
	public float xMin = -2f, xMax = 2f;

}

public class A2DIABoosEnemy : MonoBehaviour {

	public int Life  = 10; 
	public A2DLimit limits;
	private Rigidbody2D Gravity;
	public Transform ShotOrigin;
	public Transform ShotOrigin2;
	public Transform ShotOrigin3;
	public float ShotDelay = 1.3f;
	public float ShotDelay2 = 4.3f;
	public float ShotDelay3 = 4.3f;
	private float ShootingRange ;
	private float ShootingRange2 ;
	private float ShootingRange3 ;
	public int Score = 5;
	public float Speed = -2f;

	// Use this for initialization
	void Start () {
		A2DGameManager.gamemanager.Boos = true;
		A2DSoundManager.Sm.SoundEnemyINI();
		Gravity = GetComponent<Rigidbody2D> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.tag == "Player") 
		{
			A2DGameManager.gamemanager.ResLife();
			A2DSoundManager.Sm.ExplosionEnemy();
			Instantiate (A2DGameManager.gamemanager.VFX_Less1Life, transform.position, transform.rotation);	

		}
		if (other.tag == "Shot") 
		{
			Life--;
			A2DSoundManager.Sm.ShotEnemy();
			Instantiate (A2DGameManager.gamemanager.VFX_NoneShot, transform.position, transform.rotation);	
			if (Life <= 0) {
				A2DSoundManager.Sm.ExplosionEnemy();
				Instantiate (A2DGameManager.gamemanager.VFX_ExplosionPlayer, transform.position, transform.rotation);
				A2DGameManager.gamemanager.AddScore(Score);
				Instantiate (A2DGameManager.gamemanager.VFX_5Coin, transform.position, transform.rotation);
				Instantiate (A2DGameManager.gamemanager.Info_NewLevel, new Vector3(0,0,0), transform.rotation);
				Instantiate (A2DGameManager.gamemanager.ItemWeapon1, new Vector3(-2f,2.5f,0f), transform.rotation);
				Instantiate (A2DGameManager.gamemanager.ItemLife, new Vector3(-1f,2.5f,0f), transform.rotation);
				Instantiate (A2DGameManager.gamemanager.ItemWeapon2, new Vector3(0f,2.5f,0f), transform.rotation);
				Instantiate (A2DGameManager.gamemanager.ItemWeapon3, new Vector3(1.5f,2.5f,0f), transform.rotation);
				A2DGeneratorItems.GI.NewLevel();
				A2DGameManager.gamemanager.Boos = false;
				A2DGeneratorItems.GI.ReunaudarNPC();
				A2DSoundManager.Sm.SoundEnemyEND();
				Destroy (gameObject);
				Destroy (other.gameObject);
			}


		}
		if (other.tag == "Shot3") 
		{
			Life--;
			A2DSoundManager.Sm.ShotEnemy();
			Instantiate (A2DGameManager.gamemanager.VFX_NoneShot, transform.position, transform.rotation);	
			if (Life <= 0) {
				A2DSoundManager.Sm.ExplosionEnemy();
				Instantiate (A2DGameManager.gamemanager.VFX_ExplosionPlayer, transform.position, transform.rotation);
				A2DGameManager.gamemanager.AddScore(Score);
				Instantiate (A2DGameManager.gamemanager.VFX_5Coin, transform.position, transform.rotation);
				A2DSoundManager.Sm.SoundEnemyEND();
				Destroy (gameObject);

				A2DGameManager.gamemanager.Boos = false;
				A2DGeneratorItems.GI.ReunaudarNPC();
			}


		}

		if (other.tag == "Shield") 
		{
			A2DSoundManager.Sm.ExplosionEnemy();
			Instantiate (A2DGameManager.gamemanager.VFX_ExplosionPlayer, transform.position, transform.rotation);
			A2DGameManager.gamemanager.AddScore(Score);
			Instantiate (A2DGameManager.gamemanager.VFX_5Coin, transform.position, transform.rotation);
			A2DSoundManager.Sm.SoundEnemyEND();
			Destroy (gameObject);

			A2DGameManager.gamemanager.Boos = false;
			A2DGeneratorItems.GI.ReunaudarNPC();
		}


	}

	void Update()
	{
		if (Time.time > ShootingRange) {
			ShootingRange = Time.time + ShotDelay;
			Instantiate (A2DGameManager.gamemanager.VFX_ShotBoos, ShotOrigin.position, ShotOrigin.rotation);
			A2DSoundManager.Sm.LaserEnemy();

		}
		if (Time.time > ShootingRange2) {
			ShootingRange2 = Time.time + ShotDelay2;
			Instantiate (A2DGameManager.gamemanager.VFX_ShotBoos, ShotOrigin2.position, ShotOrigin2.rotation);
			A2DSoundManager.Sm.LaserEnemy();

		}
		if (Time.time > ShootingRange3) {
			ShootingRange3 = Time.time + ShotDelay3;
			Instantiate (A2DGameManager.gamemanager.VFX_ShotBoos, ShotOrigin3.position, ShotOrigin3.rotation);
			A2DSoundManager.Sm.LaserEnemy();

		}

	}
}
