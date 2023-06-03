using System;
namespace Project777.Shared.Exceptions
{
	public class NotFoundException : Exception
	{	
		public NotFoundException (string message) : base(message){}
	}
}

