using UnityEngine;
public class A2DItemWeapon : MonoBehaviour {

	public int ItemWeaponSelect = 1; 
	public int CantWeaponSelect = 1;

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player") 
		{
			if (ItemWeaponSelect == 1)
			{
				Instantiate (A2DGameManager.gamemanager.VFX_MoreWeapon1, transform.position, transform.rotation);
				A2DGameManager.gamemanager.ADDWeaponSelect1(CantWeaponSelect);
				A2DSoundManager.Sm.SoundItemsCollect();
				Destroy (gameObject);
			}
			if (ItemWeaponSelect == 2)
			{
				Instantiate (A2DGameManager.gamemanager.VFX_MoreWeapon2, transform.position, transform.rotation);
				A2DGameManager.gamemanager.ADDWeaponSelect2(CantWeaponSelect);
				A2DSoundManager.Sm.SoundItemsCollect();
				Destroy (gameObject);
			}	

			if (ItemWeaponSelect == 3)
			{
				Instantiate (A2DGameManager.gamemanager.VFX_MoreWeapon3, transform.position, transform.rotation);
				A2DGameManager.gamemanager.ADDWeaponSelect3(CantWeaponSelect);
				A2DSoundManager.Sm.SoundItemsCollect();
				Destroy (gameObject);
			}
				
		}


	}
}
