// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - SimplePlanetGenerator.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 8:50 AM, 29/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System;
using System.Collections.Generic;
using SolarSystemLibrary.Models;

#endregion

namespace SolarSystemLibrary.Generators {
    ///=================================================================================================
    /// <summary>   Simple planet generator. </summary>
    ///
    /// <remarks>   Cdo, 3/29/2013. </remarks>
    ///
    /// <seealso cref="IPlanetaryGenerator"/>
    ///=================================================================================================
    public class SimplePlanetGenerator : IPlanetaryGenerator {
        #region Constructors

        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///=================================================================================================
        public SimplePlanetGenerator( ) {
            this.Initialized = false;
        }

        ///=================================================================================================
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <param name="lunarGenerator">   (optional) the lunar generator. </param>
        ///=================================================================================================
        public SimplePlanetGenerator( ILunarGenerator lunarGenerator ) {
            this.Initialized = false;
            this.LunarGenerator = lunarGenerator;
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

        #region Implementation of IPlanetaryGenerator

        ///=================================================================================================
        /// <summary>   Gets or sets the lunar generator. </summary>
        ///
        /// <seealso cref="IPlanetaryGenerator.LunarGenerator"/>
        ///=================================================================================================
        public ILunarGenerator LunarGenerator { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets a value indicating whether the initialized. </summary>
        ///
        /// <seealso cref="IPlanetaryGenerator.Initialized"/>
        ///=================================================================================================
        public bool Initialized { get; private set; }

        ///=================================================================================================
        /// <summary>   Initializes this object. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="IPlanetaryGenerator.Initialize"/>
        ///=================================================================================================
        public bool Initialize( ) {
            this.Dice = new DiceRoller( );
            return this.LunarGenerator != null;
        }

        ///=================================================================================================
        /// <summary>   Generates a planetary body. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.IPlanetaryGenerator.GeneratePlanetaryBody(optional PlanetSize,optional int,optional int,optional int,optional int,optional int,optional double,optional TechLevel,optional ISolarSystem,optional ILunarGenerator)"/>
        ///
        /// ### <param name="size">             (optional) the size. </param>
        /// ### <param name="lunarBodyCount">   (optional) number of lunar bodies. </param>
        /// ### <param name="ringCount">        (optional) number of rings. </param>
        /// ### <param name="asteroidCount">    (optional) number of asteroids. </param>
        /// ### <param name="moonCount">        (optional) number of moons. </param>
        /// ### <param name="planetOrder">      (optional) the planet order. </param>
        /// ### <param name="waterCoverage">    (optional) the water coverage. </param>
        /// ### <param name="techLevel">        (optional) the technology level. </param>
        /// ### <param name="parentSystem">     (optional) the parent system. </param>
        /// ### <param name="lunarGenerator">   (optional) the lunar generator. </param>
        ///=================================================================================================
        public IPlanetaryBody GeneratePlanetaryBody( PlanetSize size = PlanetSize.NullSize,
                                                     int lunarBodyCount = -1,
                                                     int ringCount = -1,
                                                     int asteroidCount = -1,
                                                     int moonCount = -1,
                                                     int planetOrder = -1,
                                                     double waterCoverage = -1,
                                                     TechLevel techLevel = TechLevel.Uninhabited,
                                                     ISolarSystem parentSystem = null,
                                                     ILunarGenerator lunarGenerator = null ) {
            var planet = new Planet( );
            var localLunar = lunarGenerator ?? this.LunarGenerator;

            // Set planet order, if there is one
            if ( planetOrder != -1 ) {
                planet.PlanetOrder = planetOrder;
            }

            // Generate planet size
            if ( size != PlanetSize.NullSize ) {
                planet.Size = size;
            } else {
                this.RollRandomPlanetSize( planet );
            }

            // Generate diameter/gravity
            this.RollDiameter( planet );
            this.RollGravity( planet );

            // Generate pressure and toxicity
            this.RollPressure( planet );
            this.RollToxicity( planet );

            // Generate radiation
            this.RollRadiationLevel( planet, parentSystem );

            // Generate numMoons
            // Bugs in here: Doesn't account for if lunarbodycount is set as well as ring/asteroid/moon count but aren't equal
            // Doesn't account for rings in while loop
            int numMoons, numAsteroids;
            do {
                this.RollNumMoons( planet, out numAsteroids, out numMoons );
                numMoons = moonCount != -1 ? moonCount : numMoons;
                numAsteroids = asteroidCount != -1 ? asteroidCount : numAsteroids;
            } while ( lunarBodyCount > -1 &&
                      numMoons + numAsteroids != lunarBodyCount );

            // Generate moons
            this.RollMoons( localLunar, numAsteroids, numMoons, planet, ringCount );

            // Generate temperature
            this.RollTemperature( planet, parentSystem );

            // Generate liquid water coverage and tilt
            this.RollLiquidSurfacePercentage( planet );
            if ( waterCoverage > -1 ) {
                planet.LiquidSurfacePercentage = waterCoverage;
            }
            this.RollAxialTilt( planet );

            // Generate populated


            // Anything else?

            return planet;
        }

        ///=================================================================================================
        /// <summary>   Generates an asteroid belt. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.IPlanetaryGenerator.GenerateAsteroidBelt(optional ISolarSystem)"/>
        ///
        /// ### <param name="parentSystem"> (optional) the parent system. </param>
        ///=================================================================================================
        public IPlanetaryBody GenerateAsteroidBelt( ISolarSystem parentSystem = null ) {
            IPlanetaryBody planet;

            do {
                planet = this.GeneratePlanetaryBody( parentSystem: parentSystem );
            } while ( planet.Size !=
                      PlanetSize.AsteroidBelt );

            return planet;
        }

        ///=================================================================================================
        /// <summary>   Generates a solid planet. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.IPlanetaryGenerator.GenerateSolidPlanet(optional PlanetSize,optional int,optional int,optional int,optional int,optional int,optional double,optional TechLevel,optional ISolarSystem,optional ILunarGenerator)"/>
        ///
        /// ### <param name="size">             (optional) the size. </param>
        /// ### <param name="lunarBodyCount">   (optional) number of lunar bodies. </param>
        /// ### <param name="ringCount">        (optional) number of rings. </param>
        /// ### <param name="asteroidCount">    (optional) number of asteroids. </param>
        /// ### <param name="moonCount">        (optional) number of moons. </param>
        /// ### <param name="planetOrder">      (optional) the planet order. </param>
        /// ### <param name="waterCoverage">    (optional) the water coverage. </param>
        /// ### <param name="techLevel">        (optional) the technology level. </param>
        /// ### <param name="parentSystem">     (optional) the parent system. </param>
        /// ### <param name="lunarGenerator">   (optional) the lunar generator. </param>
        ///=================================================================================================
        public IPlanetaryBody GenerateSolidPlanet( PlanetSize size = PlanetSize.NullSize,
                                                   int lunarBodyCount = -1,
                                                   int ringCount = -1,
                                                   int asteroidCount = -1,
                                                   int moonCount = -1,
                                                   int planetOrder = -1,
                                                   double waterCoverage = -1,
                                                   TechLevel techLevel = TechLevel.Uninhabited,
                                                   ISolarSystem parentSystem = null,
                                                   ILunarGenerator lunarGenerator = null ) {
            IPlanetaryBody planet;

            do {
                planet = this.GeneratePlanetaryBody(
                    size,
                    lunarBodyCount,
                    ringCount,
                    asteroidCount,
                    moonCount,
                    planetOrder,
                    waterCoverage,
                    techLevel,
                    parentSystem,
                    lunarGenerator );
            } while ( planet.Size == PlanetSize.AsteroidBelt || planet.Size == PlanetSize.SubJovian ||
                      planet.Size == PlanetSize.Jovian ||
                      planet.Size == PlanetSize.SuperJovian );

            return planet;
        }

        ///=================================================================================================
        /// <summary>   Generates the gas giant planet. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.IPlanetaryGenerator.GenerateGasGiantPlanet(optional PlanetSize,optional int,optional int,optional int,optional int,optional int,optional ISolarSystem,optional ILunarGenerator)"/>
        ///
        /// ### <param name="size">             (optional) the size. </param>
        /// ### <param name="lunarBodyCount">   (optional) number of lunar bodies. </param>
        /// ### <param name="ringCount">        (optional) number of rings. </param>
        /// ### <param name="asteroidCount">    (optional) number of asteroids. </param>
        /// ### <param name="moonCount">        (optional) number of moons. </param>
        /// ### <param name="planetOrder">      (optional) the planet order. </param>
        /// ### <param name="parentSystem">     (optional) the parent system. </param>
        /// ### <param name="lunarGenerator">   (optional) the lunar generator. </param>
        ///=================================================================================================
        public IPlanetaryBody GenerateGasGiantPlanet( PlanetSize size = PlanetSize.NullSize,
                                                      int lunarBodyCount = -1,
                                                      int ringCount = -1,
                                                      int asteroidCount = -1,
                                                      int moonCount = -1,
                                                      int planetOrder = -1,
                                                      ISolarSystem parentSystem = null,
                                                      ILunarGenerator lunarGenerator = null ) {
            IPlanetaryBody planet;

            do {
                planet = this.GeneratePlanetaryBody(
                    size,
                    lunarBodyCount,
                    ringCount,
                    asteroidCount,
                    moonCount,
                    planetOrder,
                    parentSystem: parentSystem,
                    lunarGenerator: lunarGenerator );
            } while ( planet.Size != PlanetSize.SubJovian &&
                      planet.Size != PlanetSize.Jovian &&
                      planet.Size != PlanetSize.SuperJovian );

            return planet;
        }

        ///=================================================================================================
        /// <summary>   Generates a habitable planet. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.IPlanetaryGenerator.GenerateHabitablePlanet(optional PlanetSize,optional int,optional int,optional int,optional int,optional int,optional double,optional TechLevel,optional ISolarSystem,optional ILunarGenerator)"/>
        ///
        /// ### <param name="size">             (optional) the size. </param>
        /// ### <param name="lunarBodyCount">   (optional) number of lunar bodies. </param>
        /// ### <param name="ringCount">        (optional) number of rings. </param>
        /// ### <param name="asteroidCount">    (optional) number of asteroids. </param>
        /// ### <param name="moonCount">        (optional) number of moons. </param>
        /// ### <param name="planetOrder">      (optional) the planet order. </param>
        /// ### <param name="waterCoverage">    (optional) the water coverage. </param>
        /// ### <param name="techLevel">        (optional) the technology level. </param>
        /// ### <param name="parentSystem">     (optional) the parent system. </param>
        /// ### <param name="lunarGenerator">   (optional) the lunar generator. </param>
        ///=================================================================================================
        public IPlanetaryBody GenerateHabitablePlanet( PlanetSize size = PlanetSize.NullSize,
                                                       int lunarBodyCount = -1,
                                                       int ringCount = -1,
                                                       int asteroidCount = -1,
                                                       int moonCount = -1,
                                                       int planetOrder = -1,
                                                       double waterCoverage = -1,
                                                       TechLevel techLevel = TechLevel.Uninhabited,
                                                       ISolarSystem parentSystem = null,
                                                       ILunarGenerator lunarGenerator = null ) {
            IPlanetaryBody planet;

            do {
                planet = this.GeneratePlanetaryBody(
                    size,
                    lunarBodyCount,
                    ringCount,
                    asteroidCount,
                    moonCount,
                    planetOrder,
                    waterCoverage,
                    techLevel,
                    parentSystem,
                    lunarGenerator );
            } while ( !planet.Habitable );

            return planet;
        }

        #endregion

        #region Members

        ///=================================================================================================
        /// <summary>   Roll random planet body size. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="planet">   The planet. </param>
        ///=================================================================================================
        private void RollRandomPlanetSize( IPlanetaryBody planet ) {
            planet.Size = (PlanetSize) this.Dice.d10( );
        }

        ///=================================================================================================
        /// <summary>   Roll diameter. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="planet">   The planet. </param>
        ///=================================================================================================
        private void RollDiameter( IPlanetaryBody planet ) {
            switch ( planet.Size ) {
                case PlanetSize.AsteroidBelt:
                    planet.Diameter = this.Dice.d1000( ) + ( this.Dice.d100( ) / 100.0 ) - 1;
                    break;
                case PlanetSize.SubLunar:
                    planet.Diameter = 1000 + this.Dice.d1000( ) + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.Lunar:
                    planet.Diameter = 2000 + this.Dice.d1000( ) + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.SuperLunar:
                    planet.Diameter = 3000 +  this.Dice.Roll( 2000 )  + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.SubTerran:
                    planet.Diameter = 5000 +  this.Dice.Roll( 3000 )  + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.Terran:
                    planet.Diameter = 8000 +  this.Dice.Roll( 3000 )  + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.SuperTerran:
                    planet.Diameter = 11000 +  this.Dice.Roll( 9000 )  + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.SubJovian:
                    planet.Diameter = 20000 +  this.Dice.Roll( 30000 )  + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.Jovian:
                    planet.Diameter = 50000 +  this.Dice.Roll( 50000 )  + ( this.Dice.d100( ) / 100.0 );
                    break;
                case PlanetSize.SuperJovian:
                    planet.Diameter = 100000 +  this.Dice.Roll( 100000 )  + ( this.Dice.d100( ) / 100.0 );
                    break;
            }
        }

        ///=================================================================================================
        /// <summary>   Roll gravity. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="planet">   The planet. </param>
        ///=================================================================================================
        private void RollGravity( IPlanetaryBody planet ) {
            switch ( planet.Size ) {
                case PlanetSize.AsteroidBelt:
                    planet.Gravity = ( this.Dice.d6( ) - 1 ) / 100.0;
                    break;
                case PlanetSize.SubLunar:
                    planet.Gravity = ( this.Dice.Roll( 1, 6, 4 ) ) / 100.0;
                    break;
                case PlanetSize.Lunar:
                    planet.Gravity = ( this.Dice.Roll( 1, 21, 9 ) ) / 100.0;
                    break;
                case PlanetSize.SuperLunar:
                    planet.Gravity = ( this.Dice.Roll( 1, 41, 29 ) ) / 100.0;
                    break;
                case PlanetSize.SubTerran:
                    planet.Gravity = ( this.Dice.Roll( 1, 31, 69 ) ) / 100.0;
                    break;
                case PlanetSize.Terran:
                    planet.Gravity = ( this.Dice.Roll( 1, 101, 99 ) ) / 100.0;
                    break;
                case PlanetSize.SuperTerran:
                    planet.Gravity = ( this.Dice.Roll( 1, 101, 199 ) ) / 100.0;
                    break;
                case PlanetSize.SubJovian:
                    planet.Gravity = ( this.Dice.Roll( 1, 101, 99 ) ) / 100.0;
                    break;
                case PlanetSize.Jovian:
                    planet.Gravity = ( this.Dice.Roll( 1, 101, 199 ) ) / 100.0;
                    break;
                case PlanetSize.SuperJovian:
                    planet.Gravity = ( this.Dice.Roll( 1, 301, 299 ) ) / 100.0;
                    break;
            }
        }

        ///=================================================================================================
        /// <summary>   Roll pressure. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="planet">   The planet. </param>
        ///=================================================================================================
        private void RollPressure( IPlanetaryBody planet ) {
            switch ( planet.Size ) {
                case PlanetSize.AsteroidBelt:
                    planet.Pressure = AtmosphericPressure.Vacuum;
                    break;
                case PlanetSize.SubLunar:
                    planet.Pressure = AtmosphericPressure.Vacuum;
                    break;
                case PlanetSize.Lunar:
                    planet.Pressure = (AtmosphericPressure) ( this.Dice.d3( ) - 5 );
                    break;
                case PlanetSize.SuperLunar:
                    planet.Pressure = (AtmosphericPressure) ( this.Dice.d4( ) - 5 );
                    break;
                case PlanetSize.SubTerran:
                    planet.Pressure = (AtmosphericPressure) ( this.Dice.d4( ) - 3 );
                    break;
                case PlanetSize.Terran:
                    planet.Pressure = (AtmosphericPressure) ( this.Dice.d4( ) - 2 );
                    break;
                case PlanetSize.SuperTerran:
                    planet.Pressure = (AtmosphericPressure) ( this.Dice.d4( ) );
                    break;
                case PlanetSize.SubJovian:
                    planet.Pressure = (AtmosphericPressure) ( this.Dice.d4( ) + 1 );
                    break;
                case PlanetSize.Jovian:
                    planet.Pressure = (AtmosphericPressure) ( this.Dice.d4( ) + 3 );
                    break;
                case PlanetSize.SuperJovian:
                    planet.Pressure = (AtmosphericPressure) ( this.Dice.d4( ) + 4 );
                    break;
            }
        }

        ///=================================================================================================
        /// <summary>   Roll toxicity. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="planet">   The planet. </param>
        ///=================================================================================================
        private void RollToxicity( Planet planet ) {
            planet.Toxicity = (Toxicity) ( this.Dice.d6( ) - 3 );
        }

        ///=================================================================================================
        /// <summary>   Roll temperature. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="planet">       The planet. </param>
        /// <param name="parentSystem"> The parent system. </param>
        ///=================================================================================================
        private void RollTemperature( IPlanetaryBody planet, ISolarSystem parentSystem ) {
            if ( planet.PlanetOrder == int.MaxValue &&
                 parentSystem != null &&
                 parentSystem.Planets != null ) {
                planet.PlanetOrder = ( parentSystem.Planets.Count == 0 )
                                         ? this.Dice.Roll( 1, 4, 1 )
                                         : this.Dice.Roll(
                                             1,
                                             2,
                                             -parentSystem.Planets[ parentSystem.Planets.Count - 1 ].PlanetOrder );
            }
            planet.Temperature = (Temperature) ( planet.PlanetOrder + planet.Pressure );

            int maxSize = planet.Size == PlanetSize.SubJovian ||
                          planet.Size == PlanetSize.Jovian ||
                          planet.Size == PlanetSize.SuperJovian
                              ? (int) planet.Size - 4
                              : (int) planet.Size - 3;
            int aboveSize = 0;
            int highestSize = 0;
            foreach ( var t in planet.LunarBodies ) {
                if ( (int) t.Size == maxSize ) {
                    highestSize++;
                }
                if ( (int) t.Size ==
                     ( maxSize - 1 ) ) {
                    aboveSize++;
                }
            }

            if ( highestSize >= 2 ||
                 aboveSize >= 3 ) {
                planet.Temperature++;
            }
        }

        ///=================================================================================================
        /// <summary>   Roll radiation level. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="planet">       The planet. </param>
        /// <param name="parentSystem"> The parent system. </param>
        ///=================================================================================================
        private void RollRadiationLevel( IPlanetaryBody planet, ISolarSystem parentSystem ) {
            if ( planet.PlanetOrder == int.MaxValue &&
                 parentSystem != null &&
                 parentSystem.Planets != null ) {
                planet.PlanetOrder = ( parentSystem.Planets.Count == 0 )
                                         ? this.Dice.Roll( 1, 4, 1 )
                                         : this.Dice.Roll(
                                             1,
                                             2,
                                             -parentSystem.Planets[ parentSystem.Planets.Count - 1 ].PlanetOrder );
            }
            planet.RadiationLevel = ( planet.PlanetOrder > 0 ? planet.PlanetOrder : 0 ) -
                                    ( planet.Pressure < AtmosphericPressure.Standard
                                          ? (int) planet.Pressure
                                          : 0 );
        }

        ///=================================================================================================
        /// <summary>   Roll number moons. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <param name="planet">       The planet. </param>
        /// <param name="numAsteroids"> [out] Number of asteroids. </param>
        /// <param name="numMoons">     [out] Number of moons. </param>
        ///=================================================================================================
        protected void RollNumMoons( Planet planet, out int numAsteroids, out int numMoons ) {
            numAsteroids = 0;
            numMoons = 0;
            switch ( planet.Size ) {
                case PlanetSize.AsteroidBelt:
                    numMoons = 0;
                    break;

                case PlanetSize.SubJovian:
                case PlanetSize.Jovian:
                case PlanetSize.SuperJovian:
                    numMoons = this.Dice.d12( );
                    numAsteroids = this.Dice.Roll( 10, 10 );
                    break;

                case PlanetSize.SubLunar:
                case PlanetSize.Lunar:
                    numAsteroids = (int) Math.Floor( this.Dice.d6( ) / 2.0 );
                    break;

                default:
                    numMoons = this.Dice.Roll( 1, 3, 2 );
                    break;
            }
        }

        ///=================================================================================================
        /// <summary>   Roll moons. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <param name="localLunar">   The local lunar. </param>
        /// <param name="numAsteroids"> [out] Number of asteroids. </param>
        /// <param name="numMoons">     [out] Number of moons. </param>
        /// <param name="planet">       The planet. </param>
        /// <param name="numRings">     (optional) number of rings. </param>
        ///=================================================================================================
        protected void RollMoons( ILunarGenerator localLunar,
                                  int numAsteroids,
                                  int numMoons,
                                  Planet planet,
                                  int numRings = -1 ) {
            planet.LunarBodies = numRings > -1
                                     ? new List<IPlanetaryBody>( numRings + numMoons + numAsteroids )
                                     : new List<IPlanetaryBody>( numMoons + numAsteroids );

            if ( numRings > -1 ) {
                planet.LunarBodies.Add( localLunar.GenerateRings( planet ) );
            }

            for ( var i = 0; i < numMoons; i++ ) {
                if ( planet.Size == PlanetSize.SubJovian || planet.Size == PlanetSize.Jovian ||
                     planet.Size == PlanetSize.SuperJovian ) {
                    var maxSize = (int)planet.Size - 4;
                    IPlanetaryBody moon;
                    do {
                        moon = localLunar.GenerateMoon( parentPlanet: planet );
                        if ( moon.Size ==
                             PlanetSize.Asteroid ) {
                            moon = localLunar.GenerateRings( planet );
                        }
                    } while ( (int)moon.Size > maxSize );
                    planet.LunarBodies.Add( moon );
                } else {
                    var maxSize = (int)planet.Size - 3;
                    IPlanetaryBody moon;
                    do {
                        moon = localLunar.GenerateLunarBody( parentPlanet: planet );
                        if ( moon.Size ==
                             PlanetSize.Ring ) {
                            moon = localLunar.GenerateAsteroid( planet );
                        }
                    } while ( !( (int) moon.Size <= maxSize || moon.Size == PlanetSize.Asteroid ) );
                    planet.LunarBodies.Add( moon );
                }
            }
            switch ( planet.Size ) {
                case PlanetSize.Lunar:
                case PlanetSize.SubLunar:
                case PlanetSize.AsteroidBelt:
                case PlanetSize.SuperJovian:
                case PlanetSize.Jovian:
                case PlanetSize.SubJovian:
                    break;
                default:
                    {
                        var allSmall = true;
                        for ( int i = 0; i < numMoons; i++ ) {
                            if ( planet.LunarBodies[ i ].Size !=
                                 PlanetSize.Asteroid ) {
                                allSmall = false;
                            }
                        }

                        if ( allSmall ) {
                            var rings = this.Dice.d10( );
                            planet.LunarBodies = new List<IPlanetaryBody>( rings );
                            for ( var i = 0; i < rings; i++ ) {
                                planet.LunarBodies.Add( localLunar.GenerateRings( planet ) );
                            }
                        }
                    }
                    break;
            }

            for ( var i = 0; i < numAsteroids; i++ ) {
                planet.LunarBodies.Add( localLunar.GenerateAsteroid( planet ) );
            }
        }

        ///=================================================================================================
        /// <summary>   Roll axial tilt. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="planet">   The planet. </param>
        ///=================================================================================================
        private void RollAxialTilt( IPlanetaryBody planet ) {
            planet.AxialTilt = this.Dice.Roll( 1, 4500 ) / 100.0;
        }

        ///=================================================================================================
        /// <summary>   Roll liquid surface percentage. </summary>
        ///
        /// <remarks>   Cdo, 3/28/2013. </remarks>
        ///
        /// <param name="planet">   The planet. </param>
        ///=================================================================================================
        private void RollLiquidSurfacePercentage( IPlanetaryBody planet ) {
            if ( planet.Size != PlanetSize.AsteroidBelt &&
                 planet.Size != PlanetSize.SubJovian &&
                 planet.Size != PlanetSize.Jovian &&
                 planet.Size != PlanetSize.SuperJovian &&
                 ( planet.Habitable || this.Dice.d4( ) == 4 ) ) {
                planet.LiquidSurfacePercentage = this.Dice.Roll( 10000 ) / 100.0;
            }
        }

        #endregion
    }
}
