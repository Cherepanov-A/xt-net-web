using Epam.XT2019.Task6.BLL;
using Epam.XT2019.Task6.LogicContracts;
using System;

namespace Epam.XT2019.Task6.Ioc
{
    public static class DependencyResolver
    {
		private static IUserLogic _uLogic;
		public static IUserLogic ULogic => _uLogic ?? (_uLogic = new UserLogic());	
	}
}
