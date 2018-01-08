namespace CameraBazaar.Web.Models.Pagination
{
	public class PaginationViewModel
    {
		public int CurrentPage { get; set; }

		public int TotalPages { get; set; }

		public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;

		public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;
	}
}
