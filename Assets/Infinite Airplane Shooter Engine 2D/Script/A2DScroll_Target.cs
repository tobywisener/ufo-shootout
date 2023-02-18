using UnityEngine;
public class A2DScroll_Target : MonoBehaviour {


	public float velocidad = 0f;
	private float tiempoInicio = 0f;

	void Update () {
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(((Time.time - tiempoInicio) * velocidad) % 1, 0);
	}
}
