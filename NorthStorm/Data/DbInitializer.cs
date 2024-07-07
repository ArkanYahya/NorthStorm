using NorthStorm.Models;
using NorthStorm.Models.Assistants;
using NorthStorm.Models.Classifications;

namespace NorthStorm.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NorthStormContext context)
        {
            //context.Database.EnsureCreated();

            // البحث عن أي موظف.
            var genders = new Gender[] { };
            if (!context.Genders.Any())
            {
                genders = new Gender[]
                {
                    new Gender { Name = "ذكر" },
                    new Gender { Name = "أنثى" }
                };
                foreach (Gender g in genders)
                {
                    context.Genders.Add(g);
                }
            }

            var nationalities = new Nationality[] { };
            if (!context.Nationalities.Any())
            {
                nationalities = new Nationality[]
                {
                    new Nationality { Name = "عراقي" },
                    new Nationality { Name = "عربي" },
                    new Nationality { Name = "أجنبي" }
                };
                foreach (Nationality n in nationalities)
                {
                    context.Nationalities.Add(n);
                }
            }


            var races = new Race[] { };
            if (!context.Races.Any())
            {
                races = new Race[]
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
            }

            var religions = new Religion[] { };
            if (!context.Religions.Any())
            {
                religions = new Religion[]
                {
                    new Religion { Name = "مسلم" },
                    new Religion { Name = "مسيحي" },
                    new Religion { Name = "صابئي" },
                    new Religion { Name = "يزيدي" },
                    new Religion { Name = "أخرى" }
                };
                foreach (Religion r in religions)
                {
                    context.Religions.Add(r);
                }
            }

            var statuses = new Status[] { };
            if (!context.Statuses.Any())
            {
                statuses = new Status[]
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
            }

            var locationClassification = new LocationClassification[] { };
            if (!context.LocationClassifications.Any())
            {
                locationClassification = new LocationClassification[]
                {
                    new LocationClassification { Name = "الدولة" },
                    new LocationClassification { Name = "المحافظة" },
                    new LocationClassification { Name = "القضاء" },
                    new LocationClassification { Name = "المنطقة" },
                    new LocationClassification { Name = "الشارع" }
                };
                foreach (LocationClassification s in locationClassification)
                {
                    context.LocationClassifications.Add(s);
                }
            }


            var jobTitleClassifications = new JobTitleClassification[] { };
            if (!context.JobTitleClassifications.Any())
            {
                jobTitleClassifications = new JobTitleClassification[]
                {
                    new JobTitleClassification { Name = "طبي" },
                    new JobTitleClassification { Name = "هندسي" },
                    new JobTitleClassification { Name = "علمي" },
                    new JobTitleClassification { Name = "فني" },
                    new JobTitleClassification { Name = "إداري" },
                    new JobTitleClassification { Name = "حرفي" }
                };
                foreach (JobTitleClassification s in jobTitleClassifications)
                {
                    context.JobTitleClassifications.Add(s);
                }
            }

            if (!context.Employees.Any())
            {
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
            }

            if (!context.Recruitments.Any())
            {
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
            }

            if (!context.Grades.Any())
            {
                var grades = new Grade[]
                {
                    new Grade { Id = 1, GradeNumber = 1, GradeAsWriting = "الاولى", Stage01 = 910000, Stage02 = 930000, Stage03 = 950000, Stage04 = 970000, Stage05 = 990000, Stage06 = 1010000, Stage07 = 1030000, Stage08 = 1050000, Stage09 = 1070000, Stage10 = 1090000, Stage11 = 1110000, AnnualBonus = 20000, MinimumDuration = 0 },
                    new Grade { Id = 2, GradeNumber = 2, GradeAsWriting = "الثانية", Stage01 = 723000, Stage02 = 740000, Stage03 = 757000, Stage04 = 774000, Stage05 = 791000, Stage06 = 808000, Stage07 = 825000, Stage08 = 842000, Stage09 = 859000, Stage10 = 876000, Stage11 = 893000, AnnualBonus = 17000, MinimumDuration = 5 },
                    new Grade { Id = 3, GradeNumber = 3, GradeAsWriting = "الثالثة", Stage01 = 600000, Stage02 = 610000, Stage03 = 620000, Stage04 = 630000, Stage05 = 640000, Stage06 = 650000, Stage07 = 660000, Stage08 = 670000, Stage09 = 680000, Stage10 = 690000, Stage11 = 700000, AnnualBonus = 10000, MinimumDuration = 5 },
                    new Grade { Id = 4, GradeNumber = 4, GradeAsWriting = "الرابعة", Stage01 = 509000, Stage02 = 517000, Stage03 = 525000, Stage04 = 533000, Stage05 = 541000, Stage06 = 549000, Stage07 = 557000, Stage08 = 565000, Stage09 = 573000, Stage10 = 581000, Stage11 = 589000, AnnualBonus = 8000, MinimumDuration = 5 },
                    new Grade { Id = 5, GradeNumber = 5, GradeAsWriting = "الخامسة", Stage01 = 429000, Stage02 = 435000, Stage03 = 441000, Stage04 = 447000, Stage05 = 453000, Stage06 = 459000, Stage07 = 465000, Stage08 = 471000, Stage09 = 477000, Stage10 = 483000, Stage11 = 489000, AnnualBonus = 6000, MinimumDuration = 5 },
                    new Grade { Id = 6, GradeNumber = 6, GradeAsWriting = "السادسة", Stage01 = 362000, Stage02 = 368000, Stage03 = 374000, Stage04 = 380000, Stage05 = 386000, Stage06 = 392000, Stage07 = 398000, Stage08 = 404000, Stage09 = 410000, Stage10 = 416000, Stage11 = 422000, AnnualBonus = 6000, MinimumDuration = 4 },
                    new Grade { Id = 7, GradeNumber = 7, GradeAsWriting = "السابعة", Stage01 = 296000, Stage02 = 302000, Stage03 = 308000, Stage04 = 314000, Stage05 = 320000, Stage06 = 326000, Stage07 = 332000, Stage08 = 338000, Stage09 = 344000, Stage10 = 350000, Stage11 = 356000, AnnualBonus = 6000, MinimumDuration = 4 },
                    new Grade { Id = 8, GradeNumber = 8, GradeAsWriting = "الثامنة", Stage01 = 260000, Stage02 = 263000, Stage03 = 266000, Stage04 = 269000, Stage05 = 272000, Stage06 = 275000, Stage07 = 278000, Stage08 = 281000, Stage09 = 284000, Stage10 = 287000, Stage11 = 290000, AnnualBonus = 3000, MinimumDuration = 4 },
                    new Grade { Id = 9, GradeNumber = 9, GradeAsWriting = "التاسعة", Stage01 = 210000, Stage02 = 213000, Stage03 = 216000, Stage04 = 219000, Stage05 = 222000, Stage06 = 225000, Stage07 = 228000, Stage08 = 231000, Stage09 = 234000, Stage10 = 237000, Stage11 = 240000, AnnualBonus = 3000, MinimumDuration = 4 },
                    new Grade { Id = 10, GradeNumber = 10, GradeAsWriting = "العاشرة", Stage01 = 170000, Stage02 = 173000, Stage03 = 176000, Stage04 = 179000, Stage05 = 182000, Stage06 = 185000, Stage07 = 188000, Stage08 = 191000, Stage09 = 194000, Stage10 = 197000, Stage11 = 200000, AnnualBonus = 3000, MinimumDuration = 4 }
                };
                foreach (Grade r in grades)
                {
                    context.Grades.Add(r);
                }
            }

            context.SaveChanges();

            //var employeeRecruitments = new EmployeeRecruitment[]
            //{
            //        new EmployeeRecruitment { EmployeeId = 1000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "543").Id },
            //        new EmployeeRecruitment { EmployeeId = 2000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "542").Id },
            //        new EmployeeRecruitment { EmployeeId = 3000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "543").Id },
            //        new EmployeeRecruitment { EmployeeId = 4000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "643").Id },
            //        new EmployeeRecruitment { EmployeeId = 5000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "643").Id },
            //        new EmployeeRecruitment { EmployeeId = 6000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "733").Id },
            //        new EmployeeRecruitment { EmployeeId = 7000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "543").Id },
            //        new EmployeeRecruitment { EmployeeId = 8000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "542").Id },
            //        new EmployeeRecruitment { EmployeeId = 9000, RecruitmentId = recruitments.Single( i => i.ReferenceNo == "543").Id },
            //};

            //foreach (EmployeeRecruitment er in employeeRecruitments)
            //{
            //    context.EmployeeRecruitments.Add(er);
            //}
            //context.SaveChanges();


        }
    }
}