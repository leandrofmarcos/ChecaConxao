using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChecaConexao.ViewModel;
using Xamarin.Forms;

namespace ChecaConexao
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();

      this.BindingContext = new MainViewModel();
    }
  }
}
