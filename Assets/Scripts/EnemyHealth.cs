using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;

    [Tooltip("Adds amount to maxHP when enemy dies")]
    [SerializeField] int difficultyRound = 1;

    Enemy enemy;
    int currentHP = 0;

    void OnEnable()
    {
        currentHP = maxHP;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit(other);
    }

    void ProcessHit(GameObject other)
    {
        currentHP--;
        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
            maxHP += difficultyRound;
            enemy.RewardGold();
        }
    }
}
