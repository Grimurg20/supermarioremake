namespace Veft.SuperMarioRemake.Models.Interfaces
{
    public interface IEnemy
    {
         public string Id {get; set;}
         public string Name {get; set;}

         public int Health { get; set; }
    }
}