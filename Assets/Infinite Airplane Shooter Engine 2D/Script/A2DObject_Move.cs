using UnityEngine;

public class A2DObject_Move : MonoBehaviour
{
	public float Speed;


	void Update()
	{
		transform.position += new Vector3 ( 0,Speed* Time.deltaTime );

	}
}
