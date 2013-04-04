// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - SimpleLunarGenerator.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 2:39 PM, 28/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System;
using SolarSystemLibrary.Models;

#endregion

namespace SolarSystemLibrary.Generators {
    ///=================================================================================================
    /// <summary>   Simple lunar generator. </summary>
    ///
    /// <remarks>   Cdo, 3/28/2013. </remarks>
    ///
    /// <seealso cref="ILunarGenerator"/>
    ///=================================================================================================
    public class SimpleLunarGenerator : ILunarGenerator {
        #region Constructors

        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///=================================================================================================
        public SimpleLunarGenerator( ) {
            this.Initialized = false;
        }

        #endregion

        #region Implementation of ILunarGenerator

        ///=================================================================================================
        /// <summary>   Gets or sets a value indicating whether the initialized. </summary>
        ///
        /// <seealso cref="ILunarGenerator.Initialized"/>
        ///=================================================================================================
        public bool Initialized { get; private set; }

        ///=================================================================================================
        /// <summary>   Initializes this object. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <seealso cref="ILunarGenerator.Initialize"/>
        ///=================================================================================================
        public bool Initialize( ) {
            this.Dice = new DiceRoller( );
            this.Initialized = true;
            return true;
        }

        ///=================================================================================================
        /// <summary>   Generates a lunar body. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.ILunarGenerator.GenerateLunarBody(optional PlanetSize,optional int,optional IPlanetaryBody)"/>
        ///
        /// ### <param name="lunarBodySize">        Size of the lunar body. </param>
        /// ### <param name="parentPlanetOrder">    (optional) the parent planet order. </param>
        /// ### <param name="parentPlanet">         The parent planet. </param>
        ///=================================================================================================
        public IPlanetaryBody GenerateLunarBody( PlanetSize lunarBodySize = PlanetSize.NullSize,
                                                 int parentPlanetOrder = -1,
                                                 IPlanetaryBody parentPlanet = null ) {
            var lunar = new LunarBody( );

            // Make sure we're initialized
            if ( !this.Initialized ) {
                return null;
            }

            // Generate moon size/type
            this.RollRandomLunarBodySize( lunar );

            // Generate our diameter
            this.RollDiameter( lunar );

            // Generate our gravity
            this.RollGravity( lunar );

            if ( lunar.Size != PlanetSize.Asteroid &&
                 lunar.Size != PlanetSize.Ring ) {
                // Generate toxicity, pressure, temp
                this.RollPressure( lunar );

                this.RollToxicity( lunar );

                this.RollTemperature( parentPlanetOrder, parentPlanet, lunar );


                // Generate others
                this.RollRadiationLevel( parentPlanetOrder, parentPlanet, lunar );

                this.RollAxialTilt( lunar );

                this.RollLiquidSurfacePercentage( lunar );
            }

            return lunar;
        }

        ///=================================================================================================
        /// <summary>   Generates the rings. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.ILunarGenerator.GenerateRings(optional IPlanetaryBody)"/>
        ///
        /// ### <param name="parentPlanet"> The parent planet. </param>
        ///=================================================================================================
        public IPlanetaryBody GenerateRings( IPlanetaryBody parentPlanet = null ) {
            var lunar = new LunarBody
                            {
                                Size = PlanetSize.Ring,
                                Diameter = this.Dice.d10( ) + ( this.Dice.d100( ) / 100.0 ) - 1,
                                Gravity = 0.01,
                                Pressure = AtmosphericPressure.Vacuum,
                                LiquidSurfacePercentage = 0.0,
                                RadiationLevel = 4
                            };
            return lunar;
        }

