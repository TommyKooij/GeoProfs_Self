using GeoProfs.Models;

namespace GeoProfs.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GeoProfsContext context)
        {
            if (context.Teams.Any())
            {
                return;
            }

            // Look for any students.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            if (context.CalendarEvents.Any())
            {
                return;
            }

            if (context.AbsenceProposals.Any())
            {
                return;
            }

            var teams = new Team[]
            {
                new Team{TeamName="Design",Capacity=20,Budget=60000},
                new Team{TeamName="Accountancy",Capacity=10,Budget=20000}
            };

            var employees = new Employee[]
            {
                new Employee{FirstMidName="Carson",LastName="Alexander",Team=teams[0],Mail="carsona@hotmail.com",EnrollmentDate=DateTime.Parse("2019-09-01"),Role="Manager",IsPresent=true,MaxAbsenceDays=30},
                new Employee{FirstMidName="Meredith",LastName="Alonso",Team=teams[0],Mail="mereditha@hotmail.com",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Employee",IsPresent=false,MaxAbsenceDays=30},
                new Employee{FirstMidName="Arturo",LastName="Anand",Team=teams[1],Mail="arturoa@hotmail.com",EnrollmentDate=DateTime.Parse("2018-09-01"),Role="Employee",IsPresent=true,MaxAbsenceDays=30},
                new Employee{FirstMidName="Gytis",LastName="Barzdukas",Team=teams[0],Mail="gytisb@hotmail.com",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Employee",IsPresent=true,MaxAbsenceDays=30},
                new Employee{FirstMidName="Yan",LastName="Li",Team=teams[1],Mail="yanl@hotmail.com",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Manager",IsPresent=false,MaxAbsenceDays=30},
                new Employee{FirstMidName="Peggy",LastName="Justice",Team=teams[0],Mail="peggyj@hotmail.com",EnrollmentDate=DateTime.Parse("2016-09-01"),Role="Employee",IsPresent=true,MaxAbsenceDays=30},
                new Employee{FirstMidName="Laura",LastName="Norman",Team=teams[1],Mail="lauran@hotmail.com",EnrollmentDate=DateTime.Parse("2018-09-01"),Role="Employee",IsPresent=true,MaxAbsenceDays=30},
                new Employee{FirstMidName="Nino",LastName="Olivetto",Team=teams[0],Mail="ninoo@hotmail.com",EnrollmentDate=DateTime.Parse("2019-09-01"),Role="Employee",IsPresent=true,MaxAbsenceDays=30}
            };

            var calendarEvents = new CalendarEvent[]
            {
                new CalendarEvent{Title="Summer Vacation",Description="Summer Vacation",StartDate=DateTime.Parse("2023-06-01"),EndDate=DateTime.Parse("2023-08-01"),Type="Vacation",IsFromUser=""},
                new CalendarEvent{Title="Winter Vacation",Description="Winter Vacation",StartDate=DateTime.Parse("2023-11-01"),EndDate=DateTime.Parse("2024-01-01"),Type="Vacation",IsFromUser=""}
            };

            var absenceProposals = new AbsenceProposal[]
            {
                new AbsenceProposal{Title="Sick Today",ReasonAbsence="Sick",Reasoning="Woke up today with a cold and stomach ache",MailEmployee="arturoa@hotmail.com",MailManager="yanl@hotmail.com",StartAbsenceDate=DateTime.Parse("2023-03-23"),EndAbsenceDate=DateTime.Parse("2023-03-24"),Accepted=true,Rejected=false},
                new AbsenceProposal{Title="Absence Wedding",ReasonAbsence="Other",Reasoning="My brother is going to marry his fiancee and has invited me to be there",MailEmployee="lauran@hotmail.com",MailManager="yanl@hotmail.com",StartAbsenceDate=DateTime.Parse("2023-03-24"),EndAbsenceDate=DateTime.Parse("2023-03-25"),Accepted=false,Rejected=true},
                new AbsenceProposal{Title="test",ReasonAbsence="test",Reasoning="test",MailEmployee="adminadmin@gmail.com",MailManager="adminadmin@gmail.com",StartAbsenceDate=DateTime.Parse("2023-03-23"),EndAbsenceDate=DateTime.Parse("2023-03-24"),Accepted=true,Rejected=false}
            };

            context.Teams.AddRange(teams);
            context.Employees.AddRange(employees);
            context.CalendarEvents.AddRange(calendarEvents);
            context.AbsenceProposals.AddRange(absenceProposals);
            context.SaveChanges();
        }
    }
}