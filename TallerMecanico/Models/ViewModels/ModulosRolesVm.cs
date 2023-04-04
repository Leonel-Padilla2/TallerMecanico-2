using Examen.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using TallerMecanico.Models.Domain.Entities;

namespace TallerMecanico.Models.ViewModels
{
    public class ModulosRolesVm
    {
        public Rol Rol { get; set; }
        public Guid RolId { get; set; }
        public Guid ModuloId { get; set; }
        public Guid Id { get; set; }
        public bool Eliminado { get; set; }
        public Guid CreetedBy { get; set; }
        public Guid CreatedDate { get; set; }
        public ModuloVm Modulo { get; set; }
        public List<SelectListItem> Modulos { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public AppResultVm Validar()
        {
            AppResultVm app = new AppResultVm();

            if (this.RolId == Guid.Empty)
            {
                app.Mensaje += "El RolId no puede esta vacío \n";

            }
            if (this.ModuloId == Guid.Empty)
            {
                app.Mensaje += "El ModuloId no puede esta vacío \n";

            }
            if (string.IsNullOrEmpty(app.Mensaje))
            {
                app.IsValid = true;
                app.Mensaje = "ModulosRoles finalizado con éxito.";
            }
            else
            {
                app.IsValid = false;
            }
            return app;
        }

        public AppResultVm ValidarEnUpdate()
        {
            AppResultVm app = new AppResultVm();

            if (this.RolId == Guid.Empty)
            {
                app.Mensaje += "El RolId no puede esta vacío \n";

            }
            if (this.ModuloId == Guid.Empty)
            {
                app.Mensaje += "El ModuloId no puede esta vacío \n";

            }
            if (this.Id == Guid.Empty)
            {
                app.Mensaje += "El Id no puede esta vacío \n";

            }
            if (string.IsNullOrEmpty(app.Mensaje))
            {
                app.IsValid = true;
                app.Mensaje = "ModulosRoles finalizado con éxito.";
            }
            else
            {
                app.IsValid = false;
            }
            return app;
        }

        public AppResultVm ValidarEnDelete()
        {
            AppResultVm app = new AppResultVm();

            if (this.Id == Guid.Empty)
            {
                app.Mensaje += "El Id no puede esta vacío \n";

            }
            if (string.IsNullOrEmpty(app.Mensaje))
            {
                app.IsValid = true;
                app.Mensaje = "ModulosRoles eliminado con éxito.";
            }
            else
            {
                app.IsValid = false;
            }

            return app;
        }
    }
}
