using UnityEngine;

public class A2DPlayerDestroy : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player") 
		{
			A2DGameManager.gamemanager.ResLife();
			Instantiate (A2DGameManager.gamemanager.VFX_NoneShot, transform.position, transform.rotation);	
			Instantiate (A2DGameManager.gamemanager.VFX_Less1Life, transform.position, transform.rotation);	
			Destroy (gameObject);
		}

		if (other.tag == "Shot") 
		{
			Instantiate (A2DGameManager.gamemanager.VFX_NoneShot, transform.position, transform.rotation);	
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
		if (other.tag == "Shot3") 
		{
			Instantiate (A2DGameManager.gamemanager.VFX_NoneShot, transform.position, transform.rotation);	
			Destroy (gameObject);
		}
		if (other.tag == "Shield") 
		{
			Instantiate (A2DGameManager.gamemanager.VFX_NoneShot, transform.position, transform.rotation);	
			Destroy (gameObject);
		}


	}
}
