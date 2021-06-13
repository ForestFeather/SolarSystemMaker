// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - Temperature.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 2:19 PM, 27/03/2013
// 
//  Notes:
//  
// ==========================================================================================================
using System.ComponentModel;

namespace SolarSystemLibrary {

    ///=================================================================================================
    /// <summary>   Values that represent Temperature. </summary>
    ///
    /// <remarks>   Cdo, 3/27/2013. </remarks>
    ///=================================================================================================
    public enum Temperature {
        /// <summary>   . </summary>
        [Description("Absolute Zero")] 
        AbsoluteZero = -5,
        /// <summary>   . </summary>
        [Description("Vacuum")] 
        Vacuum,
        /// <summary>   . </summary>
        [Description("Sunny Vacuum")]
        SunnyVacuum,
        /// <summary>   . </summary>
        [Description("Arctic")] 
        Arctic,
        /// <summary>   . </summary>
        [Description("Temperate Winter")] 
        TemperateWinter,
        /// <summary>   . </summary>
        [Description("Earth Normal")] 
        EarthNorm,
        /// <summary>   . </summary>
        [Description("Desert Summer")] 
        DesertSummer,
        /// <summary>   . </summary>
        [Description("High Heat")] 
        HighHeat,
        /// <summary>   . </summary>
        [Description("Boiling Water")] 
        BoilingWater,
        /// <summary>   . </summary>
        [Description("Atmospheric Re-Entry")] 
        AtmosphericReentry,
        /// <summary>   . </summary>
        [Description("Melting Metal")] 
        MetalMelting,
        /// <summary>   . </summary>
        [Description("Melting Glass")] 
        GlassMelting,
        /// <summary>   . </summary>
        [Description("Jovian Core")] 
        JovianCore,
        /// <summary>   . </summary>
        [Description("Stellar Surface")] 
        StarSurface
    }
}