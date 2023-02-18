using UnityEngine;

public class A2DScroll : MonoBehaviour {

	public bool IniciarEnMovimiento = false;
	public float velocidad = 0f;
	private float tiempoInicio = 0f;

	public static A2DScroll SC;
	void Start () {
		SC = this;
		if (IniciarEnMovimiento) {
			PlayerRum();
		}
	}

	public void PlayerRum(){
		tiempoInicio = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(!A2DGameManager.gamemanager.PauseGame)
		{
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, ((Time.time - tiempoInicio) * velocidad) % 1);
		}
	}
}
