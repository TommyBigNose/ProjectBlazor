namespace ProjectBlazor.Data.Game.Exception
{
	public class PbException : System.Exception
	{
		public PbException()
		{
		}

		public PbException(string message)
			: base(message)
		{
		}

		public PbException(string message, System.Exception inner)
			: base(message, inner)
		{
		}
	}
}
