// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - PlanetSize.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 2:33 PM, 27/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

using System.ComponentModel;

namespace SolarSystemLibrary {
    ///=================================================================================================
    /// <summary>   Values that represent PlanetSize. </summary>
    ///
    /// <remarks>   Cdo, 3/27/2013. </remarks>
    ///=================================================================================================
    public enum PlanetSize {
        /// <summary>   . </summary>
        [Description("Asteroid Belt")] 
        AsteroidBelt = 1,

        /// <summary>   . </summary>
        [Description("Sub-Lunar")] 
        SubLunar,

        /// <summary>   . </summary>
        [Description("Lunar")] 
        Lunar,

        /// <summary>   . </summary>
        [Description("Super Lunar")] 
        SuperLunar,

        /// <summary>   . </summary>
        [Description("Sub-Terran")] 
        SubTerran,

        /// <summary>   . </summary>
        [Description("Terran")] 
        Terran,

        /// <summary>   . </summary>
        [Description("Super Terran")] 
        SuperTerran,

        /// <summary>   . </summary>
        [Description("Sub-Jovian")] 
        SubJovian,

        /// <summary>   . </summary>
        [Description("Jovian")] 
        Jovian,

        /// <summary>   . </summary>
        [Description("Super Jovian")] 
        SuperJovian,

        /// <summary>   . </summary>
        [Description("Asteroid")] 
        Asteroid,

        /// <summary>   . </summary>
        [Description("Ring")] 
        Ring,

        /// <summary>   . </summary>
        [Description("Null")] 
        NullSize
    }
}
