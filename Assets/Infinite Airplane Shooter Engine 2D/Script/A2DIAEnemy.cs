using UnityEngine;
public class A2DIAEnemy : MonoBehaviour {

	public Transform ShotOrigin;
	public float ShotDelay = 0.4f;
	private float ShootingRange ;
	public int Score = 1;

	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.tag == "Player") 
		{
			Instantiate (A2DGameManager.gamemanager.VFX_ExplosionPlayer,  other.transform.position,  other.transform.rotation);
			A2DGameManager.gamemanager.ResLife();
			Instantiate (A2DGameManager.gamemanager.VFX_Less1Life, transform.position, transform.rotation);
			A2DSoundManager.Sm.ExplosionEnemy();
			Destroy (gameObject);
		}
		if (other.tag == "Shot") 
		{
			Instantiate (A2DGameManager.gamemanager.VFX_ExplosionPlayer, transform.position, transform.rotation);
			A2DGameManager.gamemanager.AddScore(Score);
			Instantiate (A2DGameManager.gamemanager.VFX_2Coin, transform.position, transform.rotation);
			A2DSoundManager.Sm.ExplosionEnemy();
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
		if (other.tag == "Shot3") 
		{
			Instantiate (A2DGameManager.gamemanager.VFX_ExplosionPlayer, transform.position, transform.rotation);
			A2DGameManager.gamemanager.AddScore(Score);
			Instantiate (A2DGameManager.gamemanager.VFX_2Coin, transform.position, transform.rotation);
			A2DSoundManager.Sm.ExplosionEnemy();
			Destroy (gameObject);
		}

		if (other.tag == "Shield") 
		{
			Instantiate (A2DGameManager.gamemanager.VFX_ExplosionPlayer, transform.position, transform.rotation);
			A2DGameManager.gamemanager.AddScore(Score);
			Instantiate (A2DGameManager.gamemanager.VFX_2Coin, transform.position, transform.rotation);
			A2DSoundManager.Sm.ExplosionEnemy();
			Destroy (gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.time > ShootingRange) {
			ShootingRange = Time.time + ShotDelay;
			Instantiate (A2DGameManager.gamemanager.VFX_ShotEnemies, ShotOrigin.position, ShotOrigin.rotation);
			A2DSoundManager.Sm.LaserEnemy();
		}
	}
}
