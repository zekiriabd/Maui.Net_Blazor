using CommunityToolkit.Maui.Views;

namespace PopUp;

public partial class MyAlert : Popup
{
    public string Response { get; set; }
    public MyAlert()
	{
		InitializeComponent();
        BindingContext= this;
	}

    private void BtnNo_Clicked(object sender, EventArgs e)
    {
        Close(Response);
    }

    private void BtnYes_Clicked(object sender, EventArgs e)
    {
        Close(true);
    }
}