namespace AppBindingCommands;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        string informacoes = string.Empty;

        if (Preferences.ContainsKey("AcaoInicial"))
            informacoes += Preferences.Get("AcaoInicial", string.Empty);//string.empty --> valor default.

        if (Preferences.ContainsKey("AcaoStart"))
            informacoes += Preferences.Get("AcaoStart", string.Empty);

        if (Preferences.ContainsKey("AcaoSleep"))
            informacoes += Preferences.Get("AcaoSleep", string.Empty);

        if (Preferences.ContainsKey("AcaoResume"))
            informacoes += Preferences.Get("AcaoResume", string.Empty);

        lblInformacoes.Text = informacoes;
    }

    private void btnAtualizarInformacoes_Clicked(object sender, EventArgs e)
    {

    }
}

