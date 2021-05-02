using Microsoft.AspNetCore.Components;

namespace ProjectBlazor.Data
{
	public class HelperService
	{
		private NavigationManager _navigationManager;
		public HelperService(NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
		}

		public void ChangePage(string path)
		{
			_navigationManager.NavigateTo(path);
			//_navigationManager.NavigateTo("/test");
		}
	}
}
