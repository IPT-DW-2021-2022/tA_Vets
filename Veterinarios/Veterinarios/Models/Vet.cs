namespace Veterinarios.Models {
   public class Vet {

      public Vet() {
         Appointements = new HashSet<Appointement>();
      }

      public int Id { get; set; }  

      public string Name { get; set; }

      public string ProfessionalLicense { get; set; }

      public string Photo { get; set; }


      public ICollection<Appointement> Appointements { get; set; }
   }
}
