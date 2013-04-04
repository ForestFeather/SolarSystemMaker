// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemLibrary - ISolarSystem.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 9:45 AM, 01/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System.Collections.Generic;

#endregion

namespace SolarSystemLibrary.Models {
    ///=================================================================================================
    /// <summary>   Interface for solar system. </summary>
    ///
    /// <remarks>   Cdo, 3/27/2013. </remarks>
    ///=================================================================================================
    public interface ISolarSystem {
        #region Properties

        ///=================================================================================================
        /// <summary>   Gets or sets the stars. </summary>
        ///
        /// <value> The stars. </value>
        ///=================================================================================================
        IList<IStar> Stars { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the planets. </summary>
        ///
        /// <value> The planets. </value>
        ///=================================================================================================
        IList<IPlanetaryBody> Planets { get; set; }

        ///=================================================================================================
        /// <summary>   Gets the number of stars. </summary>
        ///
        /// <value> The total number of stars. </value>
        ///=================================================================================================
        int NumStars { get; }

        ///=================================================================================================
        /// <summary>   Gets the number of planets. </summary>
        ///
        /// <value> The total number of planets. </value>
        ///=================================================================================================
        int NumPlanets { get; }

        ///=================================================================================================
        /// <summary>   Gets the number of moons. </summary>
        ///
        /// <value> The total number of moons. </value>
        ///=================================================================================================
        int NumMoons { get; }

        ///=================================================================================================
        /// <summary>   Gets the number of habitable planets. </summary>
        ///
        /// <value> The total number of habitable planets. </value>
        ///=================================================================================================
        int NumHabitablePlanets { get; }

        ///=================================================================================================
        /// <summary>   Gets the number of habitable moons. </summary>
        ///
        /// <value> The total number of habitable moons. </value>
        ///=================================================================================================
        int NumHabitableMoons { get; }

        ///=================================================================================================
        /// <summary>   Gets the number of habitable bodies. </summary>
        ///
        /// <value> The total number of habitable bodies. </value>
        ///=================================================================================================
        int NumHabitableBodies { get; }

        ///=================================================================================================
        /// <summary>   Gets the number of solid planets. </summary>
        ///
        /// <value> The total number of solid planets. </value>
        ///=================================================================================================
        int NumSolidPlanets { get; }

        ///=================================================================================================
        /// <summary>   Gets the number of jovian planets. </summary>
        ///
        /// <value> The total number of jovian planets. </value>
        ///=================================================================================================
        int NumJovianPlanets { get; }

        ///=================================================================================================
        /// <summary>   Gets the number of asteroid belts. </summary>
        ///
        /// <value> The total number of asteroid belts. </value>
        ///=================================================================================================
        int NumAsteroidBelts { get; }

        #endregion
    }
}
