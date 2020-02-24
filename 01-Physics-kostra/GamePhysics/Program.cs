using System;

namespace GamePhysics {

	class Program {
		static void Main(string[] args) {
			var distance = 2.Meters();
			var time = 3.Seconds();
			var speed = distance / time;
			Console.WriteLine($"Speed: {speed}");
		}
	}

    struct Meters {
        public int Value { get; set; }

        public Meters(int Value) {
            this.Value = Value;
        }

        public static double operator /(Meters met, Seconds sec) {
            return met.Value / sec.Value;
        }
    }

    struct Seconds {
        public double Value { get; set; }

        public Seconds(double Value) {
            this.Value = Value;
        }
    }

    static class Extensions {
        public static Meters Meters(this int value) {
            Meters met = new Meters(value);

            return met;
        }

        public static Seconds Seconds(this int value) {
            Seconds sec = new Seconds(value);

            return sec;
        }

    }

    
}