        ///=================================================================================================
        /// <summary>   Generates an asteroid. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.ILunarGenerator.GenerateAsteroid(optional IPlanetaryBody)"/>
        ///
        /// ### <param name="parentPlanet"> The parent planet. </param>
        ///=================================================================================================
        public IPlanetaryBody GenerateAsteroid( IPlanetaryBody parentPlanet = null ) {
            var lunar = new LunarBody
                            {
                                Size = PlanetSize.Asteroid,
                                Diameter = this.Dice.d1000( ) + ( this.Dice.d100( ) / 100.0 ) - 1,
                                Gravity = ( this.Dice.d6( ) - 1 ) / 100.0,
                                Pressure = AtmosphericPressure.Vacuum,
                                LiquidSurfacePercentage = 0.0,
                                RadiationLevel = 4
                            };
            return lunar;
        }

        ///=================================================================================================
        /// <summary>   Generates a moon. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.ILunarGenerator.GenerateMoon(optional PlanetSize,optional int,optional IPlanetaryBody)"/>
        ///
        /// ### <param name="moonSize">             Size of the moon. </param>
        /// ### <param name="parentPlanetOrder">    (optional) the parent planet order. </param>
        /// ### <param name="parentPlanet">         The parent planet. </param>
        ///=================================================================================================
        public IPlanetaryBody GenerateMoon( PlanetSize moonSize = PlanetSize.NullSize,
                                            int parentPlanetOrder = -1,
                                            IPlanetaryBody parentPlanet = null ) {
            IPlanetaryBody lunar;

            do {
                lunar = this.GenerateLunarBody( moonSize, parentPlanetOrder, parentPlanet );
            } while ( lunar.Size == PlanetSize.Asteroid ||
                      lunar.Size == PlanetSize.Ring );

            return lunar;
        }

        ///=================================================================================================
        /// <summary>   Generates a habitable moon. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.ILunarGenerator.GenerateHabitableMoon(optional PlanetSize,optional int,optional IPlanetaryBody)"/>
        ///
        /// ### <param name="moonSize">             Size of the moon. </param>
        /// ### <param name="parentPlanetOrder">    (optional) the parent planet order. </param>
        /// ### <param name="parentPlanet">         The parent planet. </param>
        ///=================================================================================================
        public IPlanetaryBody GenerateHabitableMoon( PlanetSize moonSize = PlanetSize.NullSize,
                                                     int parentPlanetOrder = -1,
                                                     IPlanetaryBody parentPlanet = null ) {
            IPlanetaryBody lunar;

            do {
                lunar = this.GenerateLunarBody( moonSize, parentPlanetOrder, parentPlanet );
            } while ( lunar.Habitable == false );

            return lunar;
        }

        #endregion

        #region Properties

        ///=================================================================================================
        /// <summary>   Gets or sets the dice. </summary>
        ///
        /// <value> The dice. </value>
        ///=================================================================================================
        protected DiceRoller Dice { get; set; }

        #endregion

        #region Members

        ///=================================================================================================
        /// <summary>   Roll random lunar body size. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="lunar">    The lunar. </param>
        ///=================================================================================================
        private void RollRandomLunarBodySize( LunarBody lunar ) {
            switch ( this.Dice.Roll( 7 ) ) {
                case 1:
                    lunar.Size = PlanetSize.Asteroid;
                    break;
                case 2:
                    lunar.Size = PlanetSize.SubLunar;
                    break;
                case 3:
                    lunar.Size = PlanetSize.Lunar;
                    break;
                case 4:
                    lunar.Size = PlanetSize.SuperLunar;
                    break;
                case 5:
                    lunar.Size = PlanetSize.SubTerran;
                    break;
                case 6:
                    lunar.Size = PlanetSize.Terran;
                    break;
                case 7:
                    lunar.Size = PlanetSize.Ring;
                    break;
            }
        }

