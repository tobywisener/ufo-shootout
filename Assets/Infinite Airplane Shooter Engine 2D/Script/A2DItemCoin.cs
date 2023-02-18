using UnityEngine;

public class A2DItemCoin : MonoBehaviour {

	public int Score = 1;

	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.tag == "Player") 
		{
			A2DGameManager.gamemanager.AddScore(Score);
			Instantiate (A2DGameManager.gamemanager.VFX_1Coin, transform.position, transform.rotation);
			A2DSoundManager.Sm.SoundItemsCollect();
			Destroy (gameObject);
		}


	}
}
