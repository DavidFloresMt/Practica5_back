using AutoMapper;
using Ejercicio5_back.DTO;
using Ejercicio5_back.Models;

namespace Ejercicio5_back.Servicios
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            /*CreateMap<Empleado, EmpleadoInsertDTO>()
                .ForMember(ent => ent.Id, dto => dto.MapFrom(campo => campo.IdEstadoNavigation.Select(id => new CatEntidadFederativa() {Identificador = id } )));*/


        }
    }
}
