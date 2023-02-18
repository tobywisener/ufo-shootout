using UnityEngine;
using System.Collections;

public class A2DEnemiesDestroys : MonoBehaviour {

	public int Score = 1;

	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.tag == "Player") 
		{
			A2DGameManager.gamemanager.ResLife();
			A2DSoundManager.Sm.ExplosionAsteroid();
			Instantiate (A2DGameManager.gamemanager.VFX_NoneShot, transform.position, transform.rotation);	
			Instantiate (A2DGameManager.gamemanager.VFX_Less1Life, transform.position, transform.rotation);	
			Destroy (gameObject);
		}
		if (other.tag == "Shield") 
		{
			A2DSoundManager.Sm.ExplosionAsteroid();
			Instantiate (A2DGameManager.gamemanager.VFX_NoneShot, transform.position, transform.rotation);	
			Destroy (gameObject);
		}
		if (other.tag == "Shot") 
		{
			A2DSoundManager.Sm.ExplosionAsteroid();
			Instantiate (A2DGameManager.gamemanager.VFX_ExplosionEnemies, transform.position, transform.rotation);	
			Instantiate (A2DGameManager.gamemanager.VFX_1Coin, transform.position, transform.rotation);
			A2DGameManager.gamemanager.AddScore(Score);
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
		if (other.tag == "Shot3") 
		{
			A2DSoundManager.Sm.ExplosionAsteroid();
			Instantiate (A2DGameManager.gamemanager.VFX_ExplosionEnemies, transform.position, transform.rotation);	
			Instantiate (A2DGameManager.gamemanager.VFX_1Coin, transform.position, transform.rotation);
			A2DGameManager.gamemanager.AddScore(Score);
			Destroy (gameObject);
		}

	}
}
