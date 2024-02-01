﻿using Microsoft.AspNetCore.Components.Web;
using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtaWorldRazonCommonComponents;

public class VTTService
{
	public event EventHandler UpdateUI;
	public List<Token> Tokens = new();

    public VTTService()
    {
        Tokens.Add(new Token { ID = VTTTokens.Paladin, X=100, Y= 100});
        Tokens.Add(new Token { ID = VTTTokens.Thief, X=300, Y= 300});
    }

    private bool _isIvisible;

	public bool IsVisible
	{
		get { return _isIvisible; }
		set 
		{
			if(_isIvisible != value)
			{
				_isIvisible = value;
				Update();
			}			
		}
	}
	public void Clicked(MouseEventArgs e)
	{
		var ClickX = e.OffsetX;
		var ClickY = e.OffsetY;
		var t = Tokens[0];
		t.X = (int)ClickX - Token.BasicSize / 2;
		t.Y = (int)ClickY - Token.BasicSize / 2;

		Update();
	}

	public Token? SelectToken(double x, double y)
	{
		double minDist = 100000;
		Token? SelectedToken = null;

		foreach(var t in Tokens)
		{
			var d =  Math.Abs(t.X - x) + Math.Abs(t.Y - y);
			if (d < minDist)
			{
				if(d< 100)
				{
					minDist = d;
					SelectedToken = t;
				}
			}
		}

		return SelectedToken;
	}

	public void MoveToken(Token t,double X, double Y)
	{
		var token = Tokens.Find(x=>x.Guid == t.Guid);
		if(token != null)
		{
			token.X = (int)X - Token.BasicSize / 2;
			token.Y = (int)Y - Token.BasicSize / 2;
		}
		Update();
	}

	public void AddToken(VTTTokens t)
	{
		Tokens.Add( new Token { ID = t, X = 50, Y = 50});
	}

	void Update()=> UpdateUI?.Invoke(this, EventArgs.Empty);


	public List<PbtACharacter> Players { get; set; } = new();
	public string ImageName { get; set; } = "farm.jpg";

	public void Show()
	{
		IsVisible = true;
	}

	public void Hide()
	{
		IsVisible = false;
	}
}

public class Token
{
	public VTTTokens ID = VTTTokens.Barbarian;
	public static int BasicSize = 60;
	public Guid Guid { get; set; }

    public Token()
    {
        Guid = Guid.NewGuid();
    }

