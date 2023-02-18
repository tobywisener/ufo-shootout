using UnityEngine;
public class A2DPlayerController : MonoBehaviour {

	private Rigidbody2D Gravity;
	public Transform ShotOrigin;
	public Transform ShotOrigin2;
	public Transform ShotOrigin3;

	private float ShootingRange = 0;
	private float ShootingRange2 = 0 ;
	private float ShootingRange3 = 0 ;

	public GameObject Shield;
	public Sprite[] SpriteShields;


	public static A2DPlayerController PL;


	private Vector3 _dragOffset;
	private Camera _cam;

	public GameObject empty;

	[SerializeField] private float _speed = 10;

	void Awake()
	{
		_cam = Camera.main;
	}

	void OnMouseDown()
	{
		_dragOffset = transform.position - GetMousePos();
	}

	void OnMouseDrag()
	{
		transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
		Fire();
	}

	Vector3 GetMousePos()
	{
		var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		return mousePos;
	}

	// Use this for initialization
	void Start () {
		PL = this;

		Gravity = GetComponent<Rigidbody2D> ();


	}

	
		

	void FixedUpdate()
	{
		float MoveHorizontal = Input.GetAxis ("Horizontal");
		float MoveVertical = Input.GetAxis ("Vertical");
		Vector3 movimiento = new Vector3 (MoveHorizontal,MoveVertical,0);
		Gravity.velocity = movimiento * A2DGameManager.gamemanager.SpeedPlayer;

		Gravity.position = new Vector3 
			(
				Mathf.Clamp(Gravity.position.x, A2DGameManager.gamemanager.limits.xMin, A2DGameManager.gamemanager.limits.xMax),
				Mathf.Clamp(Gravity.position.y, A2DGameManager.gamemanager.limits.yMin, A2DGameManager.gamemanager.limits.yMax),0
			);
				
	}

	void Update () {

		if (A2DGameManager.gamemanager.PauseGame)
		{
			GetComponent<BoxCollider2D>().enabled = false;
		}
		if (!A2DGameManager.gamemanager.PauseGame)
		{
			GetComponent<BoxCollider2D>().enabled = true;
		}

		if (A2DGameManager.gamemanager.ShieldActive == true) {
			Shield.SetActive (true);
			if(A2DGameManager.gamemanager.DurationShield >=100)
			{
				Shield.GetComponent<SpriteRenderer> ().sprite = SpriteShields [0];
			}
			if(A2DGameManager.gamemanager.DurationShield <=99)
			{
				Shield.GetComponent<SpriteRenderer> ().sprite = SpriteShields [1];
			}
		} else {
			Shield.SetActive (false);
		}


		if ((Input.GetButton ("Jump") && Time.time > ShootingRange))
		{

			switch (A2DGameManager.gamemanager.WeaponActive) {
			case 1:
				if (A2DGameManager.gamemanager.AmmoWeapon1 > 0) {
						A2DGameManager.gamemanager.AmmoWeapon1 -= 1;
						A2DGameManager.gamemanager.UpdateTextWeaponSelect1 ();
					ShootingRange = Time.time + A2DGameManager.gamemanager.ShotDelay;
					Instantiate (A2DGameManager.gamemanager.VFX_ShotWeapon1, ShotOrigin.position, ShotOrigin.rotation);
						A2DSoundManager.Sm.LaserPlayer();

				} else {
						if(empty == null)
                        {
							empty = Instantiate(A2DGameManager.gamemanager.Info_Empty, new Vector3(0, 0, 0), transform.rotation);
						}
				}
				break;
			case 2:
				if (A2DGameManager.gamemanager.AmmoWeapon2 > 0)
				{
						A2DGameManager.gamemanager.AmmoWeapon2 -= 1;
						A2DGameManager.gamemanager.UpdateTextWeaponSelect2 ();
					if (Time.time > ShootingRange) {
						ShootingRange = Time.time + A2DGameManager.gamemanager.ShotDelay;
						Instantiate (A2DGameManager.gamemanager.VFX_ShotWeapon2, ShotOrigin.position, ShotOrigin.rotation);
							A2DSoundManager.Sm.LaserPlayer();
						}
					if (Time.time > ShootingRange2) {
						ShootingRange2 = Time.time + A2DGameManager.gamemanager.ShotDelay2;
						Instantiate (A2DGameManager.gamemanager.VFX_ShotWeapon2, ShotOrigin2.position, ShotOrigin2.rotation);
							A2DSoundManager.Sm.LaserPlayer();
						}
					if (Time.time > ShootingRange3) {
						ShootingRange3 = Time.time + A2DGameManager.gamemanager.ShotDelay3;
						Instantiate (A2DGameManager.gamemanager.VFX_ShotWeapon2, ShotOrigin3.position, ShotOrigin3.rotation);
							A2DSoundManager.Sm.LaserPlayer();
						}
				}else {
						if (empty == null)
						{
							empty = Instantiate(A2DGameManager.gamemanager.Info_Empty, new Vector3(0, 0, 0), transform.rotation);
						}
					}
				break;
			case 3:
				if (A2DGameManager.gamemanager.AmmoWeapon3 > 0)
				{
						A2DGameManager.gamemanager.AmmoWeapon3 -= 1;
						A2DGameManager.gamemanager.UpdateTextWeaponSelect3 ();
					ShootingRange = Time.time + A2DGameManager.gamemanager.ShotDelay;
					Instantiate (A2DGameManager.gamemanager.VFX_ShotWeapon3, ShotOrigin.position, ShotOrigin.rotation);
						A2DSoundManager.Sm.LaserPlayer();

					}
					else {
						if (empty == null)
						{
							empty = Instantiate(A2DGameManager.gamemanager.Info_Empty, new Vector3(0, 0, 0), transform.rotation);
						}
					}
				break;
			}

			
		}
			

	}

