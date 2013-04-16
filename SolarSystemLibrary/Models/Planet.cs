// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemLibrary - Planet.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 10:25 AM, 16/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System.Collections.Generic;
using System.Linq;

#endregion

namespace SolarSystemLibrary.Models {
    ///=================================================================================================
    /// <summary>   Planet. </summary>
    ///
    /// <remarks>   Cdo, 3/28/2013. </remarks>
    ///
    /// <seealso cref="IPlanetaryBody"/>
    ///=================================================================================================
    public class Planet : IPlanetaryBody {
        #region Constructors

        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///=================================================================================================
        public Planet( ) {
            this.PlanetOrder = -1;
            this.Size = PlanetSize.NullSize;
            this.Diameter = 0.0;
            this.Gravity = 0.0;
            this.Pressure = AtmosphericPressure.Vacuum;
            this.Temperature = Temperature.Vacuum;
            this.Toxicity = Toxicity.NobleGas;
            this.RadiationLevel = -1;
            this.LiquidSurfacePercentage = 0.0;
            this.AxialTilt = 0.0;
        }

        #endregion

        #region Implementation of IPlanetaryBody

        ///=================================================================================================
        /// <summary>   Gets or sets the size. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Size"/>
        ///=================================================================================================
        public PlanetSize Size { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the diameter. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Diameter"/>
        ///=================================================================================================
        public double Diameter { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the gravity. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Gravity"/>
        ///=================================================================================================
        public double Gravity { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the lunar bodies. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.LunarBodies"/>
        ///=================================================================================================
        public IList<IPlanetaryBody> LunarBodies { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the planet order. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.PlanetOrder"/>
        ///=================================================================================================
        public int PlanetOrder { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of moons. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.NumMoons"/>
        ///=================================================================================================
        public int NumMoons {
            get {
                return
                    this.LunarBodies.Count(
                        lunarBody => lunarBody.Size != PlanetSize.Asteroid && lunarBody.Size != PlanetSize.Ring );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of asteroids. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.NumAsteroids"/>
        ///=================================================================================================
        public int NumAsteroids {
            get {
                return
                    this.LunarBodies.Count(
                        lunarBody => lunarBody.Size == PlanetSize.Asteroid );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of rings. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.NumRings"/>
        ///=================================================================================================
        public int NumRings {
            get {
                return
                    this.LunarBodies.Count(
                        lunarBody => lunarBody.Size == PlanetSize.Ring );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the pressure. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Pressure"/>
        ///=================================================================================================
        public AtmosphericPressure Pressure { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the temperature. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Temperature"/>
        ///=================================================================================================
        public Temperature Temperature { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the toxicity. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Toxicity"/>
        ///=================================================================================================
        public Toxicity Toxicity { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the radiation level. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.RadiationLevel"/>
        ///=================================================================================================
        public int RadiationLevel { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets a value indicating whether this object is habitable. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Habitable"/>
        ///=================================================================================================
        public bool Habitable {
            get { return this.IsHabitable( ); }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the occupied. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Occupied"/>
        ///=================================================================================================
        public int Occupied { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the technology level. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.TechnologyLevel"/>
        ///=================================================================================================
        public TechLevel TechnologyLevel { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the liquid surface percentage. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.LiquidSurfacePercentage"/>
        ///=================================================================================================
        public double LiquidSurfacePercentage { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the axial tilt. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.AxialTilt"/>
        ///=================================================================================================
        public double AxialTilt { get; set; }

        #endregion

        #region Members

        protected bool IsHabitable( ) {
            var status = this.Size != PlanetSize.AsteroidBelt;

            if ( (int) this.Temperature < -1 ||
                 (int) this.Temperature > 1 ) {
                status = false;
            }

            if ( (int) this.Pressure < -1 ||
                 (int) this.Pressure > 1 ) {
                status = false;
            }

            if ( (int) this.Toxicity < -1 ||
                 (int) this.Toxicity > 1 ) {
                status = false;
            }

            if ( this.RadiationLevel != 0 ) {
                status = false;
            }

            return status;
        }

        #endregion

        #region Overrides of Object

        ///=================================================================================================
        /// <summary>
        ///     Returns a <see cref="T:System.String"/> that represents the current
        ///     <see cref="T:System.Object"/>.
        /// </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="object.ToString()"/>
        ///
        /// ### <returns>
        ///     A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        ///=================================================================================================
        public override string ToString( ) {
            string result = this.LunarBodies.Aggregate(
                "",
                ( current, body ) =>
                current +
                ( ( this.Size == PlanetSize.SubJovian || this.Size == PlanetSize.Jovian ||
                    this.Size == PlanetSize.SuperJovian ) && body.Size == PlanetSize.Asteroid
                      ? string.Empty
                      : body.ToString( ) ) );
            return
                string.Format(
                    "Planetary Body Kind: {0}\r\n\t" +
                    "Diameter: {1} miles\t\tGravity: {2}G\r\n\t" +
                    "Order: {3}\t\tAtmospheric Pressure: {4}\r\n\t" +
                    "Toxicity: {5}\t\tAverage Temperature: {6}\r\n\t" +
                    "Radiation Level: {7}\t\tHabitability: {8}\r\n\t" +
                    "Percentage of Surface Liquid: {9}\r\n\t" +
                    "Axial Tilt: {10}\t\tNumber of Moons: {11}\r\n\t" +
                    "Numer of Rings: {12}\t\tNumber of Asteroids: {13}\r\n\t" +
                    "Total Lunar Body Count: {14}\r\n\tLunar Bodies:\r\n{15}",
                    this.Size,
                    this.Diameter,
                    this.Gravity,
                    this.PlanetOrder,
                    this.Pressure,
                    this.Toxicity,
                    this.Temperature,
                    this.RadiationLevel,
                    this.Habitable,
                    this.LiquidSurfacePercentage,
                    this.AxialTilt,
                    this.NumMoons,
                    this.NumRings,
                    this.NumAsteroids,
                    this.LunarBodies.Count,
                    result );
        }

        #endregion
    }
}
