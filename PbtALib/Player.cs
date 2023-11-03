﻿namespace PbtALib;

public class Player
{
	private Guid _id = Guid.NewGuid();

	public Guid ID
	{
		get { return _id; }
		set { _id = value; }
	}

	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;

}


