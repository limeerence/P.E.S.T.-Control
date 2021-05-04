using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vcd682_GroundRangedEnemyController : vcd682_EnemyContoller
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireRate = .5f;

    [SerializeField] private bool hasAttackAnim = false;
    [SerializeField] private float attackAnimDuration = 2f;

    private float nextShootTime = 0;

    protected override void attack()
    {
        //Do not fire if we have fire too recently
        if (Time.time < nextShootTime)
            return;

        isAttacking = true;
        transform.LookAt(playerLoc);

        StartCoroutine("AttackTimer");
        if (hasAttackAnim)
            anim.SetTrigger("Attack");
        else
            GetComponent<Rigidbody>().velocity = Vector3.zero;

        fireProjectile();
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(attackAnimDuration);
        isAttacking = false;
    }

    void fireProjectile()
    {
        Vector3 projectileSpawnPoint = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint, Quaternion.identity);

        projectile.GetComponent<EnemyProjectileController>().targetPos = playerLoc.position;
        projectile.GetComponent<EnemyProjectileController>().damage = attackDamage;

        nextShootTime = Time.time + 1 / fireRate;
    }
}
