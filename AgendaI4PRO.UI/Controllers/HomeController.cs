using AgendaI4PRO.Application.Services.Interfaces;
using AgendaI4PRO.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaI4PRO.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseService<Contato> _contatoService;
        private readonly IMapper _mapper;

        public HomeController(
            IBaseService<Contato> contatoService,
            IMapper mapper)
        {
            _contatoService = contatoService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var contatos = _contatoService.Obter();
            return View(contatos);
        }
    }
}
