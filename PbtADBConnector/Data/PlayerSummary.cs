using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtADBConnector.Data;

public class PlayerSummary
{
	public string Name { get; set; } = string.Empty;
	public Guid CampaignID { get; set; }
	public byte ClassCode { get; set; }
	public byte GameCode { get; set; }
	public Guid Guid { get; set; }
}