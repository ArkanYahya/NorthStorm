using NorthStorm.Models;

namespace NorthStorm.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NorthStormContext context)
        {
            //context.Database.EnsureCreated();

            // البحث عن أي موظف.
            if (context.Genders.Any())
            {
                return;   // تمت تغذية البيانات
            }

            var genders = new Gender[]
           {
                new Gender { Name = "ذكر" },
                new Gender { Name = "أنثى" }
           };
            foreach (Gender g in genders)
            {
                context.Genders.Add(g);
            }
            context.SaveChanges();


            var nationalities = new Nationality[]
            {
                new Nationality { Name = "عراقي" },
                new Nationality { Name = "عربي" },
                new Nationality { Name = "أجنبي" }
            };
            foreach (Nationality n in nationalities)
            {
                context.Nationalities.Add(n);
            }
            context.SaveChanges();


            var races = new Race[]
            {
                new Race { Name = "عربي" },
                new Race { Name = "كردي" },
                new Race { Name = "تركماني" },
                new Race { Name = "أشوري" },
                new Race { Name = "أخرى" }
            };
            foreach (Race r in races)
            {
                context.Races.Add(r);
            }
            context.SaveChanges();


            var religions = new Religion[]
            {
                new Religion { Name = "مسلم" },
                new Religion { Name = "مسيحي" },
                new Religion { Name = "صابئي" },
                new Religion { Name = "يزيدي" },
                new Religion { Name = "أخرى" }
            };
            foreach (Religion r in religions)
            {
                context.Religiones.Add(r);
            }
            context.SaveChanges();


            var statuses = new Status[]
            {
                new Status { Name = "مستمر" },
                new Status { Name = "متقاعد" },
                new Status { Name = "متوفي" },
                new Status { Name = "موقوف" },
                new Status { Name = "مفقود" },
                new Status { Name = "أخرى" }
            };
            foreach (Status s in statuses)
            {
                context.Statuses.Add(s);
            }
            context.SaveChanges();


            var employees = new Employee[]
                {
                new Employee {Id = 1000, FirstName = "احمد", MiddleName = "علي",   LastName = "عبد الحكيم", BirthDate = DateTime.Parse("1990-09-01"), MotherFirstName = "فاطمة", MotherMiddleName = "علي", MotherLastName = "احمد",
                    GenderId =  genders.Single( i => i.Name == "ذكر").Id,
                    NationalityId = nationalities.Single( i => i.Name == "عراقي").Id,
                    RaceId = races.Single( i => i.Name == "عربي").Id,
                    ReligionId = religions.Single( i => i.Name == "مسلم").Id,
                    StatusId = statuses.Single( i => i.Name == "مستمر").Id,},
                new Employee {Id = 2000, FirstName = "غالب", MiddleName = "وائل",   LastName = "سلام", BirthDate = DateTime.Parse("1988-02-11"), MotherFirstName = "سليمة", MotherMiddleName = "عادل", MotherLastName = "سمير",
                    GenderId =  genders.Single( i => i.Name == "ذكر").Id,
                    NationalityId = nationalities.Single( i => i.Name == "عراقي").Id,
                    RaceId = races.Single( i => i.Name == "عربي").Id,
                    ReligionId = religions.Single( i => i.Name == "مسيحي").Id,
                    StatusId = statuses.Single( i => i.Name == "مستمر").Id,},
                new Employee {Id = 3000, FirstName = "محمد", MiddleName = "كامل",   LastName = "دريد", BirthDate = DateTime.Parse("2000-02-05"), MotherFirstName = "زهراء", MotherMiddleName = "خليل", MotherLastName = "ابراهيم",
                    GenderId =  genders.Single( i => i.Name == "ذكر").Id,
                    NationalityId = nationalities.Single( i => i.Name == "عربي").Id,
                    RaceId = races.Single( i => i.Name == "كردي").Id,
                    ReligionId = religions.Single( i => i.Name == "مسلم").Id,
                    StatusId = statuses.Single( i => i.Name == "مستمر").Id,},
                new Employee {Id = 4000, FirstName = "تحسين", MiddleName = "علي",   LastName = "ابراهيم", BirthDate = DateTime.Parse("1952-07-01"), MotherFirstName = "علياء", MotherMiddleName = "احمد", MotherLastName = "فاضل",
                    GenderId =  genders.Single( i => i.Name == "ذكر").Id,
                    NationalityId = nationalities.Single( i => i.Name == "عراقي").Id,
                    RaceId = races.Single( i => i.Name == "عربي").Id,
                    ReligionId = religions.Single( i => i.Name == "مسلم").Id,
                    StatusId = statuses.Single( i => i.Name == "متقاعد").Id,},
                new Employee {Id = 5000, FirstName = "فؤاد", MiddleName = "جمال",   LastName = "علي", BirthDate = DateTime.Parse("1969-11-30"), MotherFirstName = "سميرة", MotherMiddleName = "علي", MotherLastName = "احمد",
                    GenderId =  genders.Single( i => i.Name == "ذكر").Id,
                    NationalityId = nationalities.Single( i => i.Name == "عراقي").Id,
                    RaceId = races.Single( i => i.Name == "تركماني").Id,
                    ReligionId = religions.Single( i => i.Name == "مسيحي").Id,
                    StatusId = statuses.Single( i => i.Name == "مستمر").Id,},
                new Employee {Id = 6000, FirstName = "جاسم", MiddleName = "ناصر",   LastName = "احمد", BirthDate = DateTime.Parse("1975-06-25"), MotherFirstName = "وداد", MotherMiddleName = "جاسم", MotherLastName = "محمد",
                    GenderId =  genders.Single( i => i.Name == "ذكر").Id,
                    NationalityId = nationalities.Single( i => i.Name == "عربي").Id,
                    RaceId = races.Single( i => i.Name == "عربي").Id,
                    ReligionId = religions.Single( i => i.Name == "مسلم").Id,
                    StatusId = statuses.Single( i => i.Name == "مستمر").Id,},
                new Employee {Id = 7000, FirstName = "خلف", MiddleName = "كمال",   LastName = "مهند", BirthDate = DateTime.Parse("1985-02-12"), MotherFirstName = "فاطمة", MotherMiddleName = "محمود", MotherLastName = "عباس",
                    GenderId =  genders.Single( i => i.Name == "ذكر").Id,
                    NationalityId = nationalities.Single( i => i.Name == "عراقي").Id,
                    RaceId = races.Single( i => i.Name == "عربي").Id,
                    ReligionId = religions.Single( i => i.Name == "مسلم").Id,
                    StatusId = statuses.Single( i => i.Name == "مستمر").Id,},
                new Employee {Id = 8000, FirstName = "ساهرة", MiddleName = "محمد علي",   LastName = "مصطفى", BirthDate = DateTime.Parse("1986-08-22"), MotherFirstName = "كريمة", MotherMiddleName = "سامر", MotherLastName = "جبر",
                    GenderId =  genders.Single( i => i.Name == "أنثى").Id,
                    NationalityId = nationalities.Single( i => i.Name == "عراقي").Id,
                    RaceId = races.Single( i => i.Name == "كردي").Id,
                    ReligionId = religions.Single( i => i.Name == "مسلم").Id,
                    StatusId = statuses.Single( i => i.Name == "مستمر").Id,},
                new Employee {Id = 9000, FirstName = "منى", MiddleName = "عبد الله",   LastName = "باسم", BirthDate = DateTime.Parse("1992-12-01"), MotherFirstName = "نبيلة", MotherMiddleName = "نائل", MotherLastName = "خليل",
                    GenderId =  genders.Single( i => i.Name == "أنثى").Id,
                    NationalityId = nationalities.Single( i => i.Name == "عراقي").Id,
                    RaceId = races.Single( i => i.Name == "عربي").Id,
                    ReligionId = religions.Single( i => i.Name == "مسلم").Id,
                    StatusId = statuses.Single( i => i.Name == "مستمر").Id,}
                };

            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();



            var recruitments = new Recruitment[]
            {
                new Recruitment { ReferenceNo="543", ReferenceDate= DateTime.Parse("1995-03-11"), Subject="امر اداري 653" },
                new Recruitment { ReferenceNo="643", ReferenceDate= DateTime.Parse("1999-04-22"), Subject="امر اداري 873" },
                new Recruitment { ReferenceNo="542", ReferenceDate= DateTime.Parse("2012-11-18"), Subject="امر اداري 82" },
                new Recruitment { ReferenceNo="733", ReferenceDate= DateTime.Parse("2018-01-30"), Subject="امر اداري 982" }
            };

            foreach (Recruitment r in recruitments)
            {
                context.Recruitments.Add(r);
            }
            context.SaveChanges();



            var employeeRecruitments = new EmployeeRecruitment[]
            {
                    new EmployeeRecruitment { EmployeeId = 1000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "543").Id },
                    new EmployeeRecruitment { EmployeeId = 2000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "542").Id },
                    new EmployeeRecruitment { EmployeeId = 3000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "543").Id },
                    new EmployeeRecruitment { EmployeeId = 4000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "643").Id },
                    new EmployeeRecruitment { EmployeeId = 5000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "643").Id },
                    new EmployeeRecruitment { EmployeeId = 6000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "733").Id },
                    new EmployeeRecruitment { EmployeeId = 7000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "543").Id },
                    new EmployeeRecruitment { EmployeeId = 8000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "542").Id },
                    new EmployeeRecruitment { EmployeeId = 9000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "543").Id },
            };

            foreach (EmployeeRecruitment er in employeeRecruitments)
            {
                context.EmployeeRecruitments.Add(er);
            }
            context.SaveChanges();


        }
    }
}