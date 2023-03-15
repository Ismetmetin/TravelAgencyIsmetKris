using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business;
using TravelAgency.Data;

namespace TravelAgency.Presentation
{
    public class Display
    {
        BusBusiness busBusiness = new BusBusiness();
        CityBusiness cityBusiness = new CityBusiness();
        ClientBusiness clientBusiness = new ClientBusiness();
        DriverBusiness driverBusiness = new DriverBusiness();
        TravelBusiness travelBusiness = new TravelBusiness();

        //dobavqm komentar
        public Display()
        {
            Input();
        }

        public void Input()
        {
            int operation = -1;
            do
            {
                ShowMainMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        BusMenuInput();
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:
                        TravelMenuInput();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Option not available!");
                        break;
                }
            } while (operation != 6);
        }

        private void TravelMenuInput()
        {
            ShowTravelMenu();

            int operation = -1;

            operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    TravelAdd();
                    break;
                case 2:
                    TravelDelete();
                    break;
                case 3:
                    TravelGet();
                    break;
                case 4:
                    TravelGetAll();
                    break;
                case 5:
                    TravelUpdate();
                    break;
                case 6:
                    TravelGetBus();
                    break;
                case 7:
                    // TODO: Довършвам последните 2 метода и да говорим за DateTime и като цяло
                    // дали не можем да иззмислим нещо по-хубаво
                    break;
                case 8:

                    break;
                default:
                    Console.WriteLine("Option not available!\nReturning to main menu...");
                    break;
            }

        }

        private void TravelGetBus()
        {
            Console.WriteLine("Enter ID of travel to see its bus: ");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            
            // Така ли е май-добре да го оставим или нещо по-добро да измислим
            Bus bus = travel.Bus;

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("ID: " + bus.Id);
            Console.WriteLine("Model: " + bus.Model);
            Console.WriteLine("Capacity: " + bus.Capacity);
            Console.WriteLine("Kilometers runed: " + bus.KilometersRun);
            Console.WriteLine(new string('-', 40));
        }

        private void TravelUpdate()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                Console.WriteLine("Enter from-city id: ");
                travel.FromCityId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter to-city id: ");
                travel.ToCityId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bus id: ");
                travel.BusId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter date of travel: ");
                travel.DateOfTravel = DateTime.Parse(Console.ReadLine());
                travelBusiness.Update(travel);
            }
            else
            {
                Console.WriteLine("Travel not found!");
            }
        }

        private void TravelGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BUSES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var travels = travelBusiness.GetAll();
            foreach (var travel in travels)
            {
                Console.WriteLine($"{travel.Id} {travel.FromCityId} {travel.ToCityId} {travel.BusId} {travel.DateOfTravel.ToString()}");
            }
        }

        private void TravelGet()
        {
            Console.WriteLine("Enter ID to get: ");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + travel.Id);
                Console.WriteLine("From-city id: " + travel.FromCityId);
                Console.WriteLine("To-city id: " + travel.ToCityId);
                Console.WriteLine("Bus id: " + travel.BusId);
                Console.WriteLine("Date of travel: " + travel.DateOfTravel);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void TravelDelete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                travelBusiness.Delete(id);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Travel not found!");
            }
        }

        private void TravelAdd()
        {
            Travel travel = new Travel();
            Console.WriteLine("Enter from-city ID:");
            travel.FromCityId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter to-city ID:");
            travel.ToCityId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bus ID:");
            travel.BusId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter date of travel: ");

            // Да оставяме ли датите, защото после като вкарваме записите пред госпожата
            // ще е много трудно

            travel.DateOfTravel = DateTime.Parse(Console.ReadLine()); 
            travelBusiness.Add(travel);
        }



        //----------------------------------------------
        // Bus menu input and methods
        private void BusMenuInput()
        {
            ShowBusMenu();

            int operation = -1;

            operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    BusAdd();
                    break;
                case 2:
                    BusDelete();
                    break;
                case 3:
                    BusGet();
                    break;
                case 4:
                    BusGetAll();
                    break;
                case 5:
                    BusUpdate();
                    break;
                default:
                    Console.WriteLine("Option not available!\nReturning to main menu...");
                    break;
            }

        }

        private void BusAdd()
        {
            Bus bus = new Bus();
            Console.WriteLine("Enter model:");
            bus.Model = Console.ReadLine();
            Console.WriteLine("Enter capacity:");
            bus.Capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter kilometers runed:");
            bus.KilometersRun = int.Parse(Console.ReadLine());
            busBusiness.Add(bus);
        }
        private void BusDelete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Bus bus = busBusiness.Get(id);
            if (bus != null)
            {
                busBusiness.Delete(id);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Bus not found!");
            }
        }
        private void BusGet()
        {
            Console.WriteLine("Enter ID to get: ");
            int id = int.Parse(Console.ReadLine());
            Bus bus = busBusiness.Get(id);
            if (bus != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + bus.Id);
                Console.WriteLine("Model: " + bus.Model);
                Console.WriteLine("Capacity: " + bus.Capacity);
                Console.WriteLine("Kilometers runed: " + bus.KilometersRun);
                Console.WriteLine(new string('-', 40));
            }
        }
        private void BusGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BUSES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var buses = busBusiness.GetAll();
            foreach (var bus in buses)
            {
                Console.WriteLine($"{bus.Id} {bus.Model} {bus.Capacity} {bus.KilometersRun}");
            }
        }
        private void BusUpdate()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Bus bus = busBusiness.Get(id);
            if (bus != null)
            {
                Console.WriteLine("Enter model: ");
                bus.Model = Console.ReadLine();
                Console.WriteLine("Enter capacity: ");
                bus.Capacity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter kilometers runed: ");
                bus.KilometersRun = int.Parse(Console.ReadLine());
                busBusiness.Update(bus);
            }
            else
            {
                Console.WriteLine("Bus not found!");
            }
        }









        // ------------------------------------------
        // Menus

        public void ShowMainMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Bus menu");
            Console.WriteLine("2. City menu");
            Console.WriteLine("3. Client menu");
            Console.WriteLine("4. Driver menu");
            Console.WriteLine("5. Travel menu");
        }
        public void ShowBusMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "BUS MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new bus");
            Console.WriteLine("2. Delete a bus");
            Console.WriteLine("3. Get bus");
            Console.WriteLine("4. Get all buses");
            Console.WriteLine("5. Update a bus");
        }
        public void ShowCityMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "BUS MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new city");
            Console.WriteLine("2. Delete a city");
            Console.WriteLine("3. Get city");
            Console.WriteLine("4. Get all cities");
            Console.WriteLine("5. Update a city");
        }
        public void ShowClientMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "BUS MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new client");
            Console.WriteLine("2. Delete a client");
            Console.WriteLine("3. Get client");
            Console.WriteLine("4. Get all clients");
            Console.WriteLine("5. Update a client");
            Console.WriteLine("5. Get client's travel");
        }
        public void ShowDriverMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "BUS MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new driver");
            Console.WriteLine("2. Delete a driver");
            Console.WriteLine("3. Get driver");
            Console.WriteLine("4. Get all drivers");
            Console.WriteLine("5. Update a driver");
        }
        public void ShowTravelMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "BUS MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new travel");
            Console.WriteLine("2. Delete a travel");
            Console.WriteLine("3. Get travel");
            Console.WriteLine("4. Get all travels");
            Console.WriteLine("5. Update a travel");
            Console.WriteLine("6. Get bus by travel id");
            Console.WriteLine("7. Get from-city");
            Console.WriteLine("8. Get to-city");
        }
    }
}
