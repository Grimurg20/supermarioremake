using Veft.SuperMarioRemake.Models.Enums;
using Veft.SuperMarioRemake.Models.Interfaces;
namespace Veft.SuperMarioRemake.Models.Models
{
    public class CommonEnemy : IEnemy
    {
         public string Id  {get; set;}

        public string Name {get; set; } = "";

        public int Health {get; set;}

        public EnemySize EnemySize { get; set; }

    }
}