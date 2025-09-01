using EstacionamentoApi.Data;
using EstacionamentoApi.Model;
using EstacionamentoApi.Services;

namespace EstacionamentoApi.Routes
{
    public static class VeiculoRoutes
    {
        public static void VeiculosRoutes(this WebApplication app)
        {
            var route = app.MapGroup("Veiculo");

            route.MapGet("", async (VeiculoService service) => 
            {
                return await service.BuscarVeiculosAsync();
            });

            route.MapGet("{placa:required}", async(string placa, VeiculoService service) => 
            {
                return await service.BuscarVeiculoAsync(placa);
            });

            route.MapPost("", async (VeiculoService service, VeiculoRequest req) => 
            {
                return  await service.RegistrarEntradaAsync(req);
            });

            route.MapPut("{id:required}", async (int id, VeiculoService service) => 
            {
                return await service.RegistrarSaidaAsync(id);
            });

        }

        
    }
}
