namespace Veterinarios.Models {


   public class AnimalViewModel {
      public int Id { get; set; }
      public string Name { get; set; }

      public string Breed { get; set; }
      public string Specie { get; set; }
      public double Weight { get; set; }
      public string Photo { get; set; }
      public string OwnerName { get; set; }
   }







   public class ErrorViewModel {
      public string RequestId { get; set; }

      public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
   }
}