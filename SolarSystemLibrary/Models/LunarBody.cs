// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemLibrary - LunarBody.cs 
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
    /// <summary>   Lunar body. </summary>
    ///
    /// <remarks>   Cdo, 3/28/2013. </remarks>
    ///
    /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody"/>
    /// <seealso cref="IPlanetaryBody"/>
    ///=================================================================================================
    public class LunarBody : IPlanetaryBody {
        #region Constructors

        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 4/16/2013. </remarks>
        ///=================================================================================================
        public LunarBody( ) {
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
            this.Constructs = new List<IConstruct>();
        }

        #endregion

        #region Implementation of IPlanetaryBody

        ///=================================================================================================
        /// <summary>   Gets or sets the size. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Size"/>
        /// <seealso cref="IPlanetaryBody.Size"/>
        ///=================================================================================================
        public PlanetSize Size { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the diameter. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Diameter"/>
        /// <seealso cref="IPlanetaryBody.Diameter"/>
        ///=================================================================================================
        public double Diameter { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the gravity. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Gravity"/>
        /// <seealso cref="IPlanetaryBody.Gravity"/>
        ///=================================================================================================
        public double Gravity { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the lunar bodies. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.LunarBodies"/>
        /// <seealso cref="IPlanetaryBody.LunarBodies"/>
        ///=================================================================================================
        public IList<IPlanetaryBody> LunarBodies { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the planet order. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.PlanetOrder"/>
        /// <seealso cref="IPlanetaryBody.PlanetOrder"/>
        ///=================================================================================================
        public int PlanetOrder { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of moons. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.NumMoons"/>
        /// <seealso cref="IPlanetaryBody.NumMoons"/>
        ///=================================================================================================
        public int NumMoons { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of asteroids. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.NumAsteroids"/>
        /// <seealso cref="IPlanetaryBody.NumAsteroids"/>
        ///=================================================================================================
        public int NumAsteroids { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of rings. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.NumRings"/>
        /// <seealso cref="IPlanetaryBody.NumRings"/>
        ///=================================================================================================
        public int NumRings { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the pressure. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Pressure"/>
        /// <seealso cref="IPlanetaryBody.Pressure"/>
        ///=================================================================================================
        public AtmosphericPressure Pressure { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the temperature. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Temperature"/>
        /// <seealso cref="IPlanetaryBody.Temperature"/>
        ///=================================================================================================
        public Temperature Temperature { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the toxicity. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Toxicity"/>
        /// <seealso cref="IPlanetaryBody.Toxicity"/>
        ///=================================================================================================
        public Toxicity Toxicity { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the radiation level. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.RadiationLevel"/>
        /// <seealso cref="IPlanetaryBody.RadiationLevel"/>
        ///=================================================================================================
        public int RadiationLevel { get; set; }

        ///=================================================================================================
        /// <summary>   Gets a value indicating whether this object is habitable. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Habitable"/>
        /// <seealso cref="IPlanetaryBody.Habitable"/>
        ///=================================================================================================
        public bool Habitable {
            get { return this.IsHabitable( ); }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the occupied. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Occupied"/>
        /// <seealso cref="IPlanetaryBody.Occupied"/>
        ///=================================================================================================
        public int Occupied { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the technology level. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.TechnologyLevel"/>
        /// <seealso cref="IPlanetaryBody.TechnologyLevel"/>
        ///=================================================================================================
        public TechLevel TechnologyLevel { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the liquid surface percentage. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.LiquidSurfacePercentage"/>
        /// <seealso cref="IPlanetaryBody.LiquidSurfacePercentage"/>
        ///=================================================================================================
        public double LiquidSurfacePercentage { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the axial tilt. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.AxialTilt"/>
        /// <seealso cref="IPlanetaryBody.AxialTilt"/>
        ///=================================================================================================
        public double AxialTilt { get; set; }

        public IList<IConstruct> Constructs { get; set; }

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
        /// <seealso cref="System.Object.ToString()"/>
        /// <seealso cref="object.ToString()"/>
        ///=================================================================================================
        public override string ToString( ) {
            string construct_result = this.Constructs.Aggregate("", (current, body) => current + body.ToString());

            return
                string.Format(
                    "Lunar Body Kind: {0}\r\n\tDiameter: {1} miles\t\tGravity: {2}G\r\n\tOrder: {3}\t\tAtmospheric Pressure: {4}\r\n\tToxicity: {5}\t\tAverage Temperature: {6}\r\n\t" +
                    "Radiation Level: {7}\t\tHabitability: {8}\r\n\tPercentage of Surface Liquid: {9}\r\n\tAxial Tilt: {10}\r\n\tNumber of Constructs: {11}\r\n\tConstructs: {12}\r\n",
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
                    this.Constructs.Count,
                    construct_result
                    );
        }

        #endregion
    }
}
