using System;

internal class Weapon : wepInteraction{

	private Rarity rarity;
	private double attackSpeed;
	private double damage;
	private double durability;
	private string name;
	private ElementalDamages element;
	public Weapon() : base(){
	}

	public Weapon(Rarity d, double s, double a, double b, string c, ElementalDamages e) : this()
	{
		this.rarity = d;
		this.attackSpeed = s;
		this.damage = a;
		this.durability = b;
		this.name = c;
		this.element = e;
	}
	public virtual string info()
	{
		return "Rarity: " + rarity + "\nName: " + name + " \nDamage: " + damage + " \nDurability: " + durability + " \nAttack speed: " + attackSpeed;
	}
	public virtual ElementalDamages Ele
	{
		get
		{
			return element;
		}
	}
	public static Rarity generateRarity()
	{
		Rarity rez;
		double r = GlobalRandom.NextDouble;
		if (r <= 0.7)
		{
			rez = Rarity.Common;
		}
		else if (r > 0.7 && r <= 0.9)
		{
			rez = Rarity.Uncommon;
		}
		else if (r > 0.9 && r <= 0.95)
		{
			rez = Rarity.Rare;
		}
		else
		{
			rez = Rarity.Mystic;
		}
		return rez;
	}

	public virtual double damageSth(double critChance, double critMulti)
	{
		double rez = damage * durability * attackSpeed;
		double bla = GlobalRandom.NextDouble * 10;
		if (bla < critChance)
		{
			rez = rez * 1.0;
		}
		else
		{
			switch (this.rarity)
			{
				case Rarity.Common:
					rez *= (critMulti / 3.0);
					break;
				case Rarity.Uncommon:
					rez *= (critMulti / 2.0);
					break;
				case Rarity.Rare:
					rez *= (critMulti / 1.5);
					break;
				default:
				rez *= critMulti;
				break;
			}
		}
		if (durability > 1)
		{
			durability = durability - 0.5;
		}
		else
		{
			durability = 1;
		}

		Console.WriteLine("Crit roll: " + bla);
		Console.WriteLine("You did " + rez + " damage.");

		return rez;
	}

	public static string generateName(Weapon w, Rarity r)
	{
		string rez = "";
		if (r == Rarity.Common)
		{
			if (w is Sword)
			{
				double d1 = GlobalRandom.NextDouble;
				if (d1 <= 0.33)
				{
					rez += "Rusty";
				}
				else if (d1 > 0.33 && d1 <= 0.66)
				{
					rez += "Crooked";
				}
				else
				{
					rez += "Weathered";
				}
				rez += " ";
				double d2 = GlobalRandom.NextDouble;
				if (d2 <= 0.33)
				{
					rez += "Spike";
				}
				else if (d2 > 0.33 && d1 <= 0.66)
				{
					rez += "Blade";
				}
				else
				{
					rez += "Bar";
				}
			}
			else if (w is Dagger)
			{
				double d1 = GlobalRandom.NextDouble;
				if (d1 <= 0.33)
				{
					rez += "Rusty";
				}
				else if (d1 > 0.33 && d1 <= 0.66)
				{
					rez += "Decrepid";
				}
				else
				{
					rez += "Old";
				}
				rez += " ";
				double d2 = GlobalRandom.NextDouble;
				if (d2 <= 0.33)
				{
					rez += "Shank";
				}
				else if (d2 > 0.33 && d1 <= 0.66)
				{
					rez += "Knife";
				}
				else
				{
					rez += "Shard";
				}
			}
		}
		else if (r == Rarity.Uncommon)
		{
			if (w is Sword)
			{
				double d1 = GlobalRandom.NextDouble;
				if (d1 <= 0.33)
				{
					rez += "Polished";
				}
				else if (d1 > 0.33 && d1 <= 0.66)
				{
					rez += "Tempered";
				}
				else
				{
					rez += "Strong";
				}
				rez += " ";
				double d2 = GlobalRandom.NextDouble;
				if (d2 <= 0.33)
				{
					rez += "Claymore";
				}
				else if (d2 > 0.33 && d1 <= 0.66)
				{
					rez += "Rapier";
				}
				else
				{
					rez += "Highlander";
				}
			}
			else if (w is Dagger)
			{
				double d1 = GlobalRandom.NextDouble;
				if (d1 <= 0.33)
				{
					rez += "Polished";
				}
				else if (d1 > 0.33 && d1 <= 0.66)
				{
					rez += "Sharpened";
				}
				else
				{
					rez += "Poisonous";
				}
				rez += " ";
				double d2 = GlobalRandom.NextDouble;
				if (d2 <= 0.33)
				{
					rez += "Dagger";
				}
				else if (d2 > 0.33 && d1 <= 0.66)
				{
					rez += "Edge";
				}
				else
				{
					rez += "Blade";
				}
			}
		}
		else if (r == Rarity.Rare)
		{
			if (w is Sword)
			{
				double d1 = GlobalRandom.NextDouble;
				if (d1 <= 0.50)
				{
					rez += "Myghty";
				}
				else if (d1 > 0.50)
				{
					rez += "Annealed";
				}
				rez += " ";
				double d2 = GlobalRandom.NextDouble;
				if (d2 <= 0.50)
				{
					rez += "Katana";
				}
				else if (d2 > 0.50)
				{
					rez += "Headtaker";
				}
			}
			else if (w is Dagger)
			{
				double d1 = GlobalRandom.NextDouble;
				if (d1 <= 0.50)
				{
					rez += "Venomous";
				}
				else if (d1 > 0.50)
				{
					rez += "Tyrannical";
				}
				rez += " ";
				double d2 = GlobalRandom.NextDouble;
				if (d2 <= 0.50)
				{
					rez += "Reaper";
				}
				else if (d2 > 0.50)
				{
					rez += "Destroyer";
				}
			}
		}
		else if (r == Rarity.Mystic)
		{
			if (w is Sword)
			{
				double d1 = GlobalRandom.NextDouble;
				if (d1 <= 0.50)
				{
					rez += "Divine";
				}
				else if (d1 > 0.50)
				{
					rez += "Fabled";
				}

				rez += " ";
				double d2 = GlobalRandom.NextDouble;
				if (d2 <= 0.50)
				{
					rez += "Decimator";
				}
				else if (d2 > 0.50)
				{
					rez += "Chaoseater";
				}
			}
			else if (w is Dagger)
			{
				double d1 = GlobalRandom.NextDouble;
				if (d1 <= 0.50)
				{
					rez += "Eternal";
				}
				else if (d1 > 0.50)
				{
					rez += "Mythical";
				}
				rez += " ";
				double d2 = GlobalRandom.NextDouble;
				if (d2 <= 0.50)
				{
					rez += "Sai";
				}
				else if (d2 > 0.50)
				{
					rez += "Kris";
				}
			}
		}
		return rez;
	}

