using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScumAndVillainy;

public class SVCharacter : PbtALib.PbtACharacter
{
	public SVClasses Profession { get; set; } = SVClasses.NotSet;
}
