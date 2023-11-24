using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private EnemyAI enemyAI;
    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    public void TakeDamage(int damage)
    {
        if (enemyAI != null) enemyAI.ReactToHit(damage);
        if (enemyAI.health <= 0)
        {
            enemyAI._alive = false;
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
