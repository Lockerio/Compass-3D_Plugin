using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChandelierPlugin.Model
{
    public class Parameters
    {
        private double _radiusOuterCircle;
        private double _radiusInnerCircle;
        private double _radiusBaseCircle;
        private double _foundationThickness;
        private int _lampsAmount;
        private double _lampRadius;

        public double RadiusOuterCircle
        {
            get { return _radiusOuterCircle; }
            set { _radiusOuterCircle = value; }
        }

        public double RadiusInnerCircle
        {
            get { return _radiusInnerCircle; }
            set { _radiusInnerCircle = value; }
        }

        public double RadiusBaseCircle
        {
            get { return _radiusBaseCircle; }
            set { _radiusBaseCircle = value; }
        }

        public double FoundationThickness
        {
            get { return _foundationThickness; }
            set { _foundationThickness = value; }
        }

        public int LampsAmount
        {
            get { return _lampsAmount; }
            set { _lampsAmount = value; }
        }

        public double LampRadius
        {
            get { return _lampRadius; }
            set { _lampRadius = value; }
        }

        public Parameters()
        {
            RadiusOuterCircle = 800;
            RadiusInnerCircle = 700;
            RadiusBaseCircle = 100;
            FoundationThickness = 60;
            LampsAmount = 12;
            LampRadius = 20;
        }

        public Dictionary<string, object> GetParametersAsDict()
        {
            var parameters = new Dictionary<string, object>
            {
                { "RadiusOuterCircle", RadiusOuterCircle },
                { "RadiusInnerCircle", RadiusInnerCircle },
                { "RadiusBaseCircle", RadiusBaseCircle },
                { "FoundationThickness", FoundationThickness },
                { "LampsAmount", LampsAmount },
                { "LampRadius", LampRadius }
            };
            return parameters;
        }
    }
}
