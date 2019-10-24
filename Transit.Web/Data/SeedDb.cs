using System;
using System.Linq;
using System.Threading.Tasks;
using Transit.Web.Data.Entities;
using Transit.Web.Models.Data.Entities;

namespace Transit.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _Context;

        public SeedDb(DataContext dataContext)
        {
            _Context = dataContext;
        }

        public async Task SeedAsync()
        {
            await _Context.Database.EnsureCreatedAsync();
            await CheckOwnersAsync();
            await CheckAgentsAsync();
            await CheckVehiclesAsync();

        }

        private async Task CheckAgentsAsync()
        {
            if (!_Context.Agents.Any())
            {
                AddAgents("76767676", "Alexis", "Otalvaro", "244 5638");
                AddAgents("34343434", "Diana", "Tobar", "327 9641");
                AddAgents("57575577", "Luis", "Gil", "521 6809");
                await _Context.SaveChangesAsync();
            }
        }

        private void AddAgents(string document, string firstName, string lastName, string cellPhone)
        {
            _Context.Agents.Add(new Agent
            {
                Document = document,
                FirstName = firstName,
                LastName = lastName,
                CellPhone = cellPhone
            });
        }

        private async Task CheckOwnersAsync()
        {
            if (!_Context.Owners.Any())
            {
                AddOwner("89898989", "Christian", "Gil", "234 3232");
                AddOwner("56565656", "Andrea", "Marin", "338 9748");
                AddOwner("12121212", "Juan", "Zuluaga", "554 3899");
                await _Context.SaveChangesAsync();
            }
        }

        private void AddOwner(string document, string firstName, string lastName, string cellPhone)
        {
            _Context.Owners.Add(new Owner
            {
                Document = document,
                FirstName = firstName,
                LastName = lastName,
                CellPhone = cellPhone
            });
        }

        private async Task CheckVehiclesAsync()
        {
            var owner = _Context.Owners.FirstOrDefault();

            if (!_Context.Vehicles.Any())
            {
                AddVehicle("WER-234", DateTime.Today, DateTime.Today.AddYears(1), DateTime.Today, DateTime.Today.AddYears(1),"Red","QWQDAS12W","AutoMovil",owner);
                AddVehicle("WER-21F", DateTime.Today, DateTime.Today.AddYears(1), DateTime.Today, DateTime.Today.AddYears(1), "Blue", "AWEDBS35Z", "Motocicleta", owner);
                await _Context.SaveChangesAsync();
            }
        }

        private void AddVehicle(string placa, DateTime dateSoatStar, DateTime dateSoatEnd, DateTime dateTecnoStar, DateTime dateTecnoEnd, string color, string vin, string typeVehicle, Owner owner)
        {
            _Context.Vehicles.Add(new Vehicle
            {
                Placa = placa,
                DateSoatStar = dateSoatStar,
                DateSoatEnd = dateSoatEnd,
                DateTecnoStar = dateTecnoStar,
                DateTecnoEnd = dateTecnoEnd,
                Color = color,
                Vin = vin,
                TypeVehicle = typeVehicle,
                Owner = owner
            });
        }
    }
}