	public static double generateDamage(Weapon w, Rarity r)
	{
		double rez = 0.0;
		if (r == Rarity.Common)
		{
			if (w is Sword)
			{
				rez += 3.0;
			}
			if (w is Dagger)
			{
				rez += 1.7;
			}
		}
		if (r == Rarity.Uncommon)
		{
			if (w is Sword)
			{
				rez += 4.5;
			}
			if (w is Dagger)
			{
				rez += 2.9;
			}
		}
		if (r == Rarity.Rare)
		{
			if (w is Sword)
			{
				rez += 6.0;
			}
			if (w is Dagger)
			{
				rez += 4.5;
			}
		}
		if (r == Rarity.Mystic)
		{
			if (w is Sword)
			{
				rez += 10;
			}
			if (w is Dagger)
			{
				rez += 8.5;
			}
		}
		return rez;
	}

	public static double generateAtkSpeed(Rarity r, Weapon w)
	{
		double rez = 0.0;
		if (r == Rarity.Common)
		{
			if (w is Sword)
			{
				rez += 1.3;
			}
			if (w is Dagger)
			{
				rez += 1.7;
			}
		}
		if (r == Rarity.Uncommon)
		{
			if (w is Sword)
			{
				rez += 1.5;
			}
			if (w is Dagger)
			{
				rez += 1.9;
			}
		}
		if (r == Rarity.Rare)
		{
			if (w is Sword)
			{
				rez += 1.7;
			}
			if (w is Dagger)
			{
				rez += 2.1;
			}
		}
		if (r == Rarity.Mystic)
		{
			if (w is Sword)
			{
				rez += 1.9;
			}
			if (w is Dagger)
			{
				rez += 2.3;
			}
		}
		return rez;
	}

	public static double generateDurability(Rarity r, Weapon w)
	{
		double rez = 0.0;
		if (r == Rarity.Common)
		{
			if (w is Sword)
			{
				rez += 7.0;
			}
			if (w is Dagger)
			{
				rez += 6.5;
			}
		}
		if (r == Rarity.Uncommon)
		{
			if (w is Sword)
			{
				rez += 10.0;
			}
			if (w is Dagger)
			{
				rez += 9.0;
			}
		}
		if (r == Rarity.Rare)
		{
			if (w is Sword)
			{
				rez += 17.0;
			}
			if (w is Dagger)
			{
				rez += 16.0;
			}
		}
		if (r == Rarity.Mystic)
		{
			if (w is Sword)
			{
				rez += 30.0;
			}
			if (w is Dagger)
			{
				rez += 30.0;
			}
		}
		return rez;
	}

