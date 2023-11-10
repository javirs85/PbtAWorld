namespace PbtALib;

public class PbtACharacter
{
	public event EventHandler UpdateUI;
	public void OnUpdateUI()=>UpdateUI?.Invoke(this, EventArgs.Empty);

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

	public virtual int GetBonus<T>(T stat){
		throw new NotImplementedException();
	}

	public string SerializedData { get; set; } = string.Empty;

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


