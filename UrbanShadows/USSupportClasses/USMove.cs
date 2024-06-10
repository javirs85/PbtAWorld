namespace UrbanShadows;

public class LIO
{
	public string Text { get; set; } = "";
	public USMoveIDs ID { get; set; }
	public AvailableArchetypes Archetype { get; set; }

}

public class USMove : PbtALib.BaseMove<USMoveIDs, USAttributes>
{
	public USMove(USMoveIDs IDs, USAttributes roll) : base(IDs, roll)
	{
		Title = "Not Set";
	}

	public override bool HasRoll() => Roll != USAttributes.None;
	public override string ToUI() => Roll.ToUI();

	/*****/

	public bool CanBeRolledAutomatically => Roll != USAttributes.None && Roll != USAttributes.Circle && Roll != USAttributes.Status;
	public bool TicksCircle { get; set; } = false;
	public bool IsSelected { get; set; } = false;
	public bool IsImproved { get; set; } = false;
	public MovementTypes TypeOfMovement = MovementTypes.NotSet;
	public AvailableArchetypes Archetipe = AvailableArchetypes.All;
}
