using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update


    public float currHealth;
    public float maxHealth;

     public bool isDead = false;

    public  virtual void CheckHealth()
    {
        if (currHealth >= maxHealth)
            currHealth = maxHealth;
        if (currHealth <= 0)
        {
            currHealth = 0;
            isDead = true;
        }

    }

    public virtual void Die()
    {
    
    }

    public void takeDamage(float damage) 
    {
        currHealth -= damage;
    }
}
