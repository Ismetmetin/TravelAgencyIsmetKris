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
                        CityMenuInput();
                        break;
                    case 3:
                        ClientMenuInput();
                        break;
                    case 4:
                        DriverMenuInput();
                        break;
                    case 5:
                        TravelMenuInput();
                        break;
                    case 6://END 
                        break;
                    default:
                        Console.WriteLine("Option not available!");
                        break;
                }
            } while (operation != 6);
        }


        // Travel menus and methods
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
                    TravelGetFromCity();
                    break;
                case 8:
                    TravelGetToCity();
                    break;
                default:
                    Console.WriteLine("Option not available!\nReturning to main menu...");
                    break;
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
        private void TravelGetFromCity()
        {
            Console.WriteLine("Enter ID of travel to get from-city id");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                City city = travel.FromCity;
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + city.Id);
                Console.WriteLine("Name: " + city.Name);
                Console.WriteLine("Population: " + city.Population);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Travel not found!");
            }

        }
        private void TravelGetToCity()
        {
            Console.WriteLine("Enter ID of travel to get to-city id");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                City city = travel.ToCity;
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + city.Id);
                Console.WriteLine("Name: " + city.Name);
                Console.WriteLine("Population: " + city.Population);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Travel not found!");
            }
        }









        // МОЖЕМ ДА ДОБАВИМ ИНДИКАТОР НАПРИМЕР СЛЕД КАТО СЕ ДОБАВИ АВТОБУС В БАЗАТА ДАННИ СЕ ИЗПИСВА БЪС АДДЕД РЕТЪРНИН ТО МЕЙН МЕНЙУ...

        //----------------------------------------------
        // Bus menu input and methods
        
        /// <summary>
        /// Print the menu and wait for input
        /// </summary>
        
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

        /// <summary>
        /// Manually add a new bus to the database
        /// </summary>
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

        /// <summary>
        /// Delete a bus by given id
        /// </summary>
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

        /// <summary>
        /// Displays information about the bus for the travel
        /// </summary>
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
                Console.WriteLine("Kilometers ran: " + bus.KilometersRun);
                Console.WriteLine(new string('-', 40));
            }
        }

        /// <summary>
        /// Displays information about all busses in the database
        /// </summary>
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

        /// <summary>
        /// Update a bus in the database
        /// </summary>
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

        //------------------------------------------------
        // Client menu, input and methods


        /// <summary>
        /// Принтира менюто и иска вход
        /// </summary>
        private void ClientMenuInput()
        {

            ShowClientMenu();

            int operation = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    ClientAdd();
                    break;
                case 2:
                    ClientDelete();
                    break;
                case 3:
                    ClientGet();
                    break;
                case 4:
                    ClientGetAll();
                    break;
                case 5:
                    ClientUpdate();
                    break;
                case 6:
                    ClientGetTravelByClientId();
                    break;
                default:
                    Console.WriteLine("Option not available!\nReturning to main menu...");
                    break;
            }
        }

        /// <summary>
        /// Manually add a new client to the database
        /// </summary>
        public void ClientAdd()
        {
            Client client = new Client();
            Console.WriteLine("Enter first name:");
            client.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            client.LastName = Console.ReadLine();
            Console.WriteLine("Enter age :");
            client.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter id of travel");
            client.TravelId = int.Parse(Console.ReadLine());
            clientBusiness.Add(client);


        }


        /// <summary>
        /// Given the id the method deletes a client from the database 
        /// </summary>
        public void ClientDelete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Client client = clientBusiness.Get(id);
            if (client != null)
            {
                clientBusiness.Delete(id);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Client not found!");
            }
        }

        /// <summary>
        /// The method returns information about a client given the id
        /// </summary>
        public void ClientGet()
        {
            Console.WriteLine("Enter ID to get: ");
            int id = int.Parse(Console.ReadLine());
            Client client = clientBusiness.Get(id);
            if (client != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + client.Id);
                Console.WriteLine("First name: " + client.FirstName);
                Console.WriteLine("Last name: " + client.LastName);
                Console.WriteLine("Age : " + client.Age);
                Console.WriteLine("Travel id: " + client.TravelId);
                Console.WriteLine(new string('-', 40));
            }
        }

        /// <summary>
        /// The following method returns all clients currently in the database
        /// </summary>
        public void ClientGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "CLIENTS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var clients = clientBusiness.GetAll();
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Id} {client.FirstName} {client.LastName} {client.Age}, Travel ID -{client.TravelId}");
            }
        }

        /// <summary>
        /// актуализира информацията за клиента на когото ID-то е въведено
        /// </summary>
        public void ClientUpdate()
        {

            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Client client = clientBusiness.Get(id);
            if (client != null)
            {
                Console.WriteLine("Enter first name: ");
                client.FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                client.LastName = Console.ReadLine();
                Console.WriteLine("Enter age:");
                client.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter travel id");
                client.TravelId = int.Parse(Console.ReadLine());
                clientBusiness.Update(client);
            }
            else
            {
                Console.WriteLine("Client not found!");
            }



        }

        /// <summary>
        /// При дадено ID на клиент се връща информацията за неговото пътуване 
        /// </summary>
        public void ClientGetTravelByClientId()
        {
            Console.WriteLine("Enter the ID of a client and his travel information will be shown");
            int idClient = int.Parse(Console.ReadLine());
            var travel = clientBusiness.Get(idClient).Travel;
            Console.WriteLine("Travel ID: " + travel.Id);
            Console.WriteLine("From city:\nID: " + travel.FromCity.Id + " \nCity:" + travel.FromCity.Name);
            Console.WriteLine("To city:\nID: " + travel.ToCity.Id + " \nCity: " + travel.ToCity.Name);
            Console.WriteLine("Bus ID: " + travel.BusId);
            //vij tuk
            Console.WriteLine("Date of travel - " + travel.DateOfTravel.ToString());
        }

        // City menus

        public void CityMenuInput()
        {
            ShowCityMenu();

            int operation = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case 1: CityAdd(); break;
                case 2: CityDelete(); break;
                case 3: CityGet(); break;
                case 4: CityGetAll(); break;
                case 5: CityUpdate(); break;
                default: Console.WriteLine("Option not available!"); break;
            }
        }

        private void CityAdd()
        {
            City city = new City();
            Console.WriteLine("Enter name of city:");
            city.Name = Console.ReadLine();
            Console.WriteLine("Enter population:");
            city.Population = int.Parse(Console.ReadLine());
            cityBusiness.Add(city);
        }

        private void CityDelete()
        {
            Console.WriteLine("Enter the ID of the city you want to delete:");
            int id = int.Parse(Console.ReadLine());
            var city = cityBusiness.Get(id);
            if (city != null)
            {
                cityBusiness.Delete(id);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("City not found!");
            }
        }

        private void CityGet()
        {
            Console.WriteLine("Enter ID to get: ");
            int id = int.Parse(Console.ReadLine());
            City city = cityBusiness.Get(id);
            if (city != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + city.Id);
                Console.WriteLine("Name: " + city.Name);
                Console.WriteLine("Population: " + city.Population);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void CityGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "CITIES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var cities = cityBusiness.GetAll();
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Id} {city.Name} Population{city.Population}");
            }
        }

        private void CityUpdate()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            City city = cityBusiness.Get(id);
            if (city != null)
            {
                Console.WriteLine("Enter name: ");
                city.Name = Console.ReadLine();
                Console.WriteLine("Enter population: ");
                city.Population = int.Parse(Console.ReadLine());
                cityBusiness.Update(city);
            }
            else
            {
                Console.WriteLine("City not found!");
            }
        }

        public void DriverMenuInput()
        {
            ShowDriverMenu();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "DRIVER MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            int operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 1:DriverAdd(); break;
                case 2:DriverDelete(); break;
                case 3:DriverGet(); break;
                case 4:DriverGetAll(); break;
                case 5:DriverUpdate(); break;
                default: Console.WriteLine("Option not available!\nReturning to main menu..."); break;
            }
        }

        // Driver menus

        private void DriverAdd()
        {
            Driver driver = new Driver();
            Console.WriteLine("Enter first name:");
            driver.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            driver.LastName = Console.ReadLine();
            Console.WriteLine("Enter age");
            driver.Age = int.Parse(Console.ReadLine());
            driverBusiness.Add(driver);
        }

        private void DriverDelete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Driver driver = driverBusiness.Get(id);
            if (driver!= null)
            {
                driverBusiness.Delete(id);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Driver not found!");
            }
        }

        private void DriverGet()
        {
            Console.WriteLine("Enter the ID of the driver you want to delete:");
            int id = int.Parse(Console.ReadLine());
            var driver = driverBusiness.Get(id);
            if (driver != null)
            {
                driverBusiness.Delete(id);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Driver not found!");
            }
        }

        private void DriverGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "DRIVERS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var drivers = driverBusiness.GetAll();
            foreach (var driver in drivers)
            {
                Console.WriteLine($"{driver.Id} {driver.FirstName} {driver.LastName} Age{driver.Age}");
            }
        }

        private void DriverUpdate()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Driver driver = driverBusiness.Get(id);
            if (driver != null)
            {
                Console.WriteLine("Enter first name: ");
                driver.FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                driver.LastName = Console.ReadLine();
                Console.WriteLine("Enter age:");
                driver.Age = int.Parse(Console.ReadLine());
                driverBusiness.Update(driver);
            }
            else
            {
                Console.WriteLine("Driver not found!");
            }
        }




        // ------------------------------------------
        // Menus
        /* От исмет
        може да трябва да променим заглавията на всички менюта за да са симетрични
        защото при различните менюта ще се отпечатат на различна дължина тези 18 тирета и може да изглежда грозно
        най вероятно ще го оправим като от втория ню стринг с тиретата се извърши това---> 18 - (дължината на думата Бъс, например Бъс меню)
         */
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
            Console.WriteLine(new string('-', 18) + "CITY MENU" + new string('-', 18));
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
