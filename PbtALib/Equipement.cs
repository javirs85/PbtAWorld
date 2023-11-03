using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class Equipment
{
	public List<EquipmentItem> GoodWeapons { get; set; } = new();
	public List<EquipmentItem> ArmorItems { get; set; } = new();
	public EquipmentItem Things { get; set; } = new EquipmentItem { Name = "Cosas", MaxUses = 3 };
	public EquipmentItem MoreThings { get; set; } = new EquipmentItem { Name = "Mas cosas", MaxUses = 3 };
	public List<EquipmentItem> OtherItems { get; set; } = new();
	public List<EquipmentItem> EditableItems { get; set; } = new List<EquipmentItem>{
			new EquipmentItem { Weight = 1},
			new EquipmentItem { Weight = 1},
			new EquipmentItem { Weight = 1},
			new EquipmentItem { Weight = 2},
			new EquipmentItem { Weight = 2}
		};

	public int CurrentLoad
	{
		get
		{
			int load = getLoad(GoodWeapons) + getLoad(ArmorItems) + getLoad(OtherItems) + getLoad(EditableItems) + getLoad(Misc);
			if (Things.IsLoaded) load++;
			if (MoreThings.IsLoaded) load++;
			return load;
		}
	}

	public int LoadsPerSupply { get; set; } = 3;
	public string SmallThings { get; set; } = "";
	public List<EquipmentItem> Misc { get; set; } = new();

	private int getLoad(List<EquipmentItem> l)
	{
		int result = 0;
		foreach (var i in l)
		{
			if (i.IsLoaded)
				result += i.Weight;
		}
		return result;
	}
}

public class EquipmentItem
{
	public string Name { get; set; } = "";
	public int Weight { get; set; } = 1;
	private bool _isAmunition = false;
	public bool IsAmunitionWeapon
	{
		get { return _isAmunition; }
		set
		{
			_isAmunition = value;
			if (_isAmunition)
				this.MaxUses = 2;
		}
	}
	public List<EquipeLabel> Labels { get; set; } = new();
	private int _uses = 0;
	public int Uses { get; set; } = 0;
	public bool IsLoaded { get; set; } = false;
	public string Explanation { get; set; } = "";
	public int ArmorValue { get; set; }
	public int ArmorAddition { get; set; }
	public int MaxUses { get; set; } = -1;
	public int CurrentUses { get; set; }
}

public class EquipeLabel
{
	public string Name { get; set; } = "";
	public string Description { get; set; } = "";
}
