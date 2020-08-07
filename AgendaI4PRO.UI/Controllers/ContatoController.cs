using AgendaI4PRO.Application.Services.Interfaces;
using AgendaI4PRO.Application.Validation.Validators;
using AgendaI4PRO.Domain.Models;
using AgendaI4PRO.UI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace AgendaI4PRO.UI.Controllers
{
    public class ContatoController : BaseController
    {
        private readonly IBaseService<Contato> _contatoService;

        public ContatoController(IBaseService<Contato> contatoService)
        {
            _contatoService = contatoService;
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Contato contato)
        {
            var validacao = Validar(new ContatoValidator(), contato);
            var feedback = new Feedback();

            if (validacao.IsValid)
            {
                _contatoService.Inserir(contato);

                feedback.Mensagens.Add(new MensagemFeedback("success", "Contato cadastrado com sucesso"));
                TempData["Feedback"] = JsonConvert.SerializeObject(feedback);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                feedback.Mensagens = validacao.Errors.Select(e => new MensagemFeedback("danger", e.ErrorMessage)).ToList();
                TempData["Feedback"] = JsonConvert.SerializeObject(feedback);
                return View(contato);
            }
        }

        public ActionResult Remover(int id)
        {
            _contatoService.Remover(new Contato { Id = id });

            return RedirectToAction("Index", "Home");
        }
    }
}