    public int ImgX
	{
		get
		{
			return ID switch
			{
				VTTTokens.WhiteLady1 => -BasicSize * 0,
				VTTTokens.WhiteLady2 => -BasicSize * 1,
				VTTTokens.WhiteLady3 => -BasicSize * 2,
				VTTTokens.WhiteMale1 => -BasicSize * 3,
				VTTTokens.WhiteMale2 => -BasicSize * 4,
				VTTTokens.WhiteMale3 => -BasicSize * 5,
				VTTTokens.BoxGray => -BasicSize * 6,
				VTTTokens.BoxRed => -BasicSize * 0,
				VTTTokens.BoxBlue => -BasicSize * 1,
				VTTTokens.Black1 => -BasicSize * 2,
				VTTTokens.Black2 => -BasicSize * 3,
				VTTTokens.Black3 => -BasicSize * 4,
				VTTTokens.Black4 => -BasicSize * 5,
				VTTTokens.Black5 => -BasicSize * 6,
				VTTTokens.Black6 => -BasicSize * 0,
				VTTTokens.Black7 => -BasicSize * 1,
				VTTTokens.Black8 => -BasicSize * 2,
				VTTTokens.BlackBoss => -BasicSize * 3,

				VTTTokens.Red8 => -BasicSize * 5,
				VTTTokens.Red7 => -BasicSize * 6,
				VTTTokens.Red6 => -BasicSize * 0,
				VTTTokens.Red5 => -BasicSize * 1,
				VTTTokens.Red4 => -BasicSize * 2,
				VTTTokens.Red3 => -BasicSize * 3,
				VTTTokens.Red2 => -BasicSize * 4,
				VTTTokens.Red1 => -BasicSize * 5,
				VTTTokens.RedBoss => -BasicSize * 6,

				VTTTokens.Green1 => -BasicSize * 1,
				VTTTokens.Green2 => -BasicSize * 2,
				VTTTokens.Green3 => -BasicSize * 3,
				VTTTokens.Green4 => -BasicSize * 4,
				VTTTokens.Green5 => -BasicSize * 5,
				VTTTokens.Green6 => -BasicSize * 6,
				VTTTokens.Green7 => -BasicSize * 0,
				VTTTokens.Green8 => -BasicSize * 1,
				VTTTokens.GreenBoss => -BasicSize * 2,
				VTTTokens.Cleric => -BasicSize * 3,
				VTTTokens.Druid => -BasicSize * 4,
				VTTTokens.Barbarian => -BasicSize * 5,
				//VTTTokens.Green6 => -BasicSize * 6,
				VTTTokens.Paladin => -BasicSize * 0,
				VTTTokens.Ranger => -BasicSize * 1,
				VTTTokens.Thief => -BasicSize * 2,
				VTTTokens.Fighter => -BasicSize * 3,
				VTTTokens.Bard => -BasicSize * 4,
				VTTTokens.Mage => -BasicSize * 5,
				VTTTokens.Wielder => -BasicSize * 6,
				//VTTTokens.Paladin => -BasicSize * 0,
				VTTTokens.Blue8 => -BasicSize * 1,
				VTTTokens.Blue7 => -BasicSize * 2,
				VTTTokens.Blue6 => -BasicSize * 3,
				VTTTokens.Blue5 => -BasicSize * 4,
				VTTTokens.Blue4 => -BasicSize * 5,
				VTTTokens.Blue3 => -BasicSize * 6,
				VTTTokens.Blue2 => -BasicSize * 0,
				VTTTokens.Blue1 => -BasicSize * 1,
				VTTTokens.BlueBoss => -BasicSize * 2,
				//VTTTokens.Blue6 => -BasicSize * 3,
				VTTTokens.Gold => -BasicSize * 4,
				VTTTokens.RedPotion => -BasicSize * 5,
				VTTTokens.GreenPotion => -BasicSize * 6,
				_ => 0
			};
		}
	}
	public int ImgY
	{
		get
		{
			return ID switch
			{
				VTTTokens.WhiteLady1 => -BasicSize * 0,
				VTTTokens.WhiteLady2 => -BasicSize * 0,
				VTTTokens.WhiteLady3 => -BasicSize * 0,
				VTTTokens.WhiteMale1 => -BasicSize * 0,
				VTTTokens.WhiteMale2 => -BasicSize * 0,
				VTTTokens.WhiteMale3 => -BasicSize * 0,
				VTTTokens.BoxGray => -BasicSize * 0,
				VTTTokens.BoxRed => -BasicSize * 1,
				VTTTokens.BoxBlue => -BasicSize * 1,
				VTTTokens.Black1 => -BasicSize * 1,
				VTTTokens.Black2 => -BasicSize * 1,
				VTTTokens.Black3 => -BasicSize * 1,
				VTTTokens.Black4 => -BasicSize * 1,
				VTTTokens.Black5 => -BasicSize * 1,
				VTTTokens.Black6 => -BasicSize * 2,
				VTTTokens.Black7 => -BasicSize * 2,
				VTTTokens.Black8 => -BasicSize * 2,
				VTTTokens.BlackBoss => -BasicSize * 2,

				VTTTokens.Red8 => -BasicSize * 2,
				VTTTokens.Red7 => -BasicSize * 2,
				VTTTokens.Red6 => -BasicSize * 3,
				VTTTokens.Red5 => -BasicSize * 3,
				VTTTokens.Red4 => -BasicSize * 3,
				VTTTokens.Red3 => -BasicSize * 3,
				VTTTokens.Red2 => -BasicSize * 3,
				VTTTokens.Red1 => -BasicSize * 3,
				VTTTokens.RedBoss => -BasicSize * 3,

				VTTTokens.Green1 => -BasicSize * 4,
				VTTTokens.Green2 => -BasicSize * 4,
				VTTTokens.Green3 => -BasicSize * 4,
				VTTTokens.Green4 => -BasicSize * 4,
				VTTTokens.Green5 => -BasicSize * 4,
				VTTTokens.Green6 => -BasicSize * 4,
				VTTTokens.Green7 => -BasicSize * 5,
				VTTTokens.Green8 => -BasicSize * 5,
				VTTTokens.GreenBoss => -BasicSize * 5,
				VTTTokens.Cleric => -BasicSize * 5,
				VTTTokens.Druid => -BasicSize * 5,
				VTTTokens.Barbarian => -BasicSize * 5,
				//VTTTokens.Green6 => -BasicSize * 6,
				VTTTokens.Paladin => -BasicSize * 6,
				VTTTokens.Ranger => -BasicSize * 6,
				VTTTokens.Thief => -BasicSize * 6,
				VTTTokens.Fighter => -BasicSize * 6,
				VTTTokens.Bard => -BasicSize * 6,
				VTTTokens.Mage => -BasicSize * 6,
				VTTTokens.Wielder => -BasicSize * 6,
				//VTTTokens.Paladin => -BasicSize * 0,
				VTTTokens.Blue8 => -BasicSize * 7,
				VTTTokens.Blue7 => -BasicSize * 7,
				VTTTokens.Blue6 => -BasicSize * 7,
				VTTTokens.Blue5 => -BasicSize * 7,
				VTTTokens.Blue4 => -BasicSize * 7,
				VTTTokens.Blue3 => -BasicSize * 7,
				VTTTokens.Blue2 => -BasicSize * 8,
				VTTTokens.Blue1 => -BasicSize * 8,
				VTTTokens.BlueBoss => -BasicSize * 8,
				//VTTTokens.Blue6 => -BasicSize * 3,
				VTTTokens.Gold => -BasicSize * 8,
				VTTTokens.RedPotion => -BasicSize * 8,
				VTTTokens.GreenPotion => -BasicSize * 8,
				_ => 0
			};
		}
	}

	public int X;
	public int Y;
}
