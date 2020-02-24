using System.Drawing;

namespace JumpingPlatformGame {
	class Entity {
		public virtual Color Color => Color.Black;
        public virtual void Update(Seconds time) { }
        public WorldPoint Location;
	}

	class MovableEntity : Entity {
        public Movement Horizontal { get; set; }
        public MovableEntity() {
            this.Horizontal = new Movement();
        }
        public override void Update(Seconds time) {
            if (Location.X <= Horizontal.LowerBound || Location.X >= Horizontal.UpperBound) {
                Horizontal.Speed *= -1;
            }
            Location.X += Horizontal.Speed * time;
        }
    }

	class MovableJumpingEntity : MovableEntity {
        public Movement Vertical { get; set; }

        public MovableJumpingEntity() : base() {
            this.Vertical = new Movement();
        }

        public override void Update(Seconds time) {
            if (Location.X <= Horizontal.LowerBound || Location.X >= Horizontal.UpperBound) {
                Horizontal.Speed *= -1;
            }
            Location.X += Horizontal.Speed * time;

            if (Location.Y >= Vertical.UpperBound) {
                Vertical.Speed *= -1;
            }
            else if (Location.Y == Vertical.LowerBound && Vertical.Speed < 0) {
                return;
            }
            else if (Location.Y < Vertical.LowerBound && Vertical.Speed < 0) {
                Location.Y = Vertical.LowerBound;
                return;
            }
            Location.Y += Vertical.Speed * time;
        }
    }

	class Joe : MovableEntity {
		public override string ToString() => "Joe";
		public override Color Color => Color.Blue;
	}

	class Jack : MovableEntity {
		public override string ToString() => "Jack";
		public override Color Color => Color.LightBlue;
	}

	class Jane : MovableJumpingEntity {
		public override string ToString() => "Jane";
		public override Color Color => Color.Red;
	}

	class Jill : MovableJumpingEntity {
		public override string ToString() => "Jill";
		public override Color Color => Color.Pink;
	}

    struct WorldPoint {
        public Meters X { get; set; }
        public Meters Y { get; set; }
    }

    class Movement {
        public Meters LowerBound { get; set; }
        public Meters UpperBound { get; set; }
        public MeterPerSeconds Speed { get; set; }
    }
}