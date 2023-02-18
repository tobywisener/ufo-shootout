using UnityEngine;
public class A2DItemShield : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.tag == "Player") 
		{
			A2DGameManager.gamemanager.AddShield();
			A2DSoundManager.Sm.SoundItemsCollect();
			Destroy (gameObject);
		}


	}
}
