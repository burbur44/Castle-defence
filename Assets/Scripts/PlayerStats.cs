using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats

{

    PlayerUi  PlayerUi;
    // Start is called before the first frame update
    void Start()
    {
        PlayerUi = GetComponent<PlayerUi>();
        maxHealth = 100;
        currHealth = maxHealth;

        setStats();

    }

    public override void Die()
    {
        Debug.Log("you died");
    }

    void setStats()
    {
        PlayerUi.healtAmount.text = currHealth.ToString();
    }

    public override void CheckHealth()
    {

        base.CheckHealth();
        setStats();

    }
}
