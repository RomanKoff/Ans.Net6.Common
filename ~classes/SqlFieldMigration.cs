namespace Ans.Net6.Common
{

	public class SqlFieldMigration
	{

		public SqlField OldField { get; private set; }
		public SqlField NewField { get; private set; }
		public bool IsSetup { get; private set; }
		public string Value { get; private set; }


		public SqlFieldMigration(
			string definition)
		{
			if (definition[0] == '=')
			{
				this.IsSetup = true;
				var p1 = SuppString.GetPair(definition, ":");
				this.NewField = new SqlField(p1.Key[1..]);
				this.Value = p1.Value;
			}
			else
			{
				var p2 = SuppString.GetPair(definition, " > ");
				this.OldField = new SqlField(p2.Key);
				this.NewField = new SqlField(p2.Value);
			}
		}

	}

}
