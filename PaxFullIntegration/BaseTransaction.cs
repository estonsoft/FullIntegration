using System.Diagnostics;
using System.Text.Json;
using POSLinkAdmin;
using POSLinkAdmin.Manage;
using POSLinkFullIntegration;

namespace PaxFullIntegration
{
    class BaseTransaction
    {
        private POSLinkCore.CommunicationSetting.CommunicationSetting commSetting = null;
        private POSLinkCore.LogSetting logSetting = null;
        protected string? commSettingName;
        protected string? ipAddress;
        protected string? portAddress;
        protected string? timeoutValue;
        protected string? baudrateValue;
        protected string? serialPort;
        public readonly static string SUCCESS = "200";

        //protected BaseTransactions() { }
        protected async Task<Terminal> getTerminal()
        {
            POSLinkFull poslinkSemi = POSLinkFull.GetPOSLinkFull();
            Terminal terminal = poslinkSemi.GetTerminal(commSetting);
            poslinkSemi.SetLogSetting(logSetting);
            return terminal;
        }

        public async Task<string> GetDeviceDetails()
        {
            Initialise();
            InitResponse initResponse = null;
            ExecutionResult result = getTerminal().Result.Manage.Init(out initResponse);
            
            string jsonResponse = JsonSerializer.Serialize(initResponse, new JsonSerializerOptions { WriteIndented = true });
            Debug.WriteLine("Device Detaills" + jsonResponse);
            return jsonResponse;
        }

        protected async Task<String> Initialise()
        {
            logSetting = new POSLinkCore.LogSetting();
#if ANDROID
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (status == PermissionStatus.Denied)
            {
                status = await Permissions.RequestAsync<Permissions.StorageWrite>();
            }

            logSetting.FilePath = Android.OS.Environment.ExternalStorageDirectory.Path;
#endif

            if (commSettingName.ToUpper() == "TCP")
            {
                POSLinkCore.CommunicationSetting.TcpSetting tcpSetting = new POSLinkCore.CommunicationSetting.TcpSetting();
                tcpSetting.Ip = ipAddress;
                int port;
                bool isPortNum = Int32.TryParse(portAddress, out port);
                if (isPortNum)
                {
                    tcpSetting.Port = port;
                }
                int timeout;
                bool isTimeoutNum = Int32.TryParse(timeoutValue, out timeout);
                if (isTimeoutNum)
                {
                    tcpSetting.Timeout = timeout;
                }
                commSetting = tcpSetting;
            }
            else if (commSettingName.ToUpper() == "HTTP")
            {
                POSLinkCore.CommunicationSetting.HttpSetting tcpSetting = new POSLinkCore.CommunicationSetting.HttpSetting();
                tcpSetting.Ip = ipAddress;
                int port;
                bool isPortNum = Int32.TryParse(portAddress, out port);
                if (isPortNum)
                {
                    tcpSetting.Port = port;
                }
                int timeout;
                bool isTimeoutNum = Int32.TryParse(timeoutValue, out timeout);
                if (isTimeoutNum)
                {
                    tcpSetting.Timeout = timeout;
                }
                commSetting = tcpSetting;
            }
            else if (commSettingName.ToUpper() == "SSL")
            {
                POSLinkCore.CommunicationSetting.SslSetting sslSetting = new POSLinkCore.CommunicationSetting.SslSetting();
                sslSetting.Ip = ipAddress;
                int port;
                bool isPortNum = Int32.TryParse(portAddress, out port);
                if (isPortNum)
                {
                    sslSetting.Port = port;
                }
                int timeout;
                bool isTimeoutNum = Int32.TryParse(timeoutValue, out timeout);
                if (isTimeoutNum)
                {
                    sslSetting.Timeout = timeout;
                }
                commSetting = sslSetting;
            }            
            else
            {
                return "Not support.";
            }
            return SUCCESS;
        }
    }
}
