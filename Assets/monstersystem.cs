using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstersystem : MonoBehaviour
{
    public int HP;
    public int MinHP, MaxHP;
    public GameObject monster;
    public float spawnRate = 30f;
    public float spawnChance = 0.25f;
    public bool IsmonsterComing = false;

    public Animator animator;

    public BaseSystem baseSystem;

    private float timeSinceLastSpawn = 0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0f;

            if (Random.value < spawnChance)
            {
                HP = Random.Range(MinHP , MaxHP);
                monster.SetActive(true);
                IsmonsterComing = true;
                baseSystem.baseResetByMonster();
            }
        }
    }

    public void Attack(int damage)
    {
        HP -= damage;
        animator.SetTrigger("Gethit");
        if (HP <= 0)
        {
            animator.SetBool("isDead", true);
            StartCoroutine(delay());
        }
    }

    private void Reset()
    {
        monster.SetActive(false);
        animator.SetBool("isDead", false);
        IsmonsterComing = false;
        
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        Reset();
    }
}
