using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuSoundManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSource;
	public AudioSource SecondaryTrackSource;
	private bool muted = false;

	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;
	// Singleton instance.
	public static MenuSoundManager Instance = null;

	public AudioClip backgroundClip;
	public AudioClip gameMusicClip;
	public AudioClip switchClip;
	public AudioClip btnClip;
	public AudioClip breadClip;
	public AudioClip grainClip;
	public AudioClip swimClip;
	public AudioClip deathClip;

	public void Start()
    {
		int mutedInt = PlayerPrefs.GetInt("muted");
		if (mutedInt == 1)
        {
			muted = true;
        }
    }

    // Initialize the singleton instance.
    private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}
	// Play a single clip through the sound effects source.
	public void PlayBtn()
	{
		if (!muted)
        {
			EffectsSource.clip = btnClip;
			EffectsSource.Play();
		}
	}

	public void PlaySwitch()
	{
		if (!muted)
        {
			EffectsSource.clip = switchClip;
			EffectsSource.Play();
		}
	}

	public void PlayBread()
	{
		if (!muted)
		{
			EffectsSource.clip = breadClip;
			EffectsSource.Play();
		}
	}

	public void PlayGrain()
	{
		if (!muted)
		{
			EffectsSource.clip = grainClip;
			EffectsSource.Play();
		}
	}

	public void PlayDeath()
	{
		if (!muted)
		{
			EffectsSource.clip = deathClip;
			EffectsSource.Play();
		}
	}

	// Play a random clip from an array, and randomize the pitch slightly.
	public void RandomSoundEffect(params AudioClip[] clips)
	{
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range(LowPitchRange, HighPitchRange);
		EffectsSource.pitch = randomPitch;
		EffectsSource.clip = clips[randomIndex];
		EffectsSource.Play();
	}

	public void MenuMusic()
    {
		MusicSource.clip = backgroundClip;
		MusicSource.Play();
		SecondaryTrackSource.Stop();
	}

	public void GameMusic()
	{
		MusicSource.clip = gameMusicClip;
		MusicSource.Play();
		SecondaryTrackSource.clip = swimClip;
		SecondaryTrackSource.Play();
	}

	public void Mute()
    {
		muted = true;
		MusicSource.mute = true;
		SecondaryTrackSource.mute = true;

	}

	public void Unmute()
	{
		muted = false;
		MusicSource.mute = false;
		SecondaryTrackSource.mute = false;
	}

}