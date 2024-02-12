using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SilverCoastHotel
{
    public class UserInterface
    {

        public static void MainMenu()
        {
            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. All Guest Data");
            Console.WriteLine("2. All Room Data");
            Console.WriteLine("3. About This Hotel");
            Console.WriteLine("4. Exit Application");
            Console.WriteLine(" ");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {

                    case 1:
                        Console.WriteLine("1. All Guest Data");
                        AllGuessData();
                        break;
                    case 2:
                        Console.WriteLine("2. All Room Data");
                        AllRoomData();
                        break;
                    case 3:
                        Console.WriteLine("3. About This Hotel");
                        PrintHotelInformation();
                        break;
                    case 4:
                        Console.WriteLine("4. Exit Application");
                        break;
                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-4");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-4!");
                MainMenu();
            }
        }

        public static void AllGuessData()
        {       
            List<Room> getdataroomcomplete = GetFullDataCombine();
            for (int index = 0; index < getdataroomcomplete.Count; index++)
            {
                foreach (Guest eachGuest in getdataroomcomplete[index].ListGuest.Values)
                {
                    Console.WriteLine($"{eachGuest.NamaDepan} {eachGuest.NamaBelakang} dengan nomor register: {eachGuest.NomorRegister} ");
                }
            }

            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Guest Information");
            Console.WriteLine("2. Back to Main Menu");
            Console.WriteLine("3. Exit Application");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {

                    case 1:
                        Console.WriteLine("1. Guest Information");
                        GuestInformation();
                        break;
                    case 2:
                        Console.WriteLine("2. Back to Main Menu");
                        MainMenu();
                        break;
                    case 3:
                        Console.WriteLine("3. Exit Application");
                        break;

                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-3");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-3");
                MainMenu();
            }
        }

        public static void GuestInformation()
        {
            List<Room> getDataRoomComplete = GetFullDataCombine();
            Console.WriteLine("Masukkan Nomor regis yang anda ingin lihat informasinya: ");
            string nomorRegister = Console.ReadLine();
            Console.WriteLine();
            for (int index = 0; index < getDataRoomComplete.Count; index++)
            {
                foreach (Guest guest in getDataRoomComplete[index].ListGuest.Values)
                {
                    if (guest.NomorRegister == nomorRegister)
                    {
                        Console.WriteLine($"FirstName: {guest.NamaDepan}");
                        Console.WriteLine($"Last Name: {guest.NamaBelakang}");
                        Console.WriteLine($"Gender: {guest.JenisKelamin}");

                        Console.WriteLine($"Birth Information: {guest.TempatLahir} {guest.TanggalLahir.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"))} ({guest.HitungUmur()} Tahun) ");
                        Console.WriteLine($"ID Card: {guest.NomorKTP}");
                        Console.WriteLine($"Menginap Selama: {guest.TotalMenginap}");
                        Console.WriteLine($"Biaya Penginapan: {guest.BiayaMenginap}");

                        Console.WriteLine("Menginap di: ");
                        Console.WriteLine($"Room Number: {guest.Room.RoomNumber}");
                        Console.WriteLine($"Floor: {guest.Room.FloorNumber}");
                        Console.WriteLine($"Room Type: {guest.Room.RoomType}");

                        Console.WriteLine("Anggota Keluarga: ");

                        bool keluarga = guest.FamilyMember.Count != 0;

                        if (!keluarga)
                        {
                            Console.WriteLine("Pergi Sendiri");
                        }
                        else 
                        {  
                            foreach (Guest familyMember in guest.FamilyMember)
                            {
                                Console.WriteLine($"{familyMember.NamaDepan} {familyMember.NamaBelakang} dengan nomor Register: {familyMember.NomorRegister}");
                                keluarga = true;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Back to All Guest Data");
            Console.WriteLine("2. Back to Main Menu");
            Console.WriteLine("3. Exit Application");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {

                    case 1:
                        Console.WriteLine("1. Back to All Guest Data");
                        AllGuessData();
                        break;
                    case 2:
                        Console.WriteLine("2. Back to Main Menu");
                        MainMenu();
                        break;
                    case 3:
                        Console.WriteLine("3. Exit Application");
                        break;

                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-3");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-3");
                MainMenu();
            }
        }


        public static void AllRoomData()
        {

            List<Room> getdataroomcomplete = GetFullDataCombine();
            Console.Write("Lantai 3: ");
            foreach (Room room in getdataroomcomplete)
            {
                if (room.FloorNumber == "3")
                {

                    Console.Write(room.RoomNumber + ",");
                }
            }
            Console.WriteLine();
            Console.Write("Lantai 4: ");
            foreach (Room room in getdataroomcomplete)
            {
                if (room.FloorNumber == "4")
                {

                    Console.Write(room.RoomNumber + ",");
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Room Information");
            Console.WriteLine("2. Back to Main Menu");
            Console.WriteLine("3. Exit Application");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {

                    case 1:
                        Console.WriteLine("1. Room Information");
                        RoomInformation();
                        break;
                    case 2:
                        Console.WriteLine("2. Back to Main Menu");
                        MainMenu();
                        break;
                    case 3:
                        Console.WriteLine("3. Exit Application");
                        break;

                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-3");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-3");
                MainMenu();
            }
        }

        public static void RoomInformation()
        {

            List<Room> getDataRoomComplete = GetFullDataCombine();
            

            Console.WriteLine("Masukkan Nomor Room yang anda ingin lihat informasinya: ");
            string roomNumber = Console.ReadLine();
            Console.WriteLine();

            foreach (Room room in getDataRoomComplete)
            {
                if (room.RoomNumber == roomNumber)
                {
                    Console.WriteLine("Menginap di: ");
                    Console.WriteLine("Room Number : " + room.RoomNumber);
                    Console.WriteLine("Floor : " + room.FloorNumber);
                    Console.WriteLine("Room Type : " + room.RoomType);
                    Console.WriteLine("Price : " + room.RoomCostPerNight);

                    Console.WriteLine();

                    Console.WriteLine("Reservasi History : ");

                    bool roomBooked = room.ListGuest.Count != 0;

                    if (!roomBooked)
                    {
                        Console.WriteLine("Room ini belum pernah di booking");
                    }
                    else
                    {
                        foreach (Guest guest in room.ListGuest.Values)
                        {
                            Console.WriteLine($"{guest.TanggalCheckIn.ToString("dd MMMM yy", CultureInfo.CreateSpecificCulture("id-ID"))} - {guest.TanggalCheckOut.ToString("dd MMMM yy", CultureInfo.CreateSpecificCulture("id-ID"))} ({guest.NamaDepan} {guest.NamaBelakang}, {guest.NomorRegister})");

                        }
                    }


                    
                }
            }


            Console.WriteLine("Pilih menu untuk masuk ke menunya");
            Console.WriteLine("1. Back to All Room Data");
            Console.WriteLine("2. Back to Main Menu");
            Console.WriteLine("3. Exit Application");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {

                    case 1:
                        Console.WriteLine("1. Back to All Room Data");
                        AllRoomData();
                        break;
                    case 2:
                        Console.WriteLine("2. Back to Main Menu");
                        MainMenu();
                        break;
                    case 3:
                        Console.WriteLine("3. Exit Application");
                        break;

                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-3");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-3");
                MainMenu();
            }
        }


        public static void PrintHotelInformation()
        {
            Console.WriteLine("Hotel ini bernama Silver Coast Hotel. Sudah didirikan sejak 12 December 1978 di Australia,\nQueensland, di kota Gold Coast");

            Console.WriteLine("1. Return to Main Menu");
            Console.WriteLine("2. Exit To Application");
            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());

                switch (pilihMenu)
                {
                    case 1:
                        Console.WriteLine("Return to Main Menu");
                        MainMenu();
                        break;
                    case 2:
                        Console.WriteLine("Exit To Aplication");
                        break;
                    default:
                        Console.WriteLine("Input hanya 1 dan 2");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-2");
            }
        }

        public static List<Room> GetDataRoom()
        {
            List<Room> AllDataRoom = new List<Room>()
            {
                new Room("301", "3", "Regular Single Bed", 800_000),
                new Room("302", "3", "Regular Double Bed", 1000_000),
                new Room("303", "3", "Regular Twin Bed", 1200_000),
                new Room("401", "4", "VIP Single Bed", 1000_000),
                new Room("402", "4", "Regular Double Bed", 1000_000),
                new Room("403", "4", "VIP Twin Bed", 1400_000)

            };
            return AllDataRoom;
        }

        //cetak semua kamar, nomor, type kamar, harga kamar
        public void GetKamar()
        {
            List<Room> AllDataRoom = GetDataRoom();
            

            foreach(Room room in AllDataRoom)
            {
                Console.WriteLine($"Nomor Kamar: {room.RoomNumber}, Type Kamar {room.RoomType}, Harga Kamar: {room.RoomCostPerNight.ToString(CultureInfo.GetCultureInfo("id-ID"))}"); //Rp.1.000.000
            }
        }


        //cetak semua orang yang ada di kamar 302
        public static void GetNama302()
        {
            List<Room> RoomGuest = GetFullDataCombine();
   

            foreach (Guest guestRoom in RoomGuest.ElementAt(1).ListGuest.Values)
            {
                Console.WriteLine($"{guestRoom.Room.RoomNumber}, {guestRoom.NamaDepan} ");
                
            }
            
        }
            

        public static List<Guest> InsertData()
        {

            Guest dannyTan = new Guest("A021", "Danny", "Tan", new DateTime(1990, 11, 23), "Beijing", 'M', "312008923111990002", new DateTime(2018, 4, 12), new DateTime(2018, 4, 14));
            Guest dessyWang = new Guest("A022", "Dessy", "Wang", new DateTime(1990, 11, 11), "Beijing", 'F', "312008911111990002", new DateTime(2018, 4, 12), new DateTime(2018, 4, 14));
            Guest sunartiWijaya = new Guest("A023", "Sunarti", "Wijaya", new DateTime(1985, 04, 18), "Bandung", 'F', "312008923111990002", new DateTime(2018, 5, 15), new DateTime(2018, 5, 17));
            Guest ardiSanjaya = new Guest("A024", "Ardi", "Sanjaya", new DateTime(1985, 08, 01), "Jakarta", 'M', "312008901081990002", new DateTime(2018, 5, 15), new DateTime(2018, 5, 17));
            Guest muliawanSanjaya = new Guest("A025", "Muliawan", "Sanjaya", new DateTime(2000, 10, 10), "Jakarta", 'M', "3120089010102000002", new DateTime(2018, 5, 15), new DateTime(2018, 5, 17));
            Guest tirtaRaharja = new Guest("A026", "Tirta", "Raharja", new DateTime(1988, 10, 14), "Jakarta", 'M', "3120089014101988002", new DateTime(2018, 5, 15), new DateTime(2018, 5, 18));


            dannyTan.AddFamilyMember(dessyWang);
            sunartiWijaya.AddFamilyMember(ardiSanjaya);
            sunartiWijaya.AddFamilyMember(muliawanSanjaya);
            ardiSanjaya.AddFamilyMember(muliawanSanjaya);



            List<Guest> allDataGuest = new List<Guest>() { dannyTan, dessyWang, sunartiWijaya, ardiSanjaya, muliawanSanjaya, tirtaRaharja };
            return allDataGuest;
        }

        public static List<Room> GetFullDataCombine()
        {
            List<Room> AlldataRoom = GetDataRoom();
            List<Guest> AlldataGuest = InsertData();

            AlldataRoom[0].AddGuest(AlldataGuest[0]);
            AlldataRoom[0].AddGuest(AlldataGuest[1]);
            AlldataRoom[1].AddGuest(AlldataGuest[2]);
            AlldataRoom[1].AddGuest(AlldataGuest[3]);
            AlldataRoom[1].AddGuest(AlldataGuest[4]);
            AlldataRoom[3].AddGuest(AlldataGuest[5]);


            return AlldataRoom;
        }

    }
}
