using UnityEngine;

public class A2DItemsDestroyer : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.gameObject);
	}

}
