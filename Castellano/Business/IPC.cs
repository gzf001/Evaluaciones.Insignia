using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class IPC
	{
		public static IPC GetAll(AnoMes anoMes)
		{
			return Query.GetIPCes().SingleOrDefault<IPC>(x => x.AnoMes == anoMes);
		}

		public static IPC Get(AnoMes anoMes)
		{
			return Query.GetIPCes().SingleOrDefault<IPC>(x => x.AnoMes == anoMes);
		}

		public static List<IPC> GetAll()
		{
			return
				(
				from query in Query.GetIPCes()
				select query
				).ToList<IPC>();
		}
	}
}