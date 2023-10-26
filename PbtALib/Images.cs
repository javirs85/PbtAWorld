using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class PbtAImagesManager
{
    public List<PbtAImage> Images { get; set; } = new();
}

public class PbtAImage
{
    public string Name { get; set; } = string.Empty;
    public string src { get; set; } = string.Empty;
}
