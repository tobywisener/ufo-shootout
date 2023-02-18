using UnityEngine;
public class A2DGeneratorItems : MonoBehaviour {

	public GameObject[] Items;
	public GameObject[] NPC;
	public float TimeMinItems = 1f;
	public float TimeMaxItems = 9f;
	public float TimeMinNPC = 1f;
	public float TimeMaxNPC = 9f;

	public static A2DGeneratorItems GI;
	// Use this for initialization
	void Start () {
		GI = this;

	}

	public void StartGame()
	{
		Invoke("GenerarNPC", Random.Range(TimeMinNPC, TimeMaxNPC));
		Invoke("GenerarItems", Random.Range(TimeMinItems, TimeMaxItems));
	}


    public void NewLevel()
	{
		if (TimeMinNPC > 1) 
		{
			TimeMinNPC -= 0.5f;	
		}
		if (TimeMaxNPC > 3) 
		{
			TimeMaxNPC -= 1f;	
		}
	}

	public void ReunaudarNPC()
	{
		Invoke("GenerarNPC", Random.Range(TimeMinNPC, TimeMaxNPC));

	}


	// Update is called once per frame
	void GenerarItems () {
		if(!A2DGameManager.gamemanager.PauseGame)
		{
			Instantiate (Items [Random.Range (0, Items.Length)], transform.position, Quaternion.identity);
			Invoke ("GenerarItems", Random.Range(TimeMinItems,TimeMaxItems));
		}
	}

	void GenerarNPC()
	{
		if (!A2DGameManager.gamemanager.PauseGame && !A2DGameManager.gamemanager.Boos)
		{
			Instantiate(NPC[Random.Range(0, NPC.Length)], transform.position, Quaternion.identity);
			Invoke("GenerarNPC", Random.Range(TimeMinNPC, TimeMaxNPC));
		}
	}

}
