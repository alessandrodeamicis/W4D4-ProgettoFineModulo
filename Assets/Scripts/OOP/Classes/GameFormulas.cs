using Enums;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Classes
{
    public static class GameFormulas
    {
        public static bool HasElementAdvantage(ELEMENT attachElement, Hero defender)
        {
            return defender.GetWeakness() == attachElement;
        }
        public static bool HasElementDisadvantage(ELEMENT attachElement, Hero defender)
        {
            return defender.GetResistance() == attachElement;
        }
        public static float EvaluateElementalModifier(ELEMENT attachElement, Hero defender)
        {
            if (HasElementAdvantage(attachElement, defender)) return 1.5f;
            else if (HasElementDisadvantage(attachElement, defender)) return 0.5f;
            else return 0;
        }
        public static bool HasHit(Stats attacker, Stats defender)
        {
            int hitChance = attacker.aim - defender.eva;
            int randomNumber = Random.Range(0, 99);
            if (randomNumber > hitChance)
            {
                Debug.Log("MISS");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsCrit(int critValue)
        {
            int randomNumber = Random.Range(0, 99);
            if (randomNumber < critValue)
            {
                Debug.Log("CRIT");
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int CalculateDamage(Hero attacker, Hero defender)
        {
            Stats attackerStats = GetStatsWithWeapon(attacker);
            Stats defenderStats = GetStatsWithWeapon(defender);

            int defenderDefense = attacker.GetWeapon().GetDmgType() == DAMAGE_TYPE.PHYSICAL ? defenderStats.def : defenderStats.res;
            int baseDamage = attackerStats.atk - defenderDefense;
            int modifiedDamage = (int)(EvaluateElementalModifier(attacker.GetWeapon().GetElem(), defender) * baseDamage);
            modifiedDamage = IsCrit(modifiedDamage) ? modifiedDamage * 2 : modifiedDamage;

            if (modifiedDamage < 0) return modifiedDamage;
            return modifiedDamage;
        }
        public static Stats GetStatsWithWeapon(Hero hero)
        {
            return Stats.Sum(hero.GetBaseStats(), hero.GetWeapon().GetBonusStats());
        }
    }

}
