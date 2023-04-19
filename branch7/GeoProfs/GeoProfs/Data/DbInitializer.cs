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
                new Employee{FirstMidName="Carson",LastName="Alexander",Mail="carsona@hotmail.com",EnrollmentDate=DateTime.Parse("2019-09-01"),Role="Employee",IsPresent=true,maxAbsenceDays=30},
                new Employee{FirstMidName="Meredith",LastName="Alonso",Mail="mereditha@hotmail.com",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Employee",IsPresent=false,maxAbsenceDays=30},
                new Employee{FirstMidName="Arturo",LastName="Anand",Mail="arturoa@hotmail.com",EnrollmentDate=DateTime.Parse("2018-09-01"),Role="Employee",IsPresent=true,maxAbsenceDays=30},
                new Employee{FirstMidName="Gytis",LastName="Barzdukas",Mail="gytisb@hotmail.com",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Employee",IsPresent=true,maxAbsenceDays=30},
                new Employee{FirstMidName="Yan",LastName="Li",Mail="yanl@hotmail.com",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Employee",IsPresent=false,maxAbsenceDays=30},
                new Employee{FirstMidName="Peggy",LastName="Justice",Mail="peggyj@hotmail.com",EnrollmentDate=DateTime.Parse("2016-09-01"),Role="Employee",IsPresent=true,maxAbsenceDays=30},
                new Employee{FirstMidName="Laura",LastName="Norman",Mail="lauran@hotmail.com",EnrollmentDate=DateTime.Parse("2018-09-01"),Role="Employee",IsPresent=true,maxAbsenceDays=30},
                new Employee{FirstMidName="Nino",LastName="Olivetto",Mail="ninoo@hotmail.com",EnrollmentDate=DateTime.Parse("2019-09-01"),Role="Employee",IsPresent=true,maxAbsenceDays=30}
            };

            var calendarEvents = new CalendarEvent[]
            {
                new CalendarEvent{Title="Summer Vacation",Description="Summer Vacation",StartDate=DateTime.Parse("2023-06-01"),EndDate=DateTime.Parse("2023-08-01"),Type="Vacation"},
                new CalendarEvent{Title="Winter Vacation",Description="Winter Vacation",StartDate=DateTime.Parse("2023-11-01"),EndDate=DateTime.Parse("2024-01-01"),Type="Vacation"}
            };

            var absenceProposals = new AbsenceProposal[]
            {
                new AbsenceProposal{Title="Sick Today",ReasonAbsence="Sick",Reasoning="Woke up today with a cold and stomach ache",StartAbsenceDate=DateTime.Parse("2023-03-23"),EndAbsenceDate=DateTime.Parse("2023-03-24"),Accepted=true,Rejected=false},
                new AbsenceProposal{Title="Absence Wedding",ReasonAbsence="Other",Reasoning="My brother is going to marry his fiancee and has invited me to be there",StartAbsenceDate=DateTime.Parse("2023-03-24"),EndAbsenceDate=DateTime.Parse("2023-03-25"),Accepted=false,Rejected=true}
            };

            context.Employees.AddRange(employees);
            context.CalendarEvents.AddRange(calendarEvents);
            context.AbsenceProposals.AddRange(absenceProposals);
            context.SaveChanges();
        }
    }
}