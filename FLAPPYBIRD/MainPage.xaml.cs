using System.Runtime.CompilerServices;

namespace FLAPPYBIRD;

public partial class MainPage : ContentPage
{ 
	const int Gravidade =1 ;//px/ms
	const int TempoEntreFrames=25;//ms
	bool EstaMorto = false;
	double LarguraJanela = 0;
	double AlturaJanela = 0;
	int velocidade = 20;


	public MainPage()
	{
		InitializeComponent();
	}

void AplicaGravidade(){
    Passaro.TraslationY += Gravidade;
}

	public async void Desenha()
	{
		while (!EstaMorto)
		{
			AplicaGravidade();
			await Task.Delay(TempoEntreFrames);
			GerenciaCanos();
		}
	}
	protected override void OnAppearing()
{
    base.OnAppearing();
    Desenha();
}

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		LarguraJanela = w;
		AlturaJanela = h;
	}
	void GerenciaCanos()
	{
		imageCanoCima.TranslationX -= velocidade;
		imageCanoBaixo.TranslationX -= velocidade;
		if(imageCanoBaixo.Translation < -LarguraJanela)
		{
			imageCanoBaixo.TranslationX = 0;
			imageCanoCima.TranslationX = 0;
		}
	}
}
