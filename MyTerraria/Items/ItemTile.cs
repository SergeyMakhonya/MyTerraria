using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTerraria.Items
{
    // Предмет "Плитка"
    class ItemTile : Item
    {
        public ItemTile(World world, InfoItem infoItem) : base(world, infoItem)
        {
        }

        public override void OnWallCollided()
        {
        }
    }
}
