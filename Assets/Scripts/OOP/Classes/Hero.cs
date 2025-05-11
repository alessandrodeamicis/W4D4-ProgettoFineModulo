using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Classes
{
    [Serializable]
    public class Hero
    {
        [SerializeField]
        private string name;
        [SerializeField]
        private int hp;
        [SerializeField]
        private Stats baseStats;
        [SerializeField]
        private ELEMENT resistance;
        [SerializeField]
        private ELEMENT weakness;
        [SerializeField]
        private Weapon weapon;

        public Hero(string name, int hp, Stats baseStats, ELEMENT resistance, ELEMENT weakness, Weapon weapon)
        {
            SetName(name);
            SetHp(hp);
            SetStats(baseStats);
            SetResistance(resistance);
            SetWeakness(weakness);
            SetWeapon(weapon);
        }

        public string GetName() { return name; }
        public int GetHP() { return hp; }
        public Stats GetBaseStats() { return baseStats; }
        public ELEMENT GetResistance() { return resistance; }
        public ELEMENT GetWeakness() { return weakness; }
        public Weapon GetWeapon() { return weapon; }
        public void SetName(string name) { this.name = name; }
        public void SetHp(int hp) { this.hp = hp < 0 ? 0 : hp; }
        public void SetStats(Stats baseStats) { this.baseStats = baseStats; }
        public void SetResistance(ELEMENT resistance) { this.resistance = resistance; }
        public void SetWeakness(ELEMENT weakness) { this.weakness = weakness; }
        public void SetWeapon(Weapon weapon) { this.weapon = weapon; }
        public void AddHp(int amount) { SetHp(this.hp += amount); }
        public void TakeDamage(int damage) { AddHp(-damage); }
        public bool IsAlive() { return hp > 0; }
    }
}
