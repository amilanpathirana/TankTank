﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExplotion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;
    public AudioSource m_ExplotionAudio;
    public float m_MaxDamage = 100f;
    public float m_ExplotionForce = 1000f;
    public float m_MaxLifeTime = 2f;
    public float m_ExplotionRadius = 5f;



    private void Start()
    {
        //Destroy(gameObject, m_MaxLifeTime);  
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Saw collider");
        Vector3 HitLocation = transform.position;

        HitLocation.z = 0;

        Collider[] colliders = Physics.OverlapSphere(HitLocation, m_ExplotionRadius);


        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody2D rb = colliders[i].GetComponent<Rigidbody2D>();
            Transform Tf = colliders[i].GetComponent<Transform>();
            if (!rb)
                continue;

            Vector3 ForceDirection = (Tf.position - transform.position).normalized;
            rb.AddForce(ForceDirection * m_ExplotionForce, ForceMode2D.Impulse);


            TankHealth targetHealth = rb.GetComponent<TankHealth>();
            if (!targetHealth)
                continue;

            float damage = CalculateDamage(rb.position);

            targetHealth.TakeDamage(damage);


        }

        m_ExplosionParticles.transform.parent = null;
        m_ExplosionParticles.Play();

        m_ExplotionAudio.Play();

        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
        Destroy(gameObject);
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explotionDirection = targetPosition - transform.position;
        float explotionDistance = explotionDirection.magnitude;
        float relativeDistance = (m_ExplotionRadius - explotionDistance) / m_ExplotionRadius;
        float damage = relativeDistance * m_MaxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;

    }





}
