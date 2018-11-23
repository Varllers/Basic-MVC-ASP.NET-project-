using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2clis.Models;

namespace Lab2clis.dataSource
{
    public class Repository {

            private static Developer[] Developers;
            private static Tehnologic[] Tehnologics;

            static Repository()
            {
                CreateTehnologics();
                CreateDevelopers();
            }

            private static void CreateTehnologics()
            {
                Tehnologics = new Tehnologic[4];

                Tehnologic DDLTehn = new Tehnologic();
                DDLTehn.ID = 1;
                DDLTehn.Name = "DDL";

                Tehnologic OOPTech = new Tehnologic();
                OOPTech.ID = 2;
                OOPTech.Name = "OOP";

                Tehnologic BDTehn = new Tehnologic();
                BDTehn.ID = 3;
                BDTehn.Name = "DB";

                Tehnologic NETTech = new Tehnologic();
                NETTech.ID = 4;
                NETTech.Name = ".Net";

                Tehnologics[0] = DDLTehn;
                Tehnologics[1] = OOPTech;
                Tehnologics[2] = BDTehn;
                Tehnologics[3] = NETTech;
            }

            private static void CreateDevelopers()
            {
                Developers = new Developer[2];

                Developer jonDev = new Developer();
                jonDev.ID = 1;
                jonDev.Name = "Jon";
                jonDev.Surname = "Smith";
                jonDev.DateOfBirth = new DateTime(1996, 12, 10);
                jonDev.Tehnologics = new Tehnologic[2];
                jonDev.Tehnologics[0] = Tehnologics[1];
                jonDev.Tehnologics[1] = Tehnologics[2];


            Developer maksDev = new Developer();
            maksDev.ID = 2;
            maksDev.Name = "Maks";
            maksDev.Surname = "Ford";
            maksDev.DateOfBirth = new DateTime(1992, 03, 03);
            maksDev.Tehnologics = new Tehnologic[3];
            maksDev.Tehnologics[0] = Tehnologics[0];
            maksDev.Tehnologics[1] = Tehnologics[3];
            maksDev.Tehnologics[2] = Tehnologics[2];

            Developers[0] = jonDev;
            Developers[1] = maksDev;
            }

            //CRUD
            public static void Delete(int DevID)
            {
                Developers = Developers.Where(s => s.ID != DevID).ToArray();
            }

            public static void Add(Developer newDeveloper)
            {
                var newLength = Developers.Length + 1;
                Array.Resize(ref Developers, newLength);
                Developers[newLength - 1] = newDeveloper;
            }

            public static void Update(int id, Developer developer)
            {
                for (int i = 0; i < Developers.Length; i++)
                {
                    if (Developers[i].ID == id)
                    {
                        Developers[i].ID = developer.ID;
                        Developers[i].Name = developer.Name;
                        Developers[i].Surname = developer.Surname;
                        Developers[i].DateOfBirth = developer.DateOfBirth;
                        Developers[i].Tehnologics = developer.Tehnologics;
                    }
                }
            }

            public static Developer[] Get()
            {
                return Developers;
            }

            public static Developer Get(int id)
            {
                for (int i = 0; i < Developers.Length; i++)
                {
                    if (Developers[i].ID == id)
                    {
                        return Developers[i];
                    }
                }

                return null;
            }
        }
    }

