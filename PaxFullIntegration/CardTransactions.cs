using System.Diagnostics;
using System.Text.Json;
using POSLinkAdmin;
using POSLinkAdmin.Const;
using POSLinkAdmin.Util;
using POSLinkFullIntegration;
using POSLinkFullIntegration.FullIntegration;

namespace PaxFullIntegration
{
    internal class CardTransactions : BaseTransaction
    {
        public void TokeniseCard()
        {
            Terminal terminal = getTerminal().Result;
            if (terminal != null)
            {
                terminal.Manage.SetVariable(new POSLinkAdmin.Manage.SetVariableRequest(), out SetVariableResponse())
            }
        }

        public void Sale(decimal amount)
        {
            try
            {
                var pos = getTerminal().Result;

                var request = new InputAccountWithEmvRequest
                {
                    EdcType = EdcType.Credit,
                    TransactionType = TransactionType.Sale,
                    AmountInformation = new AmountRequest
                    {
                        TransactionAmount = ((int)(amount * 100)).ToString()
                    },
                    //EntryMode = EntryMode.NotSet, // terminal decides
                    StatusReportFlag = StatusReportFlag.ToReport
                };

                var result = pos.FullIntegration.InputAccountWithEmv(request, out var response);

                if (result.GetErrorCode() == ExecutionResult.Code.Ok)
                {
                    string jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });
                    Debug.WriteLine("Sale Success: {0}", jsonResponse);
                }
                else
                {
                    string errorResponse = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
                    Debug.WriteLine("Sale Failed: {0}", errorResponse);
                }
            }
            catch (Exception ex)
            {
                string execptionResponse = JsonSerializer.Serialize(ex, new JsonSerializerOptions { WriteIndented = true });
                Debug.WriteLine("Exception: {0}", ex);
            }
        }
    }
}
