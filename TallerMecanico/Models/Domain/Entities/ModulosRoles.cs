using System;

namespace TallerMecanico.Models.Domain.Entities
{
    public class ModulosRoles
    {
        public Rol Rol { get; set; }
        public Guid RolId { get; set; }
        public Modulo Modulo { get; set; }
        public Guid ModuloId { get; set; }
        public Guid Id { get; set; }
        public bool Eliminado { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public static ModulosRoles Create(Guid rolId, Guid moduloId, Guid CreatedBy)
        {
            return new ModulosRoles
            {
                Id = Guid.NewGuid(),
                RolId = rolId,
                ModuloId = moduloId,
                CreatedBy = CreatedBy
            };
        }
        public void Update(Guid rolId, Guid moduloId, Guid CreatedBy)
        {
            {
                this.RolId = rolId;
                this.ModuloId = moduloId;
                this.CreatedBy = CreatedBy;

            };
        }
        public void Delete()
        {
            this.Eliminado = true;
        }
    }
}

