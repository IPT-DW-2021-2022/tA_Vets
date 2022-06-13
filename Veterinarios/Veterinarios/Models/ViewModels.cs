namespace Veterinarios.Models {


   /// <summary>
   /// Class to collect owners' data to API
   /// </summary>
   public class OwnerViewModel {

      public int Id { get; set; }
      public string Name { get; set; }
   }



   /// <summary>
   /// this class will collect the data to be sent to API
   /// </summary>
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