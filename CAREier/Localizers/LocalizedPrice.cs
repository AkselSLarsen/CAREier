namespace CAREier.Localizers {
    public class LocalizedPrice {
        private double _price; //Price in Euro

        public double PriceDKK {
            get { return _price * 7.5; }
            set { _price = value / 7.5; }
        }

        public double PriceEuro {
            get { return _price; }
            set { _price = value; }
        }

    }
}