	public static ElementalDamages generateElementalDamage(Weapon w){
		if (w.rarity == Rarity.Rare){
			double eDmgRoll = GlobalRandom.NextDouble;
			if (eDmgRoll <= 0.7)
			{
				double rng = (GlobalRandom.NextDouble * 10);
				if (rng <= 4.70)
				{
					return ElementalDamages.Inferno;
				}
				else if (rng > 4.70 && rng <= 9.60)
				{
					return ElementalDamages.Frost;
				}
				else
				{
					return ElementalDamages.Chaos;
				}
			}
		}
		else if (w.rarity == Rarity.Mystic){
			double eDmgRoll = GlobalRandom.NextDouble;
			if (eDmgRoll <= 0.3)
			{
				double rng = (GlobalRandom.NextDouble * 10);
				if (rng <= 4.80)
				{
					return ElementalDamages.Inferno;
				}
				else if (rng > 4.80 && rng <= 9.80)
				{
					return ElementalDamages.Frost;
				}
				else
				{
					return ElementalDamages.Chaos;
				}
			}
		}
		return ElementalDamages.Inferno;
	}

	public static void elementalMethod(Weapon w)
	{
		double rez = 0.0;
		if (w.element != null)
		{
			if (w.rarity == Rarity.Common || w.rarity == Rarity.Uncommon)
			{
				return;
			}
			else if (w.rarity == Rarity.Rare)
			{
				if (w.element == ElementalDamages.Frost)
				{
					Console.WriteLine("FROST DAMAGE BONUS");
					rez += 1.0;
					w.damage += rez;
				}
				else if (w.element == ElementalDamages.Inferno)
				{
					Console.WriteLine("INFERNO DAMAGE BONUS");
					rez += 0.5;
					w.attackSpeed += rez;
				}
				else if (w.element == ElementalDamages.Chaos)
				{
					Console.WriteLine("C H A O S   D A M A G E");
					rez = 1.2;
					double rez2 = 0.6;
					w.damage += rez;
					w.attackSpeed += rez2;
				}
			}
			else if (w.rarity == Rarity.Mystic)
			{
				if (w.element == ElementalDamages.Frost)
				{
					Console.WriteLine("FROST DAMAGE BONUS");
					rez += 1.5;
					w.damage += rez;
				}
				else if (w.element == ElementalDamages.Inferno)
				{
					Console.WriteLine("INFERNO DAMAGE BONUS");
					rez += 0.8;
					w.attackSpeed += rez;
				}
				else if (w.element == ElementalDamages.Chaos)
				{
					Console.WriteLine("C H A O S   D A M A G E");
					rez = 2.1;
					double rez2 = 1.0;
					w.damage += rez;
					w.attackSpeed += rez2;
				}
			}
		}
		else
		{
			return;
		}
	}
}

internal interface wepInteraction
{
	double damageSth(double critChance, double critMulti);
}

internal enum ElementalDamages
{
	Inferno,
	Frost,
	Chaos
}

internal enum Rarity
{
	Common,
	Uncommon,
	Rare,
	Mystic
}

internal class Dagger : Weapon, wepInteraction
{
	internal double daggerCritMultiplier;
	internal double daggerCritChance;
	internal Rarity r;

	public Dagger(Rarity x, double a, double b, double d, string z, ElementalDamages e) : base(x, a, b, d, z, e)
	{
		this.daggerCritMultiplier = 2.3;
		this.daggerCritChance = 7.0;
	}

	public override string info()
	{
		return "Dagger \n" + base.info() + "\nCrit chance: " + daggerCritChance + "\nCrit multiplier: " + daggerCritMultiplier;
	}

	public override double damageSth(double critChance, double critMulti)
	{
		return base.damageSth(daggerCritChance, daggerCritMultiplier);
	}
}

internal class Sword : Weapon, wepInteraction
{
	internal double swordCritMultiplier;
	internal double swordCritChance;

	public Sword(Rarity x, double a, double b, double c, string y, ElementalDamages e) : base(x, a, b, c, y, e)
	{
		this.swordCritChance = 9.0;
		this.swordCritMultiplier = 1.6;
	}

	public override string info()
	{
		return "Sword \n" + base.info() + "\nCrit chance: " + swordCritChance + "\nCrit multiplier: " + swordCritMultiplier;
	}

	public override double damageSth(double critChance, double critMulti)
	{
		return base.damageSth(swordCritChance, swordCritMultiplier);
	}
}