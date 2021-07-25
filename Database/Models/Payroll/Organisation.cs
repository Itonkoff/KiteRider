using System;
using System.Collections.Generic;

namespace Fridge.Models.Payroll {
    public class Organisation {
        public Organisation()
        {
            PayRolls = new HashSet<Payroll>();
        }

        public Guid OrganisationId { get; set; }
        public string Name { get; set; }

        public ICollection<Payroll> PayRolls { get; set; }

        // To add NEC, Manpower levy, Standard levy, WICF, Business partner no, PAYE contract no, IC number, standard levy.
    }
}