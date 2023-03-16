using GeoProfs.Models;

namespace GeoProfs.Data
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

            var workers = new Worker[]
            {
                new Worker{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01"),Role=Role.Employee,IsPresent=true},
                new Worker{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01"),Role=Role.TeamManager,IsPresent=false},
                new Worker{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01"),Role=Role.Employee,IsPresent=true},
                new Worker{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01"),Role=Role.BoardMember,IsPresent=true},
                new Worker{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01"),Role=Role.Employee,IsPresent=false},
                new Worker{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01"),Role=Role.Employee,IsPresent=true},
                new Worker{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01"),Role=Role.Employee,IsPresent=true},
                new Worker{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01"),Role=Role.TeamManager,IsPresent=true}
            };

            context.Workers.AddRange(workers);
            context.SaveChanges();
        }
    }
}