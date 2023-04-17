using GeoProfs.Models;

namespace GeoProfs.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GeoProfsContext context)
        {
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

            var employees = new Employee[]
            {
                new Employee{FirstMidName="Carson",LastName="Alexander",Mail="carsona@hotmail.com",EnrollmentDate=DateTime.Parse("2019-09-01"),Role="Employee",IsPresent=true},
                new Employee{FirstMidName="Meredith",LastName="Alonso",Mail="carsona@hotmail.com",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Employee",IsPresent=false},
                new Employee{FirstMidName="Arturo",LastName="Anand",Mail="carsona@hotmail.com",EnrollmentDate=DateTime.Parse("2018-09-01"),Role="Employee",IsPresent=true},
                new Employee{FirstMidName="Gytis",LastName="Barzdukas",Mail="carsona@hotmail.com",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Employee",IsPresent=true},
                new Employee{FirstMidName="Yan",LastName="Li",Mail="carsona@hotmail.com",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Employee",IsPresent=false},
                new Employee{FirstMidName="Peggy",LastName="Justice",Mail="carsona@hotmail.com",EnrollmentDate=DateTime.Parse("2016-09-01"),Role="Employee",IsPresent=true},
                new Employee{FirstMidName="Laura",LastName="Norman",Mail="carsona@hotmail.com",EnrollmentDate=DateTime.Parse("2018-09-01"),Role="Employee",IsPresent=true},
                new Employee{FirstMidName="Nino",LastName="Olivetto",Mail="carsona@hotmail.com",EnrollmentDate=DateTime.Parse("2019-09-01"),Role="Employee",IsPresent=true}
            };

            var calendarEvents = new CalendarEvent[]
            {
                new CalendarEvent{Title="Summer Vacation",Description="Summer Vacation",StartDate=DateTime.Parse("2023-06-01"),EndDate=DateTime.Parse("2023-08-01"),Type="Vacation"},
                new CalendarEvent{Title="Winter Vacation",Description="Winter Vacation",StartDate=DateTime.Parse("2023-11-01"),EndDate=DateTime.Parse("2024-01-01"),Type="Vacation"}
            };

            var absenceProposals = new AbsenceProposal[]
            {
                new AbsenceProposal{Title="Sick Today",ReasonAbsence="Sick",Reasoning="Woke up today with a cold and stomach ache",StartAbsenceDate=DateTime.Parse("2023-03-23"),EndAbsenceDate=DateTime.Parse("2023-03-24"),Accepted=true},
                new AbsenceProposal{Title="Absence Wedding",ReasonAbsence="Other",Reasoning="My brother is going to marry his fiancee and has invited me to be there",StartAbsenceDate=DateTime.Parse("2023-03-24"),EndAbsenceDate=DateTime.Parse("2023-03-25"),Accepted=false}
            };

            context.Employees.AddRange(employees);
            context.CalendarEvents.AddRange(calendarEvents);
            context.AbsenceProposals.AddRange(absenceProposals);
            context.SaveChanges();
        }
    }
}