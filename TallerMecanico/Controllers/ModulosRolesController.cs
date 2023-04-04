using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using TallerMecanico.Filters;
using TallerMecanico.Models.Domain.Entities;
using TallerMecanico.Models.Domain;
using TallerMecanico.Models.ViewModels;
using System.Linq;
using Mapster;

namespace TallerMecanico.Controllers
{
    public class ModulosRolesController : Controller
    {
        private readonly ILogger<ModulosRolesController> _logger;
        private TallerMecanicoDBContext _context;

        public ModulosRolesController(ILogger<ModulosRolesController> logger, TallerMecanicoDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [ClaimRequirement("ModulosRoles")]
        public IActionResult Index()
        {
            var ListaModulosRoles = _context.ModulosRoles.Where(w => w.Eliminado == false).ProjectToType<ModulosRolesVm>().ToList();
            return View(ListaModulosRoles);
        }
        [HttpGet]
        [ClaimRequirement("ModulosRoles")]
        public IActionResult Insertar()
        {
            var registro = new ModulosRolesVm();
            var listaModulos = _context.Modulo.Where(w => w.Eliminado == false).ProjectToType<ModuloVm>().ToList();
            List<SelectListItem> itemsModulos = listaModulos.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Nombre.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            var listaRoles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            List<SelectListItem> itemsRoles = listaRoles.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Descripcion.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            registro.Modulos = itemsModulos;
            registro.Roles = itemsRoles;
            return View(registro);
        }
        [HttpPost]
        [ClaimRequirement("ModulosRoles")]
        public IActionResult Insertar(ModulosRolesVm registro)
        {
            var listaModulos = _context.Modulo.Where(w => w.Eliminado == false).ProjectToType<ModuloVm>().ToList();
            List<SelectListItem> itemsModulos = listaModulos.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Nombre.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            var listaRoles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            List<SelectListItem> itemsRoles = listaRoles.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Descripcion.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            registro.Modulos = itemsModulos;
            registro.Roles = itemsRoles;
            var validacion = registro.Validar();
            TempData["Mensaje"] = validacion.Mensaje;
            if (!validacion.IsValid)
            {
                return View(registro);
            }
            var newEntidadRegistro = ModulosRoles.Create(
                registro.RolId,
                registro.ModuloId,
                registro.CreetedBy
            );

            _context.ModulosRoles.Add(newEntidadRegistro);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [ClaimRequirement("ModulosRoles")]
        public IActionResult Editar(Guid Id)
        {
            var registro = new ModulosRolesVm();
            var listaModulos = _context.Modulo.Where(w => w.Eliminado == false).ProjectToType<ModuloVm>().ToList();
            List<SelectListItem> itemsModulos = listaModulos.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Nombre.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            var listaRoles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            List<SelectListItem> itemsRoles = listaRoles.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Descripcion.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            registro.Modulos = itemsModulos;
            registro.Roles = itemsRoles;
            return View(registro);
        }
        [HttpPost]
        [ClaimRequirement("ModulosRoles")]
        public IActionResult Editar(ModulosRolesVm registro)
        {
            var listaModulos = _context.Modulo.Where(w => w.Eliminado == false).ProjectToType<ModuloVm>().ToList();
            List<SelectListItem> itemsModulos = listaModulos.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Nombre.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            var listaRoles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            List<SelectListItem> itemsRoles = listaRoles.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Descripcion.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            registro.Modulos = itemsModulos;
            registro.Roles = itemsRoles;
            var validacion = registro.Validar();
            TempData["Mensaje"] = validacion.Mensaje;
            if (!validacion.IsValid)
            {
                return View(registro);
            }
            var registroActual = _context.ModulosRoles.FirstOrDefault(w => w.Id == registro.Id);
            registroActual.Update(
                registro.RolId,
                registro.ModuloId,
                registro.CreetedBy
            );
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [ClaimRequirement("ModulosRoles")]
        public IActionResult Eliminar(Guid Id)
        {
            var registro = _context.ModulosRoles.Where(w => w.Id == Id && w.Eliminado == false).ProjectToType<ModulosRolesVm>().FirstOrDefault();

            return View(registro);
        }
        [HttpPost]
        [ClaimRequirement("ModulosRoles")]
        public IActionResult Eliminar(ModulosRolesVm registro)
        {
            var validacion = registro.ValidarEnDelete();
            TempData["Mensaje"] = validacion.Mensaje;
            if (!validacion.IsValid)
            {
                return View(registro);
            }

            var registroActual = _context.ModulosRoles.FirstOrDefault(w => w.Id == registro.Id);
            registroActual.Delete();
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
