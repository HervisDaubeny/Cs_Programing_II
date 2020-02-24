using System;

namespace JumpingPlatformGame {
    public struct Meters {
        public int Value { get; set; }

        public Meters(int Value) {
            this.Value = Value;
        }

        public static double operator /(Meters met, Seconds sec) {
            return met.Value / sec.Value;
        }

        public static Meters operator +(Meters A, Meters B) {
            return new Meters(A.Value + B.Value);
        }

        public static bool operator >(Meters A, Meters B) {
            if (A.Value > B.Value) {
                return true;
            }

            return false;
        }

        public static bool operator <(Meters A, Meters B) {
            if (A.Value < B.Value) {
                return true;
            }

            return false;
        }

        public static bool operator <=(Meters A, Meters B) {
            if (A.Value <= B.Value) {
                return true;
            }

            return false;
        }

        public static bool operator >=(Meters A, Meters B) {
            if (A.Value >= B.Value) {
                return true;
            }

            return false;
        }

        public static bool operator ==(Meters A, Meters B) {
            if (A.Value == B.Value) {
                return true;
            }

            return false;
        }

        public static bool operator !=(Meters A, Meters B) {
            if (A.Value != B.Value) {
                return true;
            }

            return false;
        }
    }

    public struct Seconds {
        public double Value { get; set; }

        public Seconds(double Value) {
            this.Value = Value;
        }
    }

    public struct MeterPerSeconds {
        public double Value { get; set; }

        public MeterPerSeconds(double Value) {
            this.Value = Value;
        }

        public static Meters operator *(MeterPerSeconds mps, Seconds sec) {

            return new Meters((int) Math.Round(mps.Value * sec.Value));
        }

        public static MeterPerSeconds operator * (MeterPerSeconds mps, int value) {
            return new MeterPerSeconds(mps.Value * value);
        }

        public static bool operator <(MeterPerSeconds mps, int value) {
            if (mps.Value < value) {
                return true;
            }

            return false;
        }

        public static bool operator >(MeterPerSeconds mps, int value) {
            if (mps.Value > value) {
                return true;
            }

            return false;
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

        public static Seconds Seconds(this double value) {
            Seconds sec = new Seconds(value);

            return sec;
        }

        public static MeterPerSeconds MeterPerSeconds(this int value) {
            MeterPerSeconds mps = new MeterPerSeconds(value);

            return mps;
        }
        public static MeterPerSeconds MeterPerSeconds(this double value) {
            MeterPerSeconds mps = new MeterPerSeconds(value);

            return mps;
        }
    }
}