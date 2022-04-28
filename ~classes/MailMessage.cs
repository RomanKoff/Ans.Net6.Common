namespace Ans.Net6.Common
{

	public class MailMessage
	{
		public MailAddress From { get; set; }
		public MailAddress To { get; set; }
		public List<MailAddress> Cc { get; set; }
		public List<MailAddress> Bcc { get; set; }
		public string Subject { get; set; }
		public string ContentHtml { get; set; }
	}

}
