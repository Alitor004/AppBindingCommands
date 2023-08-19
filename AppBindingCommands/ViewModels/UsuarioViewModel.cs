using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppBindingCommands.ViewModels
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string name = string.Empty;//CTRL + R, E

        public string Name
        {
            get => name;
            set
            {
                if (name == null)
                    return;

                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName => $"Nome digitado: {Name}";

        public async Task CountCharacters()
        {
            string nameLenght = string.Format("Seu nome tem {0} Letras", name.Length);
            await Application.Current.MainPage.DisplayAlert("Informação", nameLenght, "Ok");
        }

        public ICommand CountCommand { get; }

        public UsuarioViewModel()
        {
            ShowMenssageCommand = new Command(ShowMenssage);
            CountCommand = new Command(async() => await CountCharacters());
            CleanCommand = new Command(async() => await CleanConfirmation());
            OptionCommand = new Command(async() => await ShowOptions());
        }

        public async Task CleanConfirmation()
        {
            if (await Application.Current.MainPage.DisplayAlert("Confirmação", "Confirma limpeza dos dados?", "Yes", "No"))
            {
                Name = string.Empty;
                DisplayMenssage = String.Empty;
                OnPropertyChanged(Name);
                OnPropertyChanged(DisplayMenssage);

                await Application.Current.MainPage.DisplayAlert("Informação", "Limpeza realizada com suceso", "Ok");            }
        }

        public ICommand CleanCommand { get; }

        public async Task ShowOptions()
        {
            string result = await Application.Current.MainPage
                .DisplayActionSheet("Selecione uma opção: ", "",
                "Cancelar", "Limpar", "Contar Caracteres", "Exibir Saudação");

            if (result != null)
            {
                if (result.Equals("Limpar"))
                    await CleanConfirmation();
                if (result.Equals("Contar Caracteres"))
                    await CountCharacters();
                if (result.Equals("Exibir Saudação"))
                    ShowMenssage();
            }
        }

        public ICommand OptionCommand { get; }
    }
}