        ///=================================================================================================
        /// <summary>   Roll diameter. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="lunar">    The lunar. </param>
        ///=================================================================================================
        private void RollDiameter( LunarBody lunar ) {
            switch ( lunar.Size ) {
                case PlanetSize.Asteroid:
                    lunar.Diameter = this.Dice.d1000( ) + ( this.Dice.d100( ) / 100.0 ) - 1;
                    break;
                case PlanetSize.SubLunar:
                    lunar.Diameter = 1000 + this.Dice.d1000( ) + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.Lunar:
                    lunar.Diameter = 2000 + this.Dice.d1000( ) + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.SuperLunar:
                    lunar.Diameter = 3000 + ( this.Dice.Roll( 2000 ) ) + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.SubTerran:
                    lunar.Diameter = 5000 + ( this.Dice.Roll( 3000 ) ) + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.Terran:
                    lunar.Diameter = 8000 + ( this.Dice.Roll( 3000 ) ) + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.Ring:
                    lunar.Diameter = this.Dice.d10( ) + ( this.Dice.d100( ) / 100.0 ) - 1;
                    break;
            }
        }

        ///=================================================================================================
        /// <summary>   Roll gravity. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="lunar">    The lunar. </param>
        ///=================================================================================================
        private void RollGravity( LunarBody lunar ) {
            switch ( lunar.Size ) {
                case PlanetSize.Asteroid:
                    lunar.Gravity = ( this.Dice.d6( ) - 1 ) / 100.0;
                    break;
                case PlanetSize.SubLunar:
                    lunar.Gravity = ( this.Dice.Roll( 1, 6, 4 ) ) / 100.0;
                    break;
                case PlanetSize.Lunar:
                    lunar.Gravity = ( this.Dice.Roll( 1, 21, 9 ) ) / 100.0;
                    break;
                case PlanetSize.SuperLunar:
                    lunar.Gravity = ( this.Dice.Roll( 1, 41, 29 ) ) / 100.0;
                    break;
                case PlanetSize.SubTerran:
                    lunar.Gravity = ( this.Dice.Roll( 1, 31, 69 ) ) / 100.0;
                    break;
                case PlanetSize.Terran:
                    lunar.Gravity = ( this.Dice.Roll( 1, 101, 99 ) ) / 100.0;
                    break;
                case PlanetSize.Ring:
                    lunar.Gravity = ( this.Dice.Roll( 1, 2, -1 ) ) / 100.0;
                    break;
            }
        }

        ///=================================================================================================
        /// <summary>   Roll pressure. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="lunar">    The lunar. </param>
        ///=================================================================================================
        private void RollPressure( LunarBody lunar ) {
            switch ( lunar.Size ) {
                case PlanetSize.Asteroid:
                    lunar.Pressure = AtmosphericPressure.Vacuum;
                    break;
                case PlanetSize.SubLunar:
                    lunar.Pressure = AtmosphericPressure.Vacuum;
                    break;
                case PlanetSize.Lunar:
                    lunar.Pressure = (AtmosphericPressure) ( this.Dice.d3( ) - 5 );
                    break;
                case PlanetSize.SuperLunar:
                    lunar.Pressure = (AtmosphericPressure) ( this.Dice.d4( ) - 5 );
                    break;
                case PlanetSize.SubTerran:
                    lunar.Pressure = (AtmosphericPressure) ( this.Dice.d4( ) - 3 );
                    break;
                case PlanetSize.Terran:
                    lunar.Pressure = (AtmosphericPressure) ( this.Dice.d4( ) - 2 );
                    break;
                case PlanetSize.Ring:
                    lunar.Pressure = AtmosphericPressure.Vacuum;
                    break;
            }
        }

        ///=================================================================================================
        /// <summary>   Roll toxicity. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="lunar">    The lunar. </param>
        ///=================================================================================================
        private void RollToxicity( LunarBody lunar ) {
            lunar.Toxicity = (Toxicity) ( this.Dice.d6( ) - 3 );
        }

