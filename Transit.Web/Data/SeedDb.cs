using System;
using System.Linq;
using System.Threading.Tasks;
using Transit.Web.Data.Entities;
using Transit.Web.Helpers;
using Transit.Web.Models.Data.Entities;

namespace Transit.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext dataContext,
            IUserHelper userHelper)
        {
            _context = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("1010", "Christian", "Gil", "hiangil0211@gmail.com", "316 494 4151", "Manager");
            var owner = await CheckUserAsync("2020", "Alexis", "Otalvaro", "cristhoper0211@hotmail.com", "316 879 1869", "Owner");
            var agent = await CheckUserAsync("3030", "Andrea", "Marin", "auxit1@navisaf.com", "318 3687693", "Agent");
            await CheckManagerAsync(manager);
            await CheckOwnersAsync(owner);
            await CheckAgentsAsync(agent);
            await CheckVehiclesAsync();

        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);

            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Document = document,
                    
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Manager");
            await _userHelper.CheckRoleAsync("Owner");
            await _userHelper.CheckRoleAsync("Agent");
        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_context.Managers.Any())
            {
                _context.Managers.Add(new Manager { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckAgentsAsync(User user)
        {
            if (!_context.Agents.Any())
            {
                _context.Agents.Add(new Agent { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckOwnersAsync(User user)
        {
            if (!_context.Owners.Any())
            {
                _context.Owners.Add(new Owner { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckVehiclesAsync()
        {
            var owner = _context.Owners.FirstOrDefault();

            if (!_context.Vehicles.Any())
            {
                AddVehicle("WER-234", DateTime.Today, DateTime.Today.AddYears(1), DateTime.Today, DateTime.Today.AddYears(1),"Red","QWQDAS12W","AutoMovil",owner);
                AddVehicle("WER-21F", DateTime.Today, DateTime.Today.AddYears(1), DateTime.Today, DateTime.Today.AddYears(1), "Blue", "AWEDBS35Z", "Motocicleta", owner);
                await _context.SaveChangesAsync();
            }
        }

        private void AddVehicle(string placa, DateTime dateSoatStar, DateTime dateSoatEnd, DateTime dateTecnoStar, DateTime dateTecnoEnd, string color, string vin, string typeVehicle, Owner owner)
        {
            _context.Vehicles.Add(new Vehicle
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
