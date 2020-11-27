namespace CAREier.Localizers {
    public class LocalizedWeight {
        private double _weight; //Weight in Kilograms

        public LocalizedWeight(double weight) {
            _weight = weight;
        }

        public double WeightKilo {
            get { return _weight; }
            set { _weight = value; }
        }

        public double WeightPound {
            get { return _weight * 2.20462262d; }
            set { _weight = value / 2.20462262d; }
        }

    }
}