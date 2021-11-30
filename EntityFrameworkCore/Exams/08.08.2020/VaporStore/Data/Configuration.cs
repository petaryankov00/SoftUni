namespace VaporStore.Data
{
	public static class Configuration
	{
		public static string ConnectionString =
			@"Server=MPC-1\SQLEXPRESS;Database=VaporStore;User Id = sa;Password = 1916";

		public static string ErrorMessage =
			"Invalid Data";

		public static string SuccesfullMessage =
			"Added {0} ({1}) with {2} tags";

		public static string SuccesfullUser =
			"Imported {0} with {1} cards";
	}
}