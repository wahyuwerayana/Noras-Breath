using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [System.Serializable]
    public class Sound{
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume = 1f;
        public bool loop = false;
        public bool needStartStopTime;
    }

    public Sound[] sounds;
    private List<AudioSource> audioSources;

    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else{
            Destroy(gameObject);
        }

        audioSources = new List<AudioSource>();
    }

    public void Play(string soundName){
        Sound s = System.Array.Find(sounds, sound => sound.name == soundName);
        if(s != null){
            AudioSource source = GetAvailableAudioSource();
            source.clip = s.clip;
            source.volume = s.volume;
            source.loop = s.loop;
            if(s.needStartStopTime){
                float startTime = Random.Range(1, 10);
                startTime -= 0.2f;
                source.time = startTime;
                source.Play();
                StartCoroutine(StopAudio());
                IEnumerator StopAudio(){
                    yield return new WaitForSeconds(1f);
                    source.Stop();
                }
            } else
                source.Play();
        } else{
            Debug.LogWarning("Sound: " + soundName + " not found");
        }
    }

    private AudioSource GetAvailableAudioSource(){
        foreach(AudioSource source in audioSources){
            if(!source.isPlaying)
                return source;
        }
        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        audioSources.Add(newSource);
        return newSource;
    }

    public void StopAll(){
        foreach(AudioSource source in audioSources){
            source.Stop();
        }
    }
}
