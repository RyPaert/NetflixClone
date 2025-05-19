using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NetflixCloneMAUI.ViewModels
{
    public partial class CategoriesViewModel : ObservableObject
    {
        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<string>(
                new string[] { "My List", "Downloads" });
        }
        public ObservableCollection<string> Categories { get; set; }

        public async Task InitializeAsync()
        {

        }
    }
}
