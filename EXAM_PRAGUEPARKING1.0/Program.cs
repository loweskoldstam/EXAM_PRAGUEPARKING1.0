using System;

namespace EXAM_PRAGUEPARKING1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string welcome = "~~~~~~~~~~~~~~~~~~~~~~~~~ Vítejte v pražské garáži! ~~~~~~~~~~~~~~~~~~~~~~~~~";
            string UPwelcome = welcome.ToUpper();





            string[] parkingSpace = new string[100];

            for (int j = 0; j < parkingSpace.Length; j++)
            {
                parkingSpace[j] = "|EMPTY";
            }

            bool running = true;
            while (running == true)
            {

                Console.WriteLine(UPwelcome);
                Console.WriteLine(DateTime.Now);
                Console.WriteLine("____________________");
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("1. CheckIn ");
                Console.WriteLine("2. Move Vehicle ");
                Console.WriteLine("3. CheckOut");
                Console.WriteLine("4. Search Vehicle");
                Console.WriteLine("5. Exit");
                Console.WriteLine("6. Show Garage Map");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":

                        /////////////////////////////VEHICLETYPE
                        Console.WriteLine("Enter vehicle type: 1. CAR | 2. MC");
                        string vehicleType = Console.ReadLine();



                        switch (vehicleType)
                        {
                            case "1":
                                vehicleType = "#CAR";
                                break;

                            case "2":
                                vehicleType = "#MC";
                                break;

                            default:
                                Console.WriteLine("Not a valid number. Try again!");
                                break;

                        }

                        /////////////////////////REGNUMBER

                        Console.WriteLine("Enter your registration number: ");
                        string registrationNr = Console.ReadLine();

                        if (registrationNr.Length > 10)
                        {
                            Console.WriteLine("The registration is not valid. PLease try again.");
                            break;
                        }


                        string newCar = "";
                        string newMC = "";

                        if (vehicleType == "#CAR")
                        {
                            newCar = vehicleType + ", " + registrationNr;
                        }

                        else if (vehicleType == "#MC")
                        {
                            newMC = vehicleType + ", " + registrationNr;
                        }

                        else
                        {
                            Console.WriteLine("Sorry, something is wrong.");
                        }

                        //////////////////////////CHECK IN

                        string MC_FREE = " #MCFREESPOT";


                        for (int r = 0; r < parkingSpace.Length; r++)

                        {
                            if (parkingSpace[r] == "|EMPTY" && vehicleType == "#CAR")
                            {
                                parkingSpace[r] = newCar;

                                Console.WriteLine("Your vehicle is parked at spot: {0}", r + 1);
                                break;

                            }

                            else if (true == parkingSpace[r].Contains(MC_FREE) && vehicleType == "#MC")
                            {
                                Console.WriteLine("This spot is free for another MC.");

                                string[] strikeout = parkingSpace[r].Split(MC_FREE, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string x in strikeout)
                                {
                                    parkingSpace[r] = x;
                                    break;
                                }

                                parkingSpace[r] += " | " + newMC;



                                break;

                            }



                            else if (parkingSpace[r] == "|EMPTY" && vehicleType == "#MC")
                            {
                                parkingSpace[r] = newMC + MC_FREE;

                                Console.WriteLine("Your vehicle is parked at spot: {0}", r + 1);
                                break;

                            }

                            else
                            {

                            }


                        }






                        //////////GO HOME GARAGE, YOU'RE DRUNK












                        break;

                    case "2":

                        /////////////////////////////////MOVE VEHICLE

                        Console.WriteLine("Enter vehicle type: 1. CAR | 2. MC");
                        string vehicleTypeMove = Console.ReadLine();



                        switch (vehicleTypeMove)
                        {
                            case "1":
                                vehicleTypeMove = "#CAR";
                                break;

                            case "2":
                                vehicleTypeMove = "#MC";
                                break;

                            default:
                                Console.WriteLine("Not a valid number. Try again!");
                                break;

                        }


                        int p = 0;
                        bool ShiftSpace = false;
                        MC_FREE = "#MCFREESPOT";

                        Console.WriteLine("Please enter the registration number for the vehicle you want to move: ");
                        string MoveVehicle = Console.ReadLine();


                        //string MoveCar = "";
                        //string MoveMC = "";

                        if (vehicleTypeMove == "#CAR")
                        {
                            MoveVehicle = vehicleTypeMove + ", " + MoveVehicle;
                        }

                        else if (vehicleTypeMove == "#MC")
                        {
                            MoveVehicle = vehicleTypeMove + ", " + MoveVehicle;
                        }

                        else
                        {
                            Console.WriteLine("Sorry, something is wrong.");
                        }







                        for (p = 0; p < parkingSpace.Length; p++)
                        {
                            ShiftSpace = parkingSpace[p].Contains(MoveVehicle);
                            if (ShiftSpace == true)
                            {
                                break;
                            }
                        }

                        if (ShiftSpace == true && vehicleTypeMove == "#CAR")
                        {
                            Console.WriteLine("Your vehicle is at spot {0}", p + 1);
                            parkingSpace[p] = "|EMPTY";


                        }

                        else if (ShiftSpace == true && vehicleTypeMove == "#MC" && parkingSpace[p].Contains(MC_FREE))
                        {
                            Console.WriteLine("Your vehicle is at spot {0}", p + 1);
                            //string[] strikeout = parkingSpace[p].Split(MoveVehicle, StringSplitOptions.RemoveEmptyEntries);
                            parkingSpace[p] = "|EMPTY";




                        }

                        else if (ShiftSpace == true && vehicleTypeMove == "#MC" && !parkingSpace[p].Contains(MC_FREE))
                        {
                            Console.WriteLine("Your vehicle is at spot {0}", p + 1);
                            //string[] strikeout = parkingSpace[p].Split(MoveVehicle, StringSplitOptions.RemoveEmptyEntries);
                            parkingSpace[p] = parkingSpace[p].Replace(MoveVehicle, MC_FREE);





                        }




                        /////////////////////

                        Console.WriteLine("Where do you want to move your vehicle?");
                        int MoveVehicleNewPos = int.Parse(Console.ReadLine());
                        MoveVehicleNewPos--;



                        p = 0;
                        bool FREENEW = false;

                        ////Någon typ av convertering? Vi behöver ju hitta den angivna CR i parkeringen och sen kolla om den är ledig, FREENEW=true;


                        for (p = 0; p < parkingSpace.Length; p++)
                        {
                            FREENEW = parkingSpace[MoveVehicleNewPos].Contains("|EMPTY");
                            if (FREENEW == true && parkingSpace[MoveVehicleNewPos] == "|EMPTY")
                            {
                                break;
                            }
                        }



                        if ((FREENEW == true) && (parkingSpace[MoveVehicleNewPos] == "|EMPTY") && (vehicleTypeMove == "#CAR"))
                        {
                            Console.WriteLine("The new position is at spot: {0}", MoveVehicleNewPos + 1);
                            parkingSpace[MoveVehicleNewPos] = MoveVehicle;
                        }



                        /////parkingSpace[MoveVehicleNewPos].Contains(MC_FREE) == true && vehicleTypeMove == "#MC"
                        else if (parkingSpace[MoveVehicleNewPos].Contains(MC_FREE) == true && vehicleTypeMove == "#MC")
                        {


                            string[] strikeout = parkingSpace[MoveVehicleNewPos].Split(MC_FREE, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string x in strikeout)
                            {
                                parkingSpace[MoveVehicleNewPos] = x;
                                break;
                            }


                            parkingSpace[MoveVehicleNewPos] += MoveVehicle;




                            break;

                        }

                        //////SINGLE MC TO EMPTY LOT
                        else if (FREENEW == true && parkingSpace[MoveVehicleNewPos] == "|EMPTY" && vehicleTypeMove == "#MC")

                        {
                            Console.WriteLine("The new position is at spot: {0}", MoveVehicleNewPos + 1);
                            parkingSpace[MoveVehicleNewPos] = MoveVehicle + " | " + MC_FREE;
                        }



                        else
                        {
                            Console.WriteLine("This spot is already taken. Try another.");
                        }


                        break;

                    case "3":
                        //////////////////////////////CHECKOUT

                        int i = 0;
                        bool vehicleFound = false;

                        Console.WriteLine("Please enter the registration number for the vehicle you want to check out: ");
                        string SearchVehicle = Console.ReadLine();

                        for (i = 0; i < parkingSpace.Length; i++)
                        {
                            vehicleFound = parkingSpace[i].Contains(SearchVehicle);
                            if (vehicleFound == true)
                            {

                                break;
                            }
                        }

                        if (vehicleFound == true)
                        {
                            Console.WriteLine("Your vehicle is at spot: {0}", i + 1);
                            parkingSpace[i] = "|EMPTY";

                        }
                        else
                        {
                            Console.WriteLine("Your vehicle has been abducted.");
                        }






                        break;

                    case "4":

                        /////////////////////////////SEARCH
                        i = 0;
                        vehicleFound = false;

                        Console.WriteLine("Please enter the registration number for the vehicle you're looking for: ");
                        SearchVehicle = Console.ReadLine();

                        for (i = 0; i < parkingSpace.Length; i++)
                        {
                            vehicleFound = parkingSpace[i].Contains(SearchVehicle);
                            if (vehicleFound == true)
                            {

                                break;
                            }
                        }

                        if (vehicleFound == true)
                        {
                            Console.WriteLine("Your vehicle is at spot: {0}", i + 1);
                        }
                        else
                        {
                            Console.WriteLine("Your vehicle has been abducted.");
                        }



                        break;

                    case "5":
                        ///////////////////////////////PROGRAM IS RUNNING
                        running = false;
                        break;

                    case "6":

                        ////////////////////////////////GARAGE MAP
                        for (i = 0; i < parkingSpace.Length; i++)
                        {
                            Console.WriteLine(i + 1 + ". " + parkingSpace[i]);
                        }

                        break;



                    default:
                        break;

                }
            }
    }
}
