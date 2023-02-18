using UnityEngine;

public class A2DItemLife : MonoBehaviour {

	// Use this for initialization
	public int Life = 1;

	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.tag == "Player") 
		{
			A2DGameManager.gamemanager.AddLife(Life);
			Instantiate (A2DGameManager.gamemanager.VFX_More1Life, transform.position, transform.rotation);
			A2DSoundManager.Sm.SoundItemsCollect();
			Destroy (gameObject);
		}


	}
}
