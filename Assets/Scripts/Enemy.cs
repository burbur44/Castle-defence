
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float damage;
    public float health = 50f;
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
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < stoppingDistance)
        {

            stopEnemy();
           // target.GetComponent<ch>
        }
        else { 

        findTarget();
        }
    }

    private void findTarget() 
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
    }

    private void stopEnemy() 
    {
        agent.isStopped = true;
    }
}
