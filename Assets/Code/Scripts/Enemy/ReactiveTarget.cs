using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private EnemyCharacter enemyCharacter;
    private void Start()
    {
        enemyCharacter = GetComponent<EnemyCharacter>();
    }

    public void TakeDamage(int damage)
    {
        if (enemyCharacter != null) enemyCharacter.ReactToHit(damage);
        if (enemyCharacter.health <= 0)
        {
            enemyCharacter._alive = false;
            StartCoroutine(DieCoroutine(3));
        }
        
    }


    private IEnumerator DieCoroutine(float waitSecond)
    {
        this.transform.Rotate(45, 0, 0);

        yield return new WaitForSeconds(waitSecond);

        Destroy(this.transform.gameObject);
    }
}
