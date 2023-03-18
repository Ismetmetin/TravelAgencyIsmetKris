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
     








        // МОЖЕМ ДА ДОБАВИМ ИНДИКАТОР НАПРИМЕР СЛЕД КАТО СЕ ДОБАВИ АВТОБУС В БАЗАТА ДАННИ СЕ ИЗПИСВА БЪС АДДЕД РЕТЪРНИН ТО МЕЙН МЕНЙУ...
             

        //------------------------------------------------
        // Client menu, input and methods


       






        // Driver menus
      



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
       
       
       
        
       
    }
}
