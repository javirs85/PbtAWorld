using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class Tag
{
    public Tag()
    {
        
    }
    public Tag(BaseTextBook.TagIDs tag, string title, string desc)
    {
        ID = tag;
        Tittle = title;
        Description = desc;
    }
    public BaseTextBook.TagIDs ID { get; set; }
    public string Tittle { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
}
