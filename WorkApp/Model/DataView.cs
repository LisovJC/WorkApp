using WorkApp.Core;

namespace WorkApp.Model
{
    internal class DataView : ObservableObject
    {
		private string? _category;

		public string? Category
		{
			get => _category; 
			set => Set(ref _category, value); 
		}

        private string? _name;

        public string? Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private string? _price;

        public string? Price
        {
            get => _price;
            set => Set(ref _price, value);
        }

    }
}
