using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data {
    public class SeedingService {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context) {
            _context = context;
        }

        public void Seed() {
            if (_context.Department.Any() || 
                _context.Seller.Any() ||
                _context.SalesRecord.Any()) {
                return; // DB has been seeded
            }
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Brob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SalesStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 4), 7000.0, SalesStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2020, 09, 4), 8000.0, SalesStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2019, 09, 4), 5000.0, SalesStatus.Billed, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2017, 09, 4), 4000.0, SalesStatus.Billed, s5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2016, 09, 4), 3000.0, SalesStatus.Billed, s6);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6);

            _context.SaveChanges();
        }
    }
}
