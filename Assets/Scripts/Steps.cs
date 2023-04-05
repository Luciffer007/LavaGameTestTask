using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class Steps : MonoBehaviour
{
    [SerializeField] 
    private AudioClip[] stoneClips;
    
    [SerializeField] 
    private AudioClip[] woodClips;
    
    private AudioSource _audioSource;

    private PhysicMaterial _hitMaterial;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(GetComponent<Collider>().bounds.center, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            _hitMaterial = hit.transform.GetComponent<Collider>().sharedMaterial;
        }
    }

    private void Step()
    {
        AudioClip clip;
        
        switch (_hitMaterial.name)
        {
            case "Stone":
                clip = GetRandomClip(stoneClips);
                break;
            case "Wood":
                clip = GetRandomClip(woodClips);
                break;
            default:
                throw new ArgumentException("Material not exist");
        }
        
        _audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip(AudioClip[] audioClips)
    {
        return audioClips[Random.Range(0, audioClips.Length)]; 
    }
}