	public void Fire()
	{
		if (Time.time > ShootingRange)
		{

			switch (A2DGameManager.gamemanager.WeaponActive)
			{
				case 1:
					if (A2DGameManager.gamemanager.AmmoWeapon1 > 0)
					{
						A2DGameManager.gamemanager.AmmoWeapon1 -= 1;
						A2DGameManager.gamemanager.UpdateTextWeaponSelect1();
						ShootingRange = Time.time + A2DGameManager.gamemanager.ShotDelay;
						Instantiate(A2DGameManager.gamemanager.VFX_ShotWeapon1, ShotOrigin.position, ShotOrigin.rotation);
						A2DSoundManager.Sm.LaserPlayer();

					}
					else
					{
						if (empty == null)
						{
							empty = Instantiate(A2DGameManager.gamemanager.Info_Empty, new Vector3(0, 0, 0), transform.rotation);
						}
					}
					break;
				case 2:
					if (A2DGameManager.gamemanager.AmmoWeapon2 > 0)
					{
						A2DGameManager.gamemanager.AmmoWeapon2 -= 1;
						A2DGameManager.gamemanager.UpdateTextWeaponSelect2();
						if (Time.time > ShootingRange)
						{
							ShootingRange = Time.time + A2DGameManager.gamemanager.ShotDelay;
							Instantiate(A2DGameManager.gamemanager.VFX_ShotWeapon2, ShotOrigin.position, ShotOrigin.rotation);
							A2DSoundManager.Sm.LaserPlayer();
						}
						if (Time.time > ShootingRange2)
						{
							ShootingRange2 = Time.time + A2DGameManager.gamemanager.ShotDelay2;
							Instantiate(A2DGameManager.gamemanager.VFX_ShotWeapon2, ShotOrigin2.position, ShotOrigin2.rotation);
							A2DSoundManager.Sm.LaserPlayer();
						}
						if (Time.time > ShootingRange3)
						{
							ShootingRange3 = Time.time + A2DGameManager.gamemanager.ShotDelay3;
							Instantiate(A2DGameManager.gamemanager.VFX_ShotWeapon2, ShotOrigin3.position, ShotOrigin3.rotation);
							A2DSoundManager.Sm.LaserPlayer();
						}
					}
					else
					{
						if (empty == null)
						{
							empty = Instantiate(A2DGameManager.gamemanager.Info_Empty, new Vector3(0, 0, 0), transform.rotation);
						}
					}
					break;
				case 3:
					if (A2DGameManager.gamemanager.AmmoWeapon3 > 0)
					{
						A2DGameManager.gamemanager.AmmoWeapon3 -= 1;
						A2DGameManager.gamemanager.UpdateTextWeaponSelect3();
						ShootingRange = Time.time + A2DGameManager.gamemanager.ShotDelay;
						Instantiate(A2DGameManager.gamemanager.VFX_ShotWeapon3, ShotOrigin.position, ShotOrigin.rotation);
						A2DSoundManager.Sm.LaserPlayer();

					}
					else
					{
						if (empty == null)
						{
							empty = Instantiate(A2DGameManager.gamemanager.Info_Empty, new Vector3(0, 0, 0), transform.rotation);
						}
					}
					break;
			}


		}


	}
	public void GameOver()
	{
		A2DSoundManager.Sm.ExplosionPlayer();
		Instantiate (A2DGameManager.gamemanager.VFX_ExplosionPlayer, transform.position, transform.rotation);
		Destroy (gameObject);
	}



}