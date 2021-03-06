namespace Ans.Net6.Common
{

	public class TinyBreaker
	{
		public int Step { get; private set; }
		public int Current { get; private set; }

		public TinyBreaker(
			int step)
		{
			Step = step;
			Current = 0;
		}

		public TinyBreaker()
			: this(1234)
		{
		}

		public bool Next()
		{
			if (Current++ != Step)
				return false;
			Current = 0;
			return true;
		}
	}

}
