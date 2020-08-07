using System.Collections.Generic;

namespace AgendaI4PRO.UI
{
    public class Feedback
    {
        public List<MensagemFeedback> Mensagens = new List<MensagemFeedback>();
    }

    public class MensagemFeedback
    {
        public MensagemFeedback(string classeCss, string conteudo)
        {
            ClasseCss = classeCss;
            Conteudo = conteudo;
        }

        public string ClasseCss { get; set; }

        public string Conteudo { get; set; }
    }
}
