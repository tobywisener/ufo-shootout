using UnityEngine;
using UnityEngine.UI;

public class A2DShopItemsManager : MonoBehaviour
{
    public Text TextPriceItem;
    public Text TextNameItem;
    public Text TextCoinAvailable;
	public Image Img;

    public int indexSelect;

	public A2DShopManager[] Items;

	public A2DButton btnBuy, btnSelect, btnExit, btnRight, btnLeft;

	[System.Serializable]
	public class A2DButton
	{
		public GameObject button;
	}

	[System.Serializable]
	public enum A2DTypeItem { Life, Ammo1, Ammo2, Ammo3, Player }

	[System.Serializable]
	public class A2DShopManager
	{
		public string Name_Item;

		public int PriceItem = 1000;
		public Sprite SpriteImg;
		public int SpriteIMG_NumPlayer = 0;
		public bool isUnLock = false;
		public A2DTypeItem Type;
	}
	private void Update()
	{
		TextNameItem.text = Items[indexSelect].Name_Item.ToString();
		TextPriceItem.text = Items[indexSelect].PriceItem.ToString();
		Img.sprite = Items[indexSelect].SpriteImg;

		TextCoinAvailable.text = PlayerPrefs.GetInt("Score_Player").ToString();

		if (!Items[indexSelect].isUnLock && Items[indexSelect].Type == A2DTypeItem.Player)
		{
			TextPriceItem.transform.gameObject.SetActive(true);
			btnBuy.button.SetActive(true);
			btnSelect.button.SetActive(false);

		}

		if (Items[indexSelect].isUnLock && Items[indexSelect].Type == A2DTypeItem.Player)
		{
			TextPriceItem.transform.gameObject.SetActive(false);
			btnBuy.button.SetActive(false);
			btnSelect.button.SetActive(true);
		}

		if (Items[indexSelect].Type == A2DTypeItem.Life || Items[indexSelect].Type == A2DTypeItem.Ammo1 || Items[indexSelect].Type == A2DTypeItem.Ammo2 || Items[indexSelect].Type == A2DTypeItem.Ammo3)
		{
			TextPriceItem.transform.gameObject.SetActive(true);
			btnBuy.button.SetActive(true);
			btnSelect.button.SetActive(false);
		}



	}

	public void LeftButton()
	{
		indexSelect--;
		if (indexSelect <= 0)
		{
			indexSelect = 0;
		}

		A2DSoundManager.Sm.SoundButton();

	}

	public void RightButton()
	{
		indexSelect++;
		if (indexSelect >= Items.Length - 1)
		{
			indexSelect = Items.Length - 1;
		}

		A2DSoundManager.Sm.SoundButton();

	}

	public void SelectButton()
	{
		A2DGameManager.gamemanager.ChangueSpritePlayer(Items[indexSelect].SpriteIMG_NumPlayer);
		A2DSoundManager.Sm.SoundButton();
	}


	public void BuyButton()
	{
		if (PlayerPrefs.GetInt("Score_Player") >= Items[indexSelect].PriceItem)
		{
			int RestCoin = (PlayerPrefs.GetInt("Score_Player") - Items[indexSelect].PriceItem);
			PlayerPrefs.SetInt("Score_Player", RestCoin);
			PlayerPrefs.Save();
			if (Items[indexSelect].Type == A2DTypeItem.Player)
			{
				A2DGameManager.gamemanager.ChangueSpritePlayer(Items[indexSelect].SpriteIMG_NumPlayer);
			}
			if (Items[indexSelect].Type == A2DTypeItem.Life)
			{
				A2DGameManager.gamemanager.AddLife(1);
			}
			if (Items[indexSelect].Type == A2DTypeItem.Ammo1)
			{
				A2DGameManager.gamemanager.ADDWeaponSelect1(5);
			}
			if (Items[indexSelect].Type == A2DTypeItem.Ammo2)
			{
				A2DGameManager.gamemanager.ADDWeaponSelect2(3);
			}
			if (Items[indexSelect].Type == A2DTypeItem.Ammo3)
			{
				A2DGameManager.gamemanager.ADDWeaponSelect3(1);
			}
			A2DSoundManager.Sm.SoundButton();
		}

	}


}
