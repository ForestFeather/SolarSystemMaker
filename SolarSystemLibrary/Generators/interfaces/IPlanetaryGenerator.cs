// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - IPlanetaryGenerator.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 7:06 AM, 28/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using SolarSystemLibrary.Models.interfaces;

#endregion

namespace SolarSystemLibrary.support.interfaces {
    ///=================================================================================================
    /// <summary>   Interface for planetary generator. </summary>
    ///
    /// <remarks>   Cdo, 3/27/2013. </remarks>
    ///=================================================================================================
    public interface IPlanetaryGenerator {
        #region Properties

        ///=================================================================================================
        /// <summary>   Gets or sets the lunar generator. </summary>
        ///
        /// <value> The lunar generator. </value>
        ///=================================================================================================
        ILunarGenerator LunarGenerator { get; set; }

        ///=================================================================================================
        /// <summary>   Gets a value indicating whether the initialized. </summary>
        ///
        /// <value> true if initialized, false if not. </value>
        ///=================================================================================================
        bool Initialized { get; }

        #endregion

        #region Members

        ///=================================================================================================
        /// <summary>   Initializes this object. </summary>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ///=================================================================================================
        bool Initialize( );

        ///=================================================================================================
        /// <summary>   Generates a planetary body. </summary>
        ///
        /// <param name="size">             (optional) the size. </param>
        /// <param name="lunarBodyCount">   (optional) number of lunar bodies. </param>
        /// <param name="ringCount">        (optional) number of rings. </param>
        /// <param name="asteroidCount">    (optional) number of asteroids. </param>
        /// <param name="moonCount">        (optional) number of moons. </param>
        /// <param name="planetOrder">      (optional) the planet order. </param>
        /// <param name="waterCoverage">    (optional) the water coverage. </param>
        /// <param name="techLevel">        (optional) the technology level. </param>
        /// <param name="parentSystem">     (optional) the parent system. </param>
        /// <param name="lunarGenerator">   (optional) the lunar generator. </param>
        ///
        /// <returns>   The planetary body. </returns>
        ///=================================================================================================
        IPlanetaryBody GeneratePlanetaryBody( PlanetSize size = PlanetSize.NullSize,
                                              int lunarBodyCount = -1,
                                              int ringCount = -1,
                                              int asteroidCount = -1,
                                              int moonCount = -1,
                                              int planetOrder = -1,
                                              double waterCoverage = -1.0,
                                              TechLevel techLevel = TechLevel.Uninhabited,
                                              ISolarSystem parentSystem = null,
                                              ILunarGenerator lunarGenerator = null );

        ///=================================================================================================
        /// <summary>   Generates an asteroid belt. </summary>
        ///
        /// <param name="parentSystem"> (optional) the parent system. </param>
        ///
        /// <returns>   The asteroid belt. </returns>
        ///=================================================================================================
        IPlanetaryBody GenerateAsteroidBelt( ISolarSystem parentSystem = null );

        ///=================================================================================================
        /// <summary>   Generates a solid planet. </summary>
        ///
        /// <param name="size">             (optional) the size. </param>
        /// <param name="lunarBodyCount">   (optional) number of lunar bodies. </param>
        /// <param name="ringCount">        (optional) number of rings. </param>
        /// <param name="asteroidCount">    (optional) number of asteroids. </param>
        /// <param name="moonCount">        (optional) number of moons. </param>
        /// <param name="planetOrder">      (optional) the planet order. </param>
        /// <param name="waterCoverage">    (optional) the water coverage. </param>
        /// <param name="techLevel">        (optional) the technology level. </param>
        /// <param name="parentSystem">     (optional) the parent system. </param>
        /// <param name="lunarGenerator">   (optional) the lunar generator. </param>
        ///
        /// <returns>   The solid planet. </returns>
        ///=================================================================================================
        IPlanetaryBody GenerateSolidPlanet( PlanetSize size = PlanetSize.NullSize,
                                            int lunarBodyCount = -1,
                                            int ringCount = -1,
                                            int asteroidCount = -1,
                                            int moonCount = -1,
                                            int planetOrder = -1,
                                            double waterCoverage = -1.0,
                                            TechLevel techLevel = TechLevel.Uninhabited,
                                            ISolarSystem parentSystem = null,
                                            ILunarGenerator lunarGenerator = null );

        ///=================================================================================================
        /// <summary>   Generates the gas giant planet. </summary>
        ///
        /// <param name="size">             (optional) the size. </param>
        /// <param name="lunarBodyCount">   (optional) number of lunar bodies. </param>
        /// <param name="ringCount">        (optional) number of rings. </param>
        /// <param name="asteroidCount">    (optional) number of asteroids. </param>
        /// <param name="moonCount">        (optional) number of moons. </param>
        /// <param name="planetOrder">      (optional) the planet order. </param>
        /// <param name="parentSystem">     (optional) the parent system. </param>
        /// <param name="lunarGenerator">   (optional) the lunar generator. </param>
        ///
        /// <returns>   The gas giant planet. </returns>
        ///=================================================================================================
        IPlanetaryBody GenerateGasGiantPlanet( PlanetSize size = PlanetSize.NullSize,
                                               int lunarBodyCount = -1,
                                               int ringCount = -1,
                                               int asteroidCount = -1,
                                               int moonCount = -1,
                                               int planetOrder = -1,
                                               ISolarSystem parentSystem = null,
                                               ILunarGenerator lunarGenerator = null );

        ///=================================================================================================
        /// <summary>   Generates a habitable planet. </summary>
        ///
        /// <param name="size">             (optional) the size. </param>
        /// <param name="lunarBodyCount">   (optional) number of lunar bodies. </param>
        /// <param name="ringCount">        (optional) number of rings. </param>
        /// <param name="asteroidCount">    (optional) number of asteroids. </param>
        /// <param name="moonCount">        (optional) number of moons. </param>
        /// <param name="planetOrder">      (optional) the planet order. </param>
        /// <param name="waterCoverage">    (optional) the water coverage. </param>
        /// <param name="techLevel">        (optional) the technology level. </param>
        /// <param name="parentSystem">     (optional) the parent system. </param>
        /// <param name="lunarGenerator">   (optional) the lunar generator. </param>
        ///
        /// <returns>   The habitable planet. </returns>
        ///=================================================================================================
        IPlanetaryBody GenerateHabitablePlanet( PlanetSize size = PlanetSize.NullSize,
                                                int lunarBodyCount = -1,
                                                int ringCount = -1,
                                                int asteroidCount = -1,
                                                int moonCount = -1,
                                                int planetOrder = -1,
                                                double waterCoverage = -1.0,
                                                TechLevel techLevel = TechLevel.Uninhabited,
                                                ISolarSystem parentSystem = null,
                                                ILunarGenerator lunarGenerator = null );

        #endregion
    }
}
