using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCoastHotel
{
    public class Guest
    {
        public string NomorRegister { get; set; }
        public string NamaDepan { get; set; }
        public string NamaBelakang { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string TempatLahir { get; set; }
        public char JenisKelamin { get; set; }
        public string NomorKTP { get; set; }
        public DateTime TanggalCheckIn { get; set; }
        public DateTime TanggalCheckOut { get; set; }

        public List<Guest> FamilyMember { get; set; } = new List<Guest>();

        public Room Room { get; set; }




        public Guest(string nomorRegister, string namaDepan, string namaBelakang, DateTime tanggalLahir, string tempatLahir,
            char jenisKelamin, string nomorKTP, DateTime tanggalCheckIn, DateTime tanggalCheckOut)
        {
            NomorRegister = nomorRegister;
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            TanggalLahir = tanggalLahir;
            TempatLahir = tempatLahir;
            JenisKelamin = jenisKelamin;
            NomorKTP = nomorKTP;
            TanggalCheckIn = tanggalCheckIn;
            TanggalCheckOut = tanggalCheckOut;

        }

        public int HitungUmur()
        {
            DateTime tanggalLahir = this.TanggalLahir;
            TimeSpan selisihLahir = DateTime.Now - this.TanggalLahir;
            int Umur = selisihLahir.Days / 365;

            return Umur;
        }


        public void AddFamilyMember(Guest guest)
        {
            guest.FamilyMember.Add(this);
            this.FamilyMember.Add(guest);
        }


        public int TotalMenginap
        {
            get
            {
                TimeSpan lamaMenginap = this.TanggalCheckOut - this.TanggalCheckIn;
                return lamaMenginap.Days;
            }
        }

        public decimal BiayaMenginap
        {
            get
            {
                decimal totalCost = TotalMenginap * Room.RoomCostPerNight;
                return totalCost;
            }
        }

       
    }
}

