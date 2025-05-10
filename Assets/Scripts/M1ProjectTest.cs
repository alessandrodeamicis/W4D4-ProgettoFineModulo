using System.Collections;
using System.Collections.Generic;
using Classes;
using Enums;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField]
    private Hero a;
    [SerializeField]
    private Hero b;
    void Start()
    {

    }

    void Update()
    {
        if (!a.IsAlive() || !b.IsAlive()) { return; }

        Hero firstAttacker;
        Hero secondAttacker;

        if (GameFormulas.GetStatsWithWeapon(a).spd > GameFormulas.GetStatsWithWeapon(b).spd)
        {
            firstAttacker = a;
            secondAttacker = b;
        }
        else
        {
            firstAttacker = b;
            secondAttacker = a;
        }

        Attack(firstAttacker, secondAttacker);

        if (secondAttacker.IsAlive())
        {
            Attack(secondAttacker, firstAttacker);
        }
    }

    public void Attack(Hero attacker, Hero defender)
    {
        Debug.Log($"{attacker.GetName()} is attacking");

        if (GameFormulas.HasHit(GameFormulas.GetStatsWithWeapon(attacker), GameFormulas.GetStatsWithWeapon(defender)))
        {
            if (GameFormulas.HasElementDisadvantage(attacker.GetWeapon().GetElem(), defender))
                Debug.Log("WEAKNESS");

            if (GameFormulas.HasElementAdvantage(attacker.GetWeapon().GetElem(), defender))
                Debug.Log("RESIST");

            int damage = GameFormulas.CalculateDamage(attacker, defender);
            defender.TakeDamage(damage);
            Debug.Log($"{attacker.GetName()} has hit {damage} of damage");

            if (!defender.IsAlive())
            {
                Debug.Log($"{attacker.GetName()} has won!");
            }
        }
    }
}
