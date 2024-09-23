namespace Trabalho_Linguagem_Programacao_.NET.Models
{
    public class ErrorViewModel
    {
        private string requestId;

        public string RequestId { get => requestId; set => requestId = value; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
