using UnityEngine;
public class A2DShot_MoveWeapon3 : MonoBehaviour {

	public float Speed = 6f;
	public float SizeCollider = 0.3f;

	void Update()
	{
		transform.position += new Vector3 ( 0,Speed* Time.deltaTime );
		transform.localScale += new Vector3 (Speed * Time.deltaTime, Speed * Time.deltaTime);
		GetComponent<BoxCollider2D> ().size += new Vector2 (SizeCollider* Time.deltaTime,0.0001f);
	
	}
}
