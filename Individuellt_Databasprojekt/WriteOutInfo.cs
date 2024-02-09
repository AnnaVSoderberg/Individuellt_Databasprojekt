using Individuellt_Databasprojekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_Databasprojekt
{
    internal class WriteOutInfo
    {
        public static void StudentInfo(SchoolDbContext context, IQueryable<TblStudent> students)
        {
            foreach (var s in students.Include(s => s.KlassNavigation))
            {
                Console.WriteLine($"Personnummer: {s.Personnummer}");
                Console.WriteLine($"Förnamn: {s.Förnamn}");
                Console.WriteLine($"Efternamn: {s.Efternamn}");
                Console.WriteLine($"Klass: {s.KlassNavigation?.KlassNamn}");
                Console.WriteLine(new string('*', 10));
            }
            Console.ReadLine();
        }

        public static void StaffInfo(SchoolDbContext context, IQueryable<TblPersonal> personals)
        {
            int rektor = 0;
            int Admin = 0;
            int Lärare = 0;
            int övriga = 0;
            foreach (var p in personals)
            {
                if (p.Titel == 1)
                {
                    rektor++;
                }
                else if (p.Titel == 2)
                {
                    Admin++;
                }
                else if (p.Titel == 3)
                {
                    Lärare++;
                }
                else
                {
                    övriga++;
                }
            }
            Console.WriteLine("Skolan har {0} rekorer anställda", rektor);
            Console.WriteLine("Skolan har {0} Admin anställda", Admin);
            Console.WriteLine("Skolan har {0} Lärare anställda", Lärare);

            if(övriga != 0)
            {
                Console.WriteLine($"Skolan har {0} personer som saknar avdelning");
            }


            Console.ReadLine();
        }

        public static void AktivaKurser(SchoolDbContext context, IQueryable<TblKur> kurser )
        {
            foreach(var k in kurser)
            {
                if (k.Kursstart < DateTime.Now && k.Kursslut > DateTime.Now)
                {
                    Console.WriteLine("Aktiva kurser: {0}", k.Kursnamn);
                }
            }
            Console.ReadLine ();
        }
    }
}

