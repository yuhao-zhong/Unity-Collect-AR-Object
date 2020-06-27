﻿using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] private int scoreYouGet = 1;
    [SerializeField] private ParticleSystem burstingParticlePrefab;
    
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        GameManager.Instance.AddScore(scoreYouGet);

        source.Play();

        var burstingParticle = GameObject.Instantiate(burstingParticlePrefab, transform.position, Quaternion.identity);      
        
        burstingParticle.Play();

        Destroy(burstingParticle.gameObject, burstingParticle.main.duration);
        
        Destroy(gameObject, 0.5F);
    }
}
