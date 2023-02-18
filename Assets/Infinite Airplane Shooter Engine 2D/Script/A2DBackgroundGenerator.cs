using UnityEngine;

public class A2DBackgroundGenerator : MonoBehaviour {

	public GameObject[] Level;
	
	private int Levelint;


	void Start () {
		Levelint = (int)Random.Range(0, Level.Length);
		BG ();
	}


	void BG()
	{
		for (int i = 0; Level.Length > i; i++)
		{
			if (Levelint == i)
			{
				Level[i].SetActive(true);

			}
			else {
				Level[i].SetActive(false);
			
			}
		
		}
	}
}
