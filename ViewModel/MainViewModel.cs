using Ausbildungsprojekt_SW_01.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ausbildungsprojekt_SW_01.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string verzeichnis;
        private string dateiendung;
        private string[] dateien;

        public string Verzeichnis
        {
            get { return verzeichnis; }
            set
            {
                verzeichnis = value;
                OnPropertyChanged();
            }
        }

        public string Dateiendung
        {
            get { return dateiendung; }
            set
            {
                dateiendung = value;
                OnPropertyChanged();
            }
        }

        public string[] Dateien
        {
            get { return dateien; }
            set
            {
                dateien = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SuchenCommand { get; private set; }

        public MainWindowViewModel()
        {
            SuchenCommand = new RelayCommand(Suchen, CanSuchen);
        }

        public bool CanSuchen()
        {
            return !string.IsNullOrWhiteSpace(Verzeichnis) && !string.IsNullOrWhiteSpace(Dateiendung);
        }
        public void Suchen()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Verzeichnis) && !string.IsNullOrWhiteSpace(Dateiendung))
                {
                    var model = new Dateisucher();
                    Dateien = model.Suchen(Verzeichnis, Dateiendung);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle unauthorized access exception
            }
            catch (Exception ex)
            {
                // Handle other exceptions
            }
        }

    }
}
