using Veft.SuperMarioRemake.Models.Interfaces;
namespace Veft.SuperMarioRemake.Models.Models
{
    public class BossEnemy : IEnemy
    {
        public string Id { get; set;}
        public string Name {get; set;} = "";

        public int Health {get; set;}

        public string AppearsInLevelId {get; set;}


    }
}