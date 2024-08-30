using UnityEngine;

[CreateAssetMenu(menuName = "Sound Effects")]
public class SoundEffectScriptableObject : ScriptableObject
{
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f;
    public bool loop = false;
}
