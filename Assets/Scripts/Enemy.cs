
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float damage;
    public float health = 50f;
    public float lastAttackTime = 0;
    public float attackCooldown = 2;

    Animator anim;
    
    NavMeshAgent  agent;
    GameObject target;
    public int stoppingDistance;

    public void takeDamage(float amount)
     { 
    health -=amount;
        if (health <= 0) {

            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < stoppingDistance)
        {

            stopEnemy();
            if (Time.time - lastAttackTime >= attackCooldown) 
            {
                lastAttackTime = Time.time;
                target.GetComponent<CharacterStats>().takeDamage(damage);
                target.GetComponent<CharacterStats>().CheckHealth();

            }
        }
        else { 

        findTarget();
        }
    }

    private void findTarget() 
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        anim.SetBool("isWalking", true);
    }

    private void stopEnemy() 
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);

    }
}
