namespace PbtALib;

public class PbtACharacter
{
	private Guid _id = Guid.NewGuid();

	public Guid ID
	{
		get { return _id; }
		set { _id = value; }
	}

	public byte EncodedClass { get; set; }

	private string _name = "Escoge un nombre";

	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}

	public virtual int GetStatBonus<T>(T stat){
		throw new NotImplementedException();
	}

	public string SerializedData { get; set; } = string.Empty;

}


