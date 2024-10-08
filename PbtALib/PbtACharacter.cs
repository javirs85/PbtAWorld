﻿namespace PbtALib;

public class PbtACharacter : ICharacter
{
	public event EventHandler UpdateUI;
	public event EventHandler UpdateVTT;

	public void OnUpdateUI()=>UpdateUI?.Invoke(this, EventArgs.Empty);
	public void OnVTTUpdate()=>UpdateVTT?.Invoke(this, EventArgs.Empty);

	public bool IsDead { get; set; } = false;
	public bool IsNPC { get; set; } = true;
	public bool IsKnownByPlayers { get; set; } = false;


	private string _name = "Escoge un nombre";

	public virtual object Duplicate(object Character) { throw new NotImplementedException(); }


	public virtual int GetBonus<T>(T stat){
		throw new NotImplementedException();
	}

	public string SerializedData { get; set; } = string.Empty;

	public virtual string ClassString { get; } = string.Empty;

	public void Init() {
		InitInternal();
		IsInitialized = true;
	}
	public bool IsInitialized { get; set; } = false;

	protected virtual void InitInternal()
	{
		throw new Exception("Init internal at PbtACharacter MUST be overriden");
	}

}


