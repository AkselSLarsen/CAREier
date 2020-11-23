using System.Numerics;

namespace CAREier.Localizers {
    public class LocalizedDimensions {
        private Vector3 _dimensions; //Dimensions in meters

        public Vector3 DimensionsInMeters {
            get { return _dimensions; }
            set { _dimensions = value; }
        }
        public Vector3 DimensionsInCM {
            get { return _dimensions * 100; }
            set { _dimensions = value / 100; }
        }
        public Vector3 DimensionsInFeet {
            get {
                float metersToFeet = 3.2808399f;
                return new Vector3(_dimensions.X * metersToFeet, _dimensions.Y * metersToFeet, _dimensions.Z * metersToFeet);
            }
            set {
                float feetToMeters = 0.3048f;
                _dimensions = new Vector3(value.X * feetToMeters, value.Y * feetToMeters, value.Z * feetToMeters);
            }
        }
    }
}