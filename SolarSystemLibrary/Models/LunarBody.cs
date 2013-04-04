// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - LunarBody.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 12:30 PM, 29/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System.Collections.Generic;

#endregion

namespace SolarSystemLibrary.Models {
    ///=================================================================================================
    /// <summary>   Lunar body. </summary>
    ///
    /// <remarks>   Cdo, 3/28/2013. </remarks>
    ///
    /// <seealso cref="IPlanetaryBody"/>
    ///=================================================================================================
    public class LunarBody : IPlanetaryBody {
        #region Implementation of IPlanetaryBody

        ///=================================================================================================
        /// <summary>   Gets or sets the size. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Size"/>
        ///
        /// ### <value> The size. </value>
        ///=================================================================================================
        public PlanetSize Size { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the diameter. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Diameter"/>
        ///
        /// ### <value> The diameter. </value>
        ///=================================================================================================
        public double Diameter { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the gravity. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Gravity"/>
        ///
        /// ### <value> The gravity. </value>
        ///=================================================================================================
        public double Gravity { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the lunar bodies. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.LunarBodies"/>
        ///
        /// ### <value> The lunar bodies. </value>
        ///=================================================================================================
        public IList<IPlanetaryBody> LunarBodies { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the planet order. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.PlanetOrder"/>
        ///
        /// ### <value> The planet order. </value>
        ///=================================================================================================
        public int PlanetOrder { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of moons. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.NumMoons"/>
        ///
        /// ### <value> The total number of moons. </value>
        ///=================================================================================================
        public int NumMoons { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of asteroids. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.NumAsteroids"/>
        ///
        /// ### <value> The total number of asteroids. </value>
        ///=================================================================================================
        public int NumAsteroids { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of rings. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.NumRings"/>
        ///
        /// ### <value> The total number of rings. </value>
        ///=================================================================================================
        public int NumRings { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the pressure. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Pressure"/>
        ///
        /// ### <value> The pressure. </value>
        ///=================================================================================================
        public AtmosphericPressure Pressure { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the temperature. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Temperature"/>
        ///
        /// ### <value> The temperature. </value>
        ///=================================================================================================
        public Temperature Temperature { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the toxicity. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Toxicity"/>
        ///
        /// ### <value> The toxicity. </value>
        ///=================================================================================================
        public Toxicity Toxicity { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the radiation level. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.RadiationLevel"/>
        ///
        /// ### <value> The radiation level. </value>
        ///=================================================================================================
        public int RadiationLevel { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets a value indicating whether this object is habitable. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Habitable"/>
        ///
        /// ### <value> true if habitable, false if not. </value>
        ///=================================================================================================
        public bool Habitable {
            get { return this.IsHabitable( ); }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the occupied. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.Occupied"/>
        ///
        /// ### <value> The occupied. </value>
        ///=================================================================================================
        public int Occupied { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the technology level. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.TechnologyLevel"/>
        ///
        /// ### <value> The technology level. </value>
        ///=================================================================================================
        public TechLevel TechnologyLevel { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the liquid surface percentage. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.LiquidSurfacePercentage"/>
        ///
        /// ### <value> The liquid surface percentage. </value>
        ///=================================================================================================
        public double LiquidSurfacePercentage { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the axial tilt. </summary>
        ///
        /// <seealso cref="IPlanetaryBody.AxialTilt"/>
        ///
        /// ### <value> The axial tilt. </value>
        ///=================================================================================================
        public double AxialTilt { get; set; }

        #endregion

        #region Members

        ///=================================================================================================
        /// <summary>   Query if this object is habitable. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <returns>   true if habitable, false if not. </returns>
        ///=================================================================================================
        protected bool IsHabitable( ) {
            var status = !( this.Size == PlanetSize.Asteroid || this.Size == PlanetSize.Ring );

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
            return
                string.Format(
                    "Lunar Body Kind: {0}\r\n\tDiameter: {1} miles\t\tGravity: {2}G\r\n\tOrder: {3}\t\tAtmospheric Pressure: {4}\r\n\tToxicity: {5}\t\tAverage Temperature: {6}\r\n\t" +
                    "Radiation Level: {7}\t\tHabitability: {8}\r\n\tPercentage of Surface Liquid: {9}\r\n\tAxial Tilt: {10}\r\n",
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
                    this.AxialTilt );
        }

        #endregion
    }
}
