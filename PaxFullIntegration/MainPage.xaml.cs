namespace PaxFullIntegration
{
    public partial class MainPage : ContentPage
    {
        private POSLinkCore.CommunicationSetting.CommunicationSetting commSetting = null;
        private POSLinkCore.LogSetting logSetting = null;
        private string log = "";
        public MainPage()
        {
            InitializeComponent();
            ipStackLayout.IsVisible = true;
            portStackLayout.IsVisible = true;
            timeoutStackLayout.IsVisible = true;
            serialPortStackLayout.IsVisible = false;
            baudrateStackLayout.IsVisible = false;
            resCodeEntry.Text = "";
            resMsgEntry.Text = "";
        }
        private async void OnTokenCard(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(async () =>
            {
                
            });
            thread1.Start();
        }
        private void OnDoCreditClicked(object sender, EventArgs e)
        {
            
        }
        private async void OnAdjustTipClicked(object sender, EventArgs e)
        {
            
        }


        private async void OnDeleteBtnClicked(object sender, EventArgs e)
        {
           
        }

        private async void OnVoidBtnClicked(object sender, EventArgs e)
        {
            
        }

        private async void OnRefundBtnClicked(object sender, EventArgs e)
        {
            
        }

        private async void OnPartialBtnClicked(object sender, EventArgs e)
        {
           
        }


        private void CommSettingChanged(object sender, EventArgs e)
        {
            if (commSettingEntry.Text.Trim().ToUpper() == "TCP")
            {
                ipStackLayout.IsVisible = true;
                portStackLayout.IsVisible = true;
                timeoutStackLayout.IsVisible = true;
                serialPortStackLayout.IsVisible = false;
                baudrateStackLayout.IsVisible = false;
                resCodeEntry.Text = "";
                resMsgEntry.Text = "";
            }
            else if (commSettingEntry.Text.Trim().ToUpper() == "HTTP")
            {
                ipStackLayout.IsVisible = true;
                portStackLayout.IsVisible = true;
                timeoutStackLayout.IsVisible = true;
                serialPortStackLayout.IsVisible = false;
                baudrateStackLayout.IsVisible = false;
                resCodeEntry.Text = "";
                resMsgEntry.Text = "";
            }
            else if (commSettingEntry.Text.Trim().ToUpper() == "SSL")
            {
                ipStackLayout.IsVisible = true;
                portStackLayout.IsVisible = true;
                timeoutStackLayout.IsVisible = true;
                serialPortStackLayout.IsVisible = false;
                baudrateStackLayout.IsVisible = false;
                resCodeEntry.Text = "";
                resMsgEntry.Text = "";
            }
            else if (commSettingEntry.Text.Trim().ToUpper() == "AIDL")
            {
                ipStackLayout.IsVisible = false;
                portStackLayout.IsVisible = false;
                serialPortStackLayout.IsVisible = false;
                baudrateStackLayout.IsVisible = false;
                timeoutStackLayout.IsVisible = false;
                resCodeEntry.Text = "";
                resMsgEntry.Text = "";
            }
            else if (commSettingEntry.Text.Trim().ToUpper() == "UART")
            {
                serialPortStackLayout.IsVisible = true;
                baudrateStackLayout.IsVisible = true;
                timeoutStackLayout.IsVisible = true;
                ipStackLayout.IsVisible = false;
                portStackLayout.IsVisible = false;
                resCodeEntry.Text = "";
                resMsgEntry.Text = "";
            }
            else
            {
                ipStackLayout.IsVisible = false;
                portStackLayout.IsVisible = false;
                serialPortStackLayout.IsVisible = false;
                baudrateStackLayout.IsVisible = false;
                timeoutStackLayout.IsVisible = false;
            }
        }
    }
}
