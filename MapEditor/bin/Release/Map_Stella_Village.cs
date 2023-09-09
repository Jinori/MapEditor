
namespace Ealadh
{
    class Map_Stella_Village : Map
    {
        public Map_Stella_Village()
            : base(70, 70)
        {
            this.Number = 6700;
            this.Name = "Stella Village";
            this.Music = 11;
            this.HasDayNight = true;

            // stuff in [] is optional and can be omitted. their default values are used if omitted.

            // This will create a flood-range spawn (fill all available tiles from start point)
            // Spawn.Create<TNpc>(int max, int rate, int x, int y[, bool specificTime = false, Time spawnTime = Time.Day])
            // ex: Spawn.Create<Monster_Spider_01>(10, 25000, 15, 15);
            // ex: Spawn.Create<Monster_Spider_01>(10, 25000, 15, 15, true, Time.Day);

            // This will create a single-tile spawn.
            // Spawn.Create<TNpc>(int max, int rate, int x, int y, Direction d[, bool specificTime = false, Time spawnTime = Time.Day])
            // ex: Spawn.Create<Npc_Heiler>(10, 25000, 15, 15, Direction.South);
            // ex: Spawn.Create<Npc_Heiler>(10, 25000, 15, 15, Direction.South, true, Time.Night);

            // This will create a rectangle-range spawn (x/y is top corner)
            // Spawn.Create<TNpc>(int max, int rate, int x, int y, int width, int height[, bool specificTime = false, Time spawnTime = Time.Day])
            // ex: Spawn.Create<Monster_Spider_01>(10, 25000, 15, 15, 5, 5);
            // ex: Spawn.Create<Monster_Spider_01>(10, 25000, 15, 15, 5, 5, true, Time.Day);

            // Adding spawns can be done one of two ways:
            // var spawn1 = Spawn.Create(...);
            // this.Spawns.Add(spawn1);
            // - OR -
            // this.Spawns.Add(Spawn.Create(...));

            this.Spawns.Add(Spawn.Create<Npc_Melorin>(1, 15000, 40, 34, Direction.North));
            this.Spawns.Add(Spawn.Create<Npc_Joy>(1, 15000, 27, 61, Direction.West));
            this.Spawns.Add(Spawn.Create<Npc_Balloon_Attendant>(1, 15000, 30, 39, Direction.North));
            this.Spawns.Add(Spawn.Create<Monster_Stella_Wisp>(20, 15000, 39, 39, true, Time.Night));

            this.Warps[46, 47] = new Warp(6722, new Point(10, 5), 1, 100, false);

            this.Warps[30, 28] = new Warp(6720, new Point(14, 12), 1, 100, false);
            this.Warps[33, 27] = new Warp(6721, new Point(12, 7), 1, 100, false);

            this.Warps[69, 26] = new Warp(6701, new Point(1, 10), 1, 100, false);
            this.Warps[69, 27] = new Warp(6701, new Point(1, 11), 1, 100, false);
            this.Warps[69, 28] = new Warp(6701, new Point(1, 12), 1, 100, false);
            this.Warps[69, 29] = new Warp(6701, new Point(1, 13), 1, 100, false);

            this.Warps[29, 69] = new Warp(4604, new Point(27, 1), 1, 100, false);
            this.Warps[30, 69] = new Warp(4604, new Point(27, 1), 1, 100, false);
            this.Warps[31, 69] = new Warp(4604, new Point(27, 1), 1, 100, false);
            this.Warps[32, 69] = new Warp(4604, new Point(28, 1), 1, 100, false);
            this.Warps[33, 69] = new Warp(4604, new Point(28, 1), 1, 100, false);
            this.Warps[34, 69] = new Warp(4604, new Point(28, 1), 1, 100, false);

            this.Warps[50, 25] = new Warp(6716, new Point(9, 18), 1, 100, false);
        }

        public override void OnTick()
        {

        }
    }
}