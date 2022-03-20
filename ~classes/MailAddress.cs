namespace Ans.Net6.Common
{

	public class MailAddress
	{
		public string Title { get; set; }
		public string Address { get; set; }

		public MailAddress()
		{
		}

		public MailAddress(
			string title,
			string address)
			: this()
		{
			this.Title = title;
			this.Address = address;
		}

		public MailAddress(
			string address)
			: this(null, address)
		{
		}
	}

}
