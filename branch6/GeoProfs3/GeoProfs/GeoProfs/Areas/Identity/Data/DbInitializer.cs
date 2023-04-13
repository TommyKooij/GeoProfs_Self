using GeoProfs.Models;

namespace GeoProfs.Areas.Identity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GeoProfsContext context)
        {
            // Look for any students.
            if (context.Workers.Any())
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

            var workers = new Worker[]
            {
                new Worker{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01"),Role="Employee",IsPresent=true},
                new Worker{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Employee",IsPresent=false},
                new Worker{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01"),Role="Employee",IsPresent=true},
                new Worker{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Employee",IsPresent=true},
                new Worker{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01"),Role="Employee",IsPresent=false},
                new Worker{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01"),Role="Employee",IsPresent=true},
                new Worker{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01"),Role="Employee",IsPresent=true},
                new Worker{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01"),Role="Employee",IsPresent=true}
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

            context.Workers.AddRange(workers);
            context.CalendarEvents.AddRange(calendarEvents);
            context.AbsenceProposals.AddRange(absenceProposals);
            context.SaveChanges();
        }
    }
}
