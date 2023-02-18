using UnityEngine;
public class A2DSoundManager : MonoBehaviour {

	AudioSource music;
	AudioSource sfx;

    public AudioClip[] GameMusic;
	public AudioClip Button;
	public AudioClip Shot_Enemy;
	public AudioClip Sound_Items;
	public AudioClip laserPlayer;
	public AudioClip laserEnemy;
	public AudioClip Explosion_Enemy;
	public AudioClip Explosion_Player;
	public AudioClip Explosion_Asteroid;
	public AudioClip SoundBoos;

	public static A2DSoundManager Sm;

	void Awake() {
		Sm = this;
		AudioSource[] sources = GetComponents<AudioSource>();
		music = sources[0];
		sfx = sources[1];
	}


	void Start () {
		RandomSong ();
	}

	void RandomSong()
	{
		int Selected = Random.Range(0,GameMusic.Length);
		music.clip = GameMusic[Selected];
		music.Play();
	}

	public void ExplosionEnemy()
	{
		sfx.PlayOneShot (Explosion_Enemy,0.7F);
	}

	public void SoundEnemyINI()
	{
		music.Stop();
		music.PlayOneShot (SoundBoos,1);
	}

	public void SoundEnemyEND()
	{
		music.Stop();
		RandomSong ();
	}
	public void ShotEnemy()
	{
		sfx.PlayOneShot (Shot_Enemy,1);
	}
	public void ExplosionPlayer()
	{
		sfx.PlayOneShot (Explosion_Player,1);
	}
	public void ExplosionAsteroid()
	{
		sfx.PlayOneShot (Explosion_Asteroid,1);
	}

	public void SoundItemsCollect ()
	{
		sfx.PlayOneShot (Sound_Items,1);
	}

	public void SoundButton()
	{
		sfx.PlayOneShot (Button,1);
	}

	public void LaserPlayer()
	{
		sfx.PlayOneShot (laserPlayer,1);
	}

	public void LaserEnemy()
	{
		sfx.PlayOneShot (laserEnemy,1);
	}

}