        ///=================================================================================================
        /// <summary>   Roll temperature. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="parentPlanetOrder">    The parent planet order. </param>
        /// <param name="parentPlanet">         The parent planet. </param>
        /// <param name="lunar">                The lunar. </param>
        ///=================================================================================================
        private void RollTemperature( int parentPlanetOrder, IPlanetaryBody parentPlanet, LunarBody lunar ) {
            var haveOrder = parentPlanetOrder != -1 || ( ( parentPlanet != null && parentPlanet.PlanetOrder != -1 ) );
            if ( haveOrder ) {
                var order = parentPlanetOrder != -1 ? parentPlanetOrder : parentPlanet.PlanetOrder;
                lunar.Temperature =
                    (Temperature)
                    ( order + lunar.Pressure +
                      ( parentPlanet != null &&
                        ( parentPlanet.Size == PlanetSize.SubJovian || parentPlanet.Size == PlanetSize.Jovian ||
                          parentPlanet.Size == PlanetSize.SuperJovian )
                            ? 1
                            : 0 ) );
            } else {
                var order = this.Dice.d10( ) - 5;
                lunar.Temperature =
                    (Temperature)
                    ( order + lunar.Pressure +
                      ( parentPlanet != null &&
                        ( parentPlanet.Size == PlanetSize.SubJovian || parentPlanet.Size == PlanetSize.Jovian ||
                          parentPlanet.Size == PlanetSize.SuperJovian )
                            ? 1
                            : 0 ) );
            }
        }

        ///=================================================================================================
        /// <summary>   Roll radiation level. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="parentPlanetOrder">    The parent planet order. </param>
        /// <param name="parentPlanet">         The parent planet. </param>
        /// <param name="lunar">                The lunar. </param>
        ///=================================================================================================
        private void RollRadiationLevel( int parentPlanetOrder, IPlanetaryBody parentPlanet, LunarBody lunar ) {
            var haveOrder = parentPlanetOrder != -1 || ( ( parentPlanet != null && parentPlanet.PlanetOrder != -1 ) );
            if ( haveOrder ) {
                var order = parentPlanetOrder != -1 ? parentPlanetOrder : parentPlanet.PlanetOrder;

                lunar.RadiationLevel = ( order > 0 ? order : 0 ) -
                                       ( lunar.Pressure < AtmosphericPressure.Standard
                                             ? (int) lunar.Pressure
                                             : 0 );
            } else {
                lunar.RadiationLevel = Math.Abs( (int) lunar.RadiationLevel ) + this.Dice.Roll( 1, 3, -2 );
            }
        }

        ///=================================================================================================
        /// <summary>   Roll axial tilt. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="lunar">    The lunar. </param>
        ///=================================================================================================
        private void RollAxialTilt( LunarBody lunar ) {
            lunar.AxialTilt = this.Dice.Roll( 1, 4500 ) / 100.0;
        }

        ///=================================================================================================
        /// <summary>   Roll liquid surface percentage. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="lunar">    The lunar. </param>
        ///=================================================================================================
        private void RollLiquidSurfacePercentage( IPlanetaryBody lunar ) {
            if ( lunar.Size != PlanetSize.Asteroid && lunar.Size != PlanetSize.Ring &&
                 ( lunar.Habitable || this.Dice.d4( ) == 4 ) ) {
                lunar.LiquidSurfacePercentage = this.Dice.Roll( 10000 ) / 100.0;
            }
        }

        #endregion

        //switch (lunar.Size)
        //{
        //    case PlanetSize.Asteroid:
        //        lunar
        //        break;
        //    case PlanetSize.SubLunar:
        //        lunar
        //        break;
        //    case PlanetSize.Lunar:
        //        lunar
        //        break;
        //    case PlanetSize.SuperLunar:
        //        lunar
        //        break;
        //    case PlanetSize.SubTerran:
        //        lunar
        //        break;
        //    case PlanetSize.Terran:
        //        lunar
        //        break;
        //    case PlanetSize.Ring:
        //        lunar
        //        break;
        //}
    }
}
