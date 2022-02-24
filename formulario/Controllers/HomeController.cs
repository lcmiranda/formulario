using formulario.Data;
using formulario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace formulario.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Context db)
        {
            _logger = logger;
            _db = db;
        }

        //[HttpGet]
        public IActionResult Index()
        {
            try
            {
                List<BaseForms> dados = _db.formulario.ToList<BaseForms>();
            }
            catch (Exception e)
            {
                ViewBag.table = false;
            }
            

            return View( new BaseForms());
        }

        [HttpPost]
        public IActionResult Index(BaseForms form)
        {
            TabelaHorario segunda = new TabelaHorario();
            TabelaHorario terca = new TabelaHorario();
            TabelaHorario quarta = new TabelaHorario();
            TabelaHorario quinta = new TabelaHorario();
            TabelaHorario sexta = new TabelaHorario();
            List<TabelaHorario> lista = new List<TabelaHorario>();

            try
            {
                _db.formulario.Add(form);
                _db.SaveChanges();

                var entity_query = _db.formulario.OrderByDescending(forms => forms.cpf == form.cpf
                && forms.email == form.email).FirstOrDefault();

                segunda.id = 0;
                segunda.id_forms = entity_query.id;
                segunda.dia = form.segunda; 
                segunda.h_inicio = form.segundaIni;
                segunda.h_fim = form.segundaFim; 
                segunda.h_descanso = form.segundaDec;
                segunda.carga_h = form.segundaCarga;

                terca.id = 0;
                terca.id_forms = entity_query.id;
                terca.dia = form.terca; 
                terca.h_inicio = form.tercaIni;
                terca.h_fim = form.tercaFim; 
                terca.h_descanso = form.tercaDec;
                terca.carga_h = form.tercaCarga;

                quarta.id = 0;
                quarta.id_forms = entity_query.id;
                quarta.dia = form.quarta; 
                quarta.h_inicio = form.quartaIni;
                quarta.h_fim = form.quartaFim; 
                quarta.h_descanso = form.quartaDec;
                quarta.carga_h = form.quartaCarga;

                quinta.id = 0;
                quinta.id_forms = entity_query.id;
                quinta.dia = form.quinta;
                quinta.h_inicio = form.quintaIni;
                quinta.h_fim = form.quintaFim;
                quinta.h_descanso = form.quintaDec;
                quinta.carga_h = form.quintaCarga;

                sexta.id = 0;
                sexta.id_forms = entity_query.id;
                sexta.dia = form.sexta; 
                sexta.h_inicio = form.sextaIni;
                sexta.h_fim = form.sextaFim; 
                sexta.h_descanso = form.sextaDec;
                sexta.carga_h = form.sextaCarga;

                lista.Add(segunda);
                lista.Add(terca);
                lista.Add(quarta);
                lista.Add(quinta);
                lista.Add(sexta);

                foreach (var list in lista)
                {
                    _db.tabHora.Add(list);
                    _db.SaveChanges();
                }
                

                ViewBag.cadastrado = true;
            }
            catch(Exception e)
            {
                ViewBag.cadastrado = false;
            }
            
            return View();
        }


        public IActionResult Cadastro()
        {
            List<BaseForms> dados = _db.formulario.ToList<BaseForms>();
            ViewBag.listForms = dados;
            return View();
        }


        public IActionResult DeletarCad(int id)
        {

            try
            {
                var form = _db.formulario.First(c => c.id == id);
                _db.Remove(form);

                var datas = _db.tabHora.Where(c => c.id_forms == id).ToList<TabelaHorario>();
                _db.RemoveRange(datas);

                _db.SaveChanges();

                ViewBag.cadastrado = true;
            }
            catch(Exception e)
            {
                ViewBag.cadastrado = false;
            }

            return RedirectToAction(nameof(Cadastro));
        }


        public IActionResult EditarForm(int id)
        {

            try
            {
                ViewBag.formulario = _db.formulario.First(c => c.id == id);

                ViewBag.datas = _db.tabHora.Where(c => c.id_forms == id).ToList<TabelaHorario>();

                ViewBag.carga = 0;
                foreach( var date  in ViewBag.datas)
                {
                    ViewBag.carga = ViewBag.carga + date.carga_h;
                }


            }
            catch (Exception e)
            {

            }

            return View(); 
        }


        public IActionResult EditarForms(BaseForms form)
        {
            TabelaHorario segunda = new TabelaHorario();
            TabelaHorario terca = new TabelaHorario();
            TabelaHorario quarta = new TabelaHorario();
            TabelaHorario quinta = new TabelaHorario();
            TabelaHorario sexta = new TabelaHorario();
            List<TabelaHorario> lista = new List<TabelaHorario>();

            try
            {

                var entity_query = _db.formulario.OrderByDescending(forms => forms.cpf == form.cpf
                && forms.email == form.email).FirstOrDefault();

                _db.Entry(entity_query).CurrentValues.SetValues(form);
                _db.SaveChanges();


                segunda.id = form.idSeg;
                segunda.id_forms = entity_query.id;
                segunda.dia = form.segunda;
                segunda.h_inicio = form.segundaIni;
                segunda.h_fim = form.segundaFim;
                segunda.h_descanso = form.segundaDec;
                segunda.carga_h = form.segundaCarga;

                terca.id = form.idTer;
                terca.id_forms = entity_query.id;
                terca.dia = form.terca;
                terca.h_inicio = form.tercaIni;
                terca.h_fim = form.tercaFim;
                terca.h_descanso = form.tercaDec;
                terca.carga_h = form.tercaCarga;

                quarta.id = form.idQuart;
                quarta.id_forms = entity_query.id;
                quarta.dia = form.quarta;
                quarta.h_inicio = form.quartaIni;
                quarta.h_fim = form.quartaFim;
                quarta.h_descanso = form.quartaDec;
                quarta.carga_h = form.quartaCarga;

                quinta.id = form.idQuint;
                quinta.id_forms = entity_query.id;
                quinta.dia = form.quinta;
                quinta.h_inicio = form.quintaIni;
                quinta.h_fim = form.quintaFim;
                quinta.h_descanso = form.quintaDec;
                quinta.carga_h = form.quintaCarga;

                sexta.id = form.idSext;
                sexta.id_forms = entity_query.id;
                sexta.dia = form.sexta;
                sexta.h_inicio = form.sextaIni;
                sexta.h_fim = form.sextaFim;
                sexta.h_descanso = form.sextaDec;
                sexta.carga_h = form.sextaCarga;

                lista.Add(segunda);
                lista.Add(terca);
                lista.Add(quarta);
                lista.Add(quinta);
                lista.Add(sexta);

                foreach (var list in lista)
                {
                   var date = _db.tabHora.Where(a => a.id == list.id).FirstOrDefault(); 
                    _db.Entry(date).CurrentValues.SetValues(list);
                    _db.SaveChanges();
                }


                ViewBag.cadastrado = true;
            }
            catch (Exception e)
            {
                ViewBag.cadastrado = false;
            }

            return RedirectToAction(nameof(Cadastro));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
