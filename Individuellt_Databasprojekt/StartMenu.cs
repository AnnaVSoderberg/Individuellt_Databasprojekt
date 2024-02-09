using Individuellt_Databasprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_Databasprojekt
{
    internal class StartMenu
    {
        public static void Startmenu()
        {
            using SchoolDbContext context = new SchoolDbContext();
            bool Q = true;
            List<string> menuAlternativeList = new List<string>();

            menuAlternativeList.Add("\tAntal lärare per avdelning");
            menuAlternativeList.Add("\tVisa info om alla elever");
            menuAlternativeList.Add("\tVisa en lista på samtliga aktiva kurser");
            menuAlternativeList.Add("\tAvsluta");

            while (Q)
            {
                int choice = Arrowmenu.startMenuArrow(menuAlternativeList, "");

                var personals = context.TblPersonals.Where(p => p.Titel != -1);
                var students = context.TblStudents.Where(s => s.Klass != 0);
                var kurser = context.TblKurs.Where(k => k.KurskodNy != -1);

                switch (choice)
                {
                    case 0:
                        WriteOutInfo.StaffInfo(context, personals);
                        break;

                    case 1:
                        WriteOutInfo.StudentInfo(context, students);
                        break;

                    case 2:
                        WriteOutInfo.AktivaKurser(context, kurser);
                        break;

                    case 3:
                        Console.WriteLine("Programmet avslutas tryck på valfri tangent");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
           
        }
    }
}
