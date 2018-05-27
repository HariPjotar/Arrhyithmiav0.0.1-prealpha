using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class a : MonoBehaviour{
	
	public void Drop(){
		
		double j = GlobalRandom.NextDouble;
		if (j <= 0.33){
			Rarity r = Weapon.generateRarity();
			Weapon c1 = new Sword(r, 1.3, 5, 4.5, "", ElementalDamages.Inferno);
			Sword c = new Sword(r, Weapon.generateAtkSpeed(r, c1), Weapon.generateDamage(c1, r), Weapon.generateDurability(r, c1), Weapon.generateName(c1, r), Weapon.generateElementalDamage(c1));
			Weapon.elementalMethod(c);
			for (int k = 0; k <= 0; k++)
			{
				Debug.Log(c.info());
				c.damageSth(c.swordCritChance, c.swordCritMultiplier);
				Debug.Log ("");
			}
		}else if (j > 0.33 && j < 0.66){
			Rarity r = Weapon.generateRarity();
			Weapon a1 = new Dagger(r, 1.75, 3.0, 4.0, "", ElementalDamages.Inferno);
			Dagger a = new Dagger(r, Weapon.generateAtkSpeed(r, a1), Weapon.generateDamage(a1, r), Weapon.generateDurability(r, a1), Weapon.generateName(a1, r), Weapon.generateElementalDamage(a1));
			Weapon.elementalMethod(a);
			for (int i = 0; i <= 0; i++)
			{
				Debug.Log(a.info());
				a.damageSth(a.daggerCritChance, a.daggerCritMultiplier);
				Debug.Log("");
			}
		}else{
			Debug.Log("You get nothing!");
		}
		Debug.Log("RNG: ");
		Debug.Log(j);
	}

	void Update(){
		if (Input.GetKey (KeyCode.P)) {
			Drop ();
		}
	}
}