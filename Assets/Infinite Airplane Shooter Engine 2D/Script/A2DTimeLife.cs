using UnityEngine;

public class A2DTimeLife : MonoBehaviour {

	public float Time = 2;

	void Start () {
		Destroy (gameObject, Time);
	}
	
	void Update () {
	
	}
}
