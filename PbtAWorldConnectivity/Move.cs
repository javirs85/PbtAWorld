using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtAWorldConnectivity;


public class Move<M, S>
{
    public M Id { get; set; }
    public S Stat { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Trigger { get; set; } = string.Empty;

    public Move(M moveId, S statId)
    {
        Id = moveId;
        Stat = statId;
    }

    public Consequence On10 { get; set; }
    public Consequence On79 { get; set; }
    public Consequence On6 { get; set; }
    public string ClossingText { get; set;}
}

public class Consequence
{
    public string MainText { get; set; } = string.Empty;
    public List<string>? Options { get; set; } = null;
}
