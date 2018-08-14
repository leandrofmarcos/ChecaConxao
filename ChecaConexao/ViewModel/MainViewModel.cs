using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;

namespace ChecaConexao.ViewModel
{
  public class MainViewModel : INotifyPropertyChanged
  {

    private NetworkAccess current;

    #region Declaração das propriedades para uso na MainPage.xaml

    private string _icon;
    public string Icon
    {
      get => _icon;
      set
      {
        _icon = value;
        OnPropertyChanged();
      }
    }

    private string _msg;
    public string Msg
    {
      get => _msg;
      set
      {
        _msg = value;
        OnPropertyChanged();
      }
    }

    private string _cor;
    public string Cor
    {
      get => _cor;
      set
      {
        _cor = value;
        OnPropertyChanged();
      }
    }

    private string _tipo;
    public string Tipo
    {
      get => _tipo;
      set
      {
        _tipo = value;
        OnPropertyChanged();
      }
    }

    private bool _onLine;
    public bool OnLine
    {
      get => _onLine;
      set
      {
        _onLine = value;
        OnPropertyChanged();
      }
    }
    #endregion



    public MainViewModel()
    {
      ChecaStatusInicial();
      ChecandoStatus();
    }

    public void ChecaStatusInicial()
    {
      ManipulaStatus();
    }

    public void ChecandoStatus()
    {
      Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
    }


    //Evento para manipulação da mudança de status quando ocorrer
    void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
      ManipulaStatus();
    }

    private void ManipulaStatus()
    {
      current = Connectivity.NetworkAccess;

      Icon = current == NetworkAccess.Internet ? "online.png" : "offline.png";
      Msg = current == NetworkAccess.Internet ? "OnLine" : "OffLine";
      Cor = current == NetworkAccess.Internet ? "Green" : "Red";
      OnLine = current == NetworkAccess.Internet;

      var networkProfiles = Connectivity.Profiles;

      if (networkProfiles.Contains(ConnectionProfile.Cellular))
      {
        Tipo = "Celular";
      }

      if (networkProfiles.Contains(ConnectionProfile.WiFi))
      {
        Tipo = "WiFi";
      }

    }


    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
