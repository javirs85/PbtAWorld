using PbtALib;
using System.Reflection.Metadata.Ecma335;

namespace UrbanShadows;

public class LIO : IMove
{
	public string Text { get; set; } = "";
	public USMoveIDs ID { get; set; }
	public US_Classes Archetype { get; set; }
    public bool IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Title { get => Text; set => Text = value; }
    public Consequences PreCondition { get => new Consequences { MainText = Text }; set => throw new NotImplementedException(); }
    public Consequences ConsequencesOn79 { get => null; set => throw new NotImplementedException(); }
    public Consequences ConsequencesOn10 { get => null; set => throw new NotImplementedException(); }
    public Consequences ConsequencesOn6 { get => null; set => throw new NotImplementedException(); }
    public Consequences AdvancedConsequences { get => null; set => throw new NotImplementedException(); }

    public string IDText => ID.ToString() ?? "ID not set";

    public string ClosingText { get => ""; set => throw new NotImplementedException(); }
    public int NumUsedTimes { get => 0; set => throw new NotImplementedException(); }

    public HowOftenUsed HowOften => HowOftenUsed.NeverUsed;

    public bool IsImproved { get => false; set => throw new NotImplementedException(); }

    public void AddIDToList<T>(List<T> list)
    {
        throw new NotImplementedException();
    }

    public bool HasRoll()
    {
        return false;
    }

    public bool IsInList<T>(IEnumerable<T> list)
    {
        throw new NotImplementedException();
    }

    public void RemoveIDFromList<T>(List<T> list)
    {
        throw new NotImplementedException();
    }

    public string ToUI()
    {
        throw new NotImplementedException();
    }
}

public class USMove : PbtALib.BaseMove<USMoveIDs, USAttributes>
{
	public USMove(USMoveIDs IDs, USAttributes roll) : base(IDs, roll)
	{
		Title = "Not Set";
	}
    public bool IsImprovedByOtherMove { get; set; } = false;
	public override bool HasRoll() => Roll != USAttributes.None;
	public override string ToUI() => Roll.ToUI();

	/*****/

	public bool CanBeRolledAutomatically => Roll != USAttributes.None && Roll != USAttributes.Circle && Roll != USAttributes.Status;
	public bool TicksCircle { get; set; } = false;
	public bool IsSelected { get; set; } = false;
	public bool IsImproved { get; set; } = false;
	public MovementTypes TypeOfMovement = MovementTypes.NotSet;
	public US_Classes Archetipe = US_Classes.All;

	protected override void CopyContentFromInternal<M>(M move)
	{
        var m = move as USMove;
        if(m is not null)
        {
			this.TicksCircle = m.TicksCircle;
			this.IsImproved = m.IsImproved;
			this.TypeOfMovement = m.TypeOfMovement;
			this.Archetipe = m.Archetipe;
		}
	}
}